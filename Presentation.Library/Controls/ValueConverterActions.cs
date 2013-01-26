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
using System.Collections.Generic;
using System.Linq;
using Presentation.Library.Model;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Controls
{
   public sealed partial class NullValueConverter
   {
      partial void Convert (object from, ref object to, object parameter, ref bool handled)
      {
         to = from;
         handled = true;
      }

      partial void ConvertBack (object to, ref object from, object parameter, ref bool handled)
      {
         from = to;
         handled = true;
      }
   }

   public sealed partial class TypeToBoolValueConverter
   {
      static readonly Type[] s_default = 
         new[]
            {
               typeof (BaseElement),
            };
      static readonly IDictionary<string, Type[]> s_typesToTestAgainst;

      static TypeToBoolValueConverter ()
      {
         var typesToTestAgainst = new Dictionary<string, Type[]> ();
         typesToTestAgainst["Font"] = 
            new[]
               {
                  typeof (TextElement),
               };
         typesToTestAgainst["Color"] = 
            new[]
               {
                  typeof (TextElement),
                  typeof (ShapeElement),
               };
         s_typesToTestAgainst = typesToTestAgainst;
      }

      partial void Convert (object from, ref bool to, string parameter, ref bool handled)
      {
         var typesToTestAgainst = s_typesToTestAgainst.Lookup (parameter ?? "", s_default);

         if (from != null)
         {
            var fromType = from.GetType ();
            to = typesToTestAgainst.FirstOrDefault (type => type.IsAssignableFrom (fromType)) != null;
         }
         else
         {
            to = false;
         }

         handled = true;
      }
   }
}
