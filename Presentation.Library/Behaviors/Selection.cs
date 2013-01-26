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
using System.Windows;
using System.Windows.Input;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Behaviors
{
   public interface ISelector
   {
      void SetSelection (
         Action clearSelection,
         DependencyObject selection
         );
   }

   public static partial class Selection
   {
      public sealed class SelectionHandler : BaseAttachedState
      {
         public DependencyObject Instance;

         public SelectionHandler (FrameworkElement attachedObject) 
            :  base (attachedObject)
         {
         }

         protected override void OnAttached ()
         {
            AttachedObject.GotFocus += AttachedObject_GotFocus;

            MouseButtonEventHandler mouseLeftButtonDown = AttachedObject_MouseLeftButtonDown;
            AttachedObject.AddHandler (UIElement.MouseLeftButtonDownEvent, mouseLeftButtonDown, true);
         }

         void AttachedObject_MouseLeftButtonDown (object sender, MouseButtonEventArgs e)
         {
            SetSelection ();
         }

         void SetSelection ()
         {
            var selector = AttachedObject.FindParentOfType<ISelector> ();

            if (selector != null && Instance != null)
            {
               selector.SetSelection (ClearSelection, Instance);
               SetSelectionVisibility (AttachedObject, Visibility.Visible);
            }
         }

         void ClearSelection ()
         {
            Debug.WriteLine("ClearSelection");
            SetSelectionVisibility (AttachedObject, Visibility.Collapsed);
         }

         void AttachedObject_GotFocus (object sender, RoutedEventArgs e)
         {
            SetSelection ();
         }
      }

      static SelectionHandler Setup (FrameworkElement dobj)
      {
         var handler = GetHandler (dobj);
         if (handler == null)
         {
            handler = new SelectionHandler (dobj);
            SetHandler (dobj, handler);
         }
         return handler;
      }

      static partial void OnChange_Instance (FrameworkElement dobj, DependencyObject oldValue, DependencyObject newValue, ref bool handled)
      {
         var sel = Setup (dobj);
         sel.Instance = newValue;
         handled = true;
      }
   }
}
