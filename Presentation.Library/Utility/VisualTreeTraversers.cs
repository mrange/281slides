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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Presentation.Library.Utility
{
   public static class VisualTreeTraversers
   {
      public static UIElement GetRoot (
         this DependencyObject dependencyObject)
      {
         if (dependencyObject == null)
         {
            return null;
         }

         var parent = VisualTreeHelper.GetParent (dependencyObject);

         return parent != null ? parent.GetRoot () : (UIElement)dependencyObject;
      }

      public static bool IsRoot (
         this DependencyObject dependencyObject
         )
      {
         if (dependencyObject == null)
         {
            return false;
         }

         var parent = VisualTreeHelper.GetParent (dependencyObject);

         return parent == null;
      }

      public static T FindParentOfType<T>(
         this DependencyObject dependencyObject)
         where T : class
      {
         if (dependencyObject == null)
         {
            return null;
         }

         var parent = VisualTreeHelper.GetParent (dependencyObject);

         return parent is T ? (T)(object) parent : parent.FindParentOfType<T> ();
      }

      public static DependencyObject FindChildToParentOfType<T>(
         this DependencyObject dependencyObject)
         where T : UIElement
      {
         if (dependencyObject == null)
         {
            return null;
         }

         var parent = VisualTreeHelper.GetParent (dependencyObject);

         return parent is T 
            ? dependencyObject 
            : parent.FindChildToParentOfType<T> ();
      }

      public static UIElement FindParentInclusive (
         this DependencyObject dependencyObject,
         Func<UIElement, bool> testPredicate
         )
      {
         if (dependencyObject == null)
         {
            return null;
         }

         var uiElement = dependencyObject as UIElement;

         if (uiElement != null && testPredicate (uiElement))
         {
            return uiElement;
         }

         var parent = VisualTreeHelper.GetParent (dependencyObject);
         return parent.FindParentInclusive (testPredicate);
      }

      [Conditional ("DEBUG")]
      static void PrintVisualTree (
         StringBuilder sb,
         int indent,
         DependencyObject dobj)
      {
         if (dobj != null)
         {
            var name = dobj.GetValue (FrameworkElement.NameProperty) as string;

            var indentString = new string (' ', indent * 3);

            sb.AppendFormat (
               "{0}{1}({2})\r\n",
               indentString,
               dobj.GetType ().Name,
               name.IsNullOrEmpty () ? "<UNNAMED>" : name
               );

            var count = VisualTreeHelper.GetChildrenCount (dobj);
            if (count > 0)
            {
               sb.AppendFormat ("{0}[\r\n", indentString);
               foreach (var child in dobj.GetVisualChildren ())
               {
                  PrintVisualTree (
                     sb,
                     indent + 1,
                     child);
               }
               sb.AppendFormat ("{0}]\r\n", indentString);
            }
         }

      }

      [Conditional ("DEBUG")]
      public static void TraceVisualTree (this UIElement uiElement)
      {
         var sb = new StringBuilder ();

         PrintVisualTree (
            sb,
            0,
            uiElement);

         Debug.WriteLine (sb.ToString ());
      }

      public static IEnumerable<UIElement> GetVisualChildren (
         this DependencyObject dependencyObject)
      {
         if (dependencyObject != null )
         {
            var childCount = VisualTreeHelper.GetChildrenCount (dependencyObject);

            for (var iter = 0; iter < childCount; ++iter)
            {
               var uiElement = VisualTreeHelper.GetChild (dependencyObject, iter) as UIElement;

               if (uiElement != null)
               {
                  yield return uiElement;
               }
            }
         }
      }

      public static IEnumerable<UIElement> WhereVisualChildren (
         this DependencyObject dependencyObject,
         Func<UIElement, bool> testPredicate
         )
      {
         var uiElement = dependencyObject as UIElement;
         if (uiElement == null)
         {
            yield break;
         }

         if (testPredicate (uiElement))
         {
            yield return uiElement;
         }

         foreach (var child in uiElement
            .GetVisualChildren ()
            .SelectMany (c => c.WhereVisualChildren (testPredicate)))
         {
            yield return child;
         }
      }
   }
}
