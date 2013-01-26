// ----------------------------------------------------------------------------------------------
// Copyright (c) Mårten Rånge.
// ----------------------------------------------------------------------------------------------
// This source code is subject to terms and conditions of the Microsoft Public License. A 
// copy of the license can be found in the License.html file at the root of this distribution. 
// If you cannot locate the  Microsoft Public License, please send an email to 
// dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
//  by the terms of the Microsoft Public License.
// ----------------------------------------------------------------------------------------------
// You must not remove this notice, or any other, from this software.
// ----------------------------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Collections;
using System.Collections.Generic;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Model
{
   using SLE = System.Linq.Expressions;
   public static partial class ModelCopier
   {
      static void CopyImpl (
            ModelContext modelContext
         ,  BaseModelEntity assignvalue
         ,  BaseModelEntity value
         )
      {
      }

      static void Copy (ModelContext modelContext, Size fromValue, out Size toValue)
      {
         toValue = fromValue;
      }

      static void Copy (ModelContext modelContext, DateTime fromValue, out DateTime toValue)
      {
         toValue = fromValue;
      }

      static void Copy (ModelContext modelContext, int fromValue, out int toValue)
      {
         toValue = fromValue;
      }

      static void Copy (ModelContext modelContext, double fromValue, out double toValue)
      {
         toValue = fromValue;
      }

      static void Copy (ModelContext modelContext, bool fromValue, out bool toValue)
      {
         toValue = fromValue;
      }

      static void Copy (ModelContext modelContext, string fromValue, out string toValue)
      {
         toValue = fromValue;
      }

      static void Copy (ModelContext modelContext, Color fromValue, out Color toValue)
      {
         toValue = fromValue;
      }
   }

   public interface IFactory
   {
      object CreateCollection (Type itemType, IEnumerable e);
      object CreateInstance (Type type);
   }

   public sealed class ModelCopier2
   {
      public sealed class PropertyDescription
      {
         public string Name;
         public Type Type;
         public Type ItemType;
         public Func<object, object> Getter;
         public Action<object, object> Setter;
      }

      public sealed class TypeDescription
      {
         public string Name;
         public IDictionary<string, PropertyDescription> Properties;
      }

      readonly IDictionary<Type, TypeDescription> m_typeDescriptions = 
         new Dictionary<Type, TypeDescription> ();

      static SLE.Expression CastIfNecessary (SLE.Expression input, Type castTo)
      {
         return input.Type != castTo 
            ? SLE.Expression.Convert (input, castTo) 
            : input
            ;
      }

      static Func<object, object> GeneratePropertyGetter (PropertyInfo propertyInfo)
      {
         var getMethodInfo = propertyInfo.GetGetMethod ();

         if (getMethodInfo == null)
         {
            return null;
         }

         var instanceParameter = SLE.Expression.Parameter (typeof (object), "instance");

         var expr = SLE.Expression.Lambda<Func<object, object>> (
            CastIfNecessary (
               SLE.Expression.Call (
                  CastIfNecessary (instanceParameter, propertyInfo.DeclaringType),
                  getMethodInfo
                  ),
               typeof (object)
               ),
            instanceParameter
            );

         return expr.Compile ();
      }

      static Action<object, object> GeneratePropertySetter (PropertyInfo propertyInfo)
      {
         var setMethodInfo = propertyInfo.GetSetMethod ();

         if (setMethodInfo == null)
         {
            return null;
         }

         var instanceParameter = SLE.Expression.Parameter (typeof (object), "instance");
         var inputParameter = SLE.Expression.Parameter (typeof (object), "input");

         var expr = SLE.Expression.Lambda<Action<object, object>> (
            SLE.Expression.Call (
               CastIfNecessary (instanceParameter, propertyInfo.DeclaringType),
               setMethodInfo,
               CastIfNecessary (inputParameter, propertyInfo.PropertyType)
               ), 
            instanceParameter,
            inputParameter
            );

         return expr.Compile ();
      }

      static PropertyDescription GeneratePropertyDescription (MemberInfo memberInfo)
      {
         var propertyInfo = memberInfo as PropertyInfo;

         if (propertyInfo != null)
         {
            return new PropertyDescription
                   {
                      Name = propertyInfo.Name,
                      Type = propertyInfo.PropertyType,
                      ItemType = propertyInfo
                        .PropertyType
                        .GetInterfaces ()
                        .Where (t => t.IsGenericType && typeof (IEnumerable<>) == t.GetGenericTypeDefinition ())
                        .Select(t => t.GetGenericArguments ()[0])
                        .FirstOrDefault(),
                      Getter = GeneratePropertyGetter (propertyInfo),
                      Setter = GeneratePropertySetter (propertyInfo),
                   };
         }

         return null;
      }
      
      TypeDescription GetTypeDescription (Type type)
      {
         return m_typeDescriptions.LookupOrAdd (type, () => GenerateTypeDescription (type));
      }

      static TypeDescription GenerateTypeDescription (Type type)
      {
         var propertyDescriptions = type
            .GetMembers ()
            .Select (GeneratePropertyDescription)
            .Where (pd => pd != null)
            .ToDictionary (pd => pd.Name)
            ;
         return new TypeDescription
            {
               Name = type.Name,
               Properties = propertyDescriptions,
            };
      }

      public void Copy<TSource, TDestination> (
         IFactory factory,
         TSource source,
         out TDestination destination
         )
         where TSource : class 
         where TDestination : class
      {
         if (source == null)
         {
            destination = null;
            return;
         }
         object result;
         Copy (factory, typeof (TSource), source, typeof (TDestination), out result);
         destination = (TDestination) result;
      }

      void Copy (
         IFactory factory,
         Type sourceType, 
         object source, 
         Type destinationType, 
         out object destination
         )
      {
         var sourceTd = GetTypeDescription (sourceType);
         var destinationTd = GetTypeDescription (destinationType);

         destination = factory.CreateInstance (destinationType);

         foreach (var pd in sourceTd.Properties)
         {
            var sourcePd = pd.Value;

            var destinationPd = destinationTd.Properties.Lookup (sourcePd.Name);

            if (destinationPd == null)
            {
               continue;
            }

            if (sourcePd.Getter == null)
            {
               continue;;
            }

            if (destinationPd.Setter == null)
            {
               continue;
            }

            var sourceValue = sourcePd.Getter (source);

            if (sourceValue == null)
            {
               continue;
            }

            if (!sourcePd.Type.IsClass || sourcePd.Type == typeof (string))
            {
               var newValue = sourcePd.Type == destinationPd.Type 
                  ? sourceValue 
                  : Convert.ChangeType (
                        sourceValue
                     ,  destinationPd.Type
                     ,  CultureInfo.InvariantCulture
                     );

               destinationPd.Setter (destination, newValue);
            }
            else if (sourcePd.ItemType != null)
            {
               Debug.Assert (destinationPd.ItemType != null);

               var result = new List<object> ();

               foreach (var sourceItem in ((IEnumerable)sourceValue))
               {
                  object destinationItem;
                  Copy (factory, sourcePd.ItemType, sourceItem, destinationPd.ItemType, out destinationItem);
                  result.Add (destinationItem);
               }

               destinationPd.Setter (destination, factory.CreateCollection (destinationPd.ItemType, result));
            }
            else
            {
               object newValue;
               Copy (factory, sourcePd.Type, sourceValue, destinationPd.Type, out newValue);
               destinationPd.Setter (destination, newValue);
            }
         }
      }
   }

}
