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
using Presentation.Library.Utility;

namespace Presentation.Library.Controls
{
   public partial class WatermarkTextBox : TextBox
   {
      bool m_hasFocus;

      public WatermarkTextBox ()
      {
         DefaultStyleKey = typeof (WatermarkTextBox);

         LostFocus += WatermarkTextBox_LostFocus;
         GotFocus += WatermarkTextBox_GotFocus;
         TextChanged += WatermarkTextBox_TextChanged;
         Loaded += WatermarkTextBox_Loaded;
      }

      void WatermarkTextBox_Loaded (object sender, RoutedEventArgs e)
      {
         Update ();
      }

      void Update ()
      {
         WatermarkVisibility = (Text.IsNullOrEmpty () /*&& !m_hasFocus*/) 
            ? Visibility.Visible 
            : Visibility.Collapsed
            ;
      }

      void WatermarkTextBox_TextChanged (object sender, TextChangedEventArgs e)
      {
         Update ();
      }

      void WatermarkTextBox_GotFocus (object sender, RoutedEventArgs e)
      {
         m_hasFocus = true;
         Update ();
      }

      void WatermarkTextBox_LostFocus (object sender, RoutedEventArgs e)
      {
         m_hasFocus = false;
         Update ();
      }
   }

   public partial class SearchTextBox : WatermarkTextBox
   {
      public SearchTextBox ()
      {
         DefaultStyleKey = typeof (SearchTextBox);

         TextChanged += SearchTextBox_TextChanged;
      }

      void SearchTextBox_TextChanged (object sender, TextChangedEventArgs e)
      {
         SearchText = Text;
      }
   }

}
