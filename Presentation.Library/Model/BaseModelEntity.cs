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
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows;

namespace Presentation.Library.Model
{
   public interface IBaseModelEntity
   {
      
   }

   public abstract partial class BaseModelEntity : DependencyObject, IBaseModelEntity
   {
      protected BaseModelEntity (ModelContext modelContext)
      {
         ModelContext = modelContext;
      }

      public ModelContext ModelContext
      {
         get; 
         set;
      }

      protected void Update<TParent, T> (TParent parent, T value)
         where TParent : BaseModelEntity
      {
         if (value is BaseModelEntity)
         {
            var baseModelEntity = ((BaseModelEntity)(object)value);
            baseModelEntity.Update (parent);
         }

         if (value is IList)
         {
            var list = (IList)value;
            foreach (var subValue in list)
            {
               Update (parent, subValue);
            }
         }
         
      }

      public abstract void Update<TParent> (TParent parent)
         where TParent : BaseModelEntity;

      protected void OnCollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.CollectionChange : Action:{0}, Instance:{1}", e.Action, sender);
#endif
         var mc = ModelContext;
         var list = sender as IList;

         if (mc != null && list != null && mc.IsChangeTracking)
         {
            mc.AppendCollectionChangedAction (
               list,
               e
               );
         }
      }
   }
}
