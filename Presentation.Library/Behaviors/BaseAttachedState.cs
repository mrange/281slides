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
using System.Windows;

namespace Presentation.Library.Behaviors
{
   public abstract class BaseAttachedState
   {
      public readonly FrameworkElement AttachedObject;

      protected BaseAttachedState (FrameworkElement attachedObject)
      {
         AttachedObject = attachedObject;
         AttachedObject.Loaded += AttachedObject_Loaded;
      }

      void AttachedObject_Loaded (object sender, RoutedEventArgs e)
      {
         OnAttached ();
      }
      protected abstract void OnAttached ();
   }
}
