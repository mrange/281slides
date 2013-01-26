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

// ReSharper disable ConstantNullCoalescingCondition
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable HeuristicUnreachableCode
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast
// ReSharper disable RedundantIfElseBlock

#pragma warning disable 183

namespace Presentation.Library.Controls
{
   using System;
   using System.Globalization;
   using System.Windows;
   using System.Windows.Data;

   public partial class NullValueConverter : IValueConverter 
   {
      public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
      {
         if ((value == null || value is object) && typeof (object) == targetType)
         {
            var from = (object)(value ?? default (object));
            var to = default (object);
            var handled = false;

            Convert (from, ref to, parameter as object, ref handled);

            if (handled)
            {
               return to;
            }
            else
            {
               return default (object);
            }
         }
         else
         {
            return DependencyProperty.UnsetValue;
         }
      }

      public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
      {
         if ((value == null || value is object) && typeof (object) == targetType)
         {
            var from = default (object);
            var to = (object) (value ?? default (object));
            var handled = false;

            ConvertBack (to, ref from, parameter as object, ref handled);

            if (handled)
            {
               return from;
            }
            else
            {
               return default (object);
            }
         }
         else
         {
            return DependencyProperty.UnsetValue;
         }
      }

      partial void Convert (object from, ref object to, object parameter, ref bool handled);
      partial void ConvertBack (object to, ref object from, object parameter, ref bool handled);
   }
   public partial class TypeToBoolValueConverter : IValueConverter 
   {
      public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
      {
         if ((value == null || value is object) && typeof (bool) == targetType)
         {
            var from = (object)(value ?? default (object));
            var to = default (bool);
            var handled = false;

            Convert (from, ref to, parameter as string, ref handled);

            if (handled)
            {
               return to;
            }
            else
            {
               return default (bool);
            }
         }
         else
         {
            return DependencyProperty.UnsetValue;
         }
      }

      public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
      {
         if ((value == null || value is bool) && typeof (object) == targetType)
         {
            var from = default (object);
            var to = (bool) (value ?? default (bool));
            var handled = false;

            ConvertBack (to, ref from, parameter as string, ref handled);

            if (handled)
            {
               return from;
            }
            else
            {
               return default (bool);
            }
         }
         else
         {
            return DependencyProperty.UnsetValue;
         }
      }

      partial void Convert (object from, ref bool to, string parameter, ref bool handled);
      partial void ConvertBack (bool to, ref object from, string parameter, ref bool handled);
   }
}

