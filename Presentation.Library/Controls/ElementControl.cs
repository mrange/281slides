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
using System.Windows.Controls;
using Presentation.Library.Model;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Controls
{
   public class PresentingElementControl : BaseElementControl
   {
      public PresentingElementControl ()
      {
         DefaultStyleKey = typeof (PresentingElementControl);
      }
   }

   public class EditingElementControl : BaseElementControl
   {
      public EditingElementControl ()
      {
         DefaultStyleKey = typeof (EditingElementControl);
      }
   }

   public partial class BaseElementControl : Control
   {
      bool m_loaded;

      protected BaseElementControl ()
      {
         
         Loaded += ElementControl_Loaded;
      }

      void ElementControl_Loaded (object sender, System.Windows.RoutedEventArgs e)
      {
         m_loaded = true;
         Update ();
      }

      void Update ()
      {
         if (!m_loaded)
         {
            return;
         }

         var element = Element;
         if (element != null)
         {
            if (element is TextElement)
            {
               ElementTemplate = TextElementTemplate ?? DefaultElementTemplate;
            }
            else if (element is ShapeElement)
            {
               ElementTemplate = ShapeElementTemplate ?? DefaultElementTemplate;
            }
            else if (element is PictureElement)
            {
               ElementTemplate = PictureElementTemplate ?? DefaultElementTemplate;
            }
            else if (element is MovieElement)
            {
               ElementTemplate = MovieElementTemplate ?? DefaultElementTemplate;
            }
            else
            {
               ElementTemplate = DefaultElementTemplate;
            }
         }
         else
         {
            ElementTemplate = DefaultElementTemplate;
         }
      }

      partial void OnChange_TextElementTemplate (System.Windows.DataTemplate oldValue, System.Windows.DataTemplate newValue, ref bool handled)
      {
         Update ();
         handled = true;
      }

      partial void OnChange_ShapeElementTemplate (System.Windows.DataTemplate oldValue, System.Windows.DataTemplate newValue, ref bool handled)
      {
         Update ();
         handled = true;
      }

      partial void OnChange_PictureElementTemplate (System.Windows.DataTemplate oldValue, System.Windows.DataTemplate newValue, ref bool handled)
      {
         Update ();
         handled = true;
      }

      partial void OnChange_MovieElementTemplate (System.Windows.DataTemplate oldValue, System.Windows.DataTemplate newValue, ref bool handled)
      {
         Update ();
         handled = true;
      }

      partial void  OnChange_Element (BaseElement oldValue, Model.BaseElement newValue, ref bool handled)
      {
         Update ();
         handled = true;
      }
   }
}
