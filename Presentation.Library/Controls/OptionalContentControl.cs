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

// ReSharper disable UnusedParameter.Local

using System.Windows;
using System.Windows.Controls;

namespace Presentation.Library.Controls
{
   public partial class OptionalContentControl : ContentControl
   {
      partial void OnChange_OptionalContent (object oldValue, object newValue, ref bool handled)
      {
         if (newValue != null && OptionalContentTemplate != null)
         {
            var uiElement = OptionalContentTemplate.LoadContent ();
            var frameworkElement = uiElement as FrameworkElement;
            if (frameworkElement != null)
            {
               frameworkElement.DataContext = OptionalContent;
            }

            Content = uiElement;
         }
         else
         {
            Content = null;
         }
      }
   }
}
