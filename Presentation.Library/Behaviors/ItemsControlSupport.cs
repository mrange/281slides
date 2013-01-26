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
using System.Windows.Controls;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Behaviors
{
   public sealed partial class ItemsControlSupport
   {

      static partial void OnChange_ZIndex(FrameworkElement dobj, int oldValue, int newValue, ref bool handled)
      {
         var panelChild = dobj.FindChildToParentOfType<Panel> () as UIElement;

         if (panelChild != null)
         {
            Canvas.SetZIndex(panelChild, newValue);
         }

         handled = true;
      }
   }
}
