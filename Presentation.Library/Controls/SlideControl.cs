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
using System.Windows;
using System.Windows.Controls;
using Presentation.Library.Behaviors;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Controls
{
   public class PresentingSlideControl : BaseSlideControl
   {
      public PresentingSlideControl ()
      {
         DefaultStyleKey = typeof (PresentingSlideControl);
      }
   }

   public partial class EditingSlideControl : BaseSlideControl, ISelector
   {
      Action m_clearSelection;

      public EditingSlideControl ()
      {
         DefaultStyleKey = typeof (EditingSlideControl);
      }

      public void SetSelection (Action clearSelection, DependencyObject selection)
      {
         SelectedElement = selection;
         if (m_clearSelection != null)
         {
            m_clearSelection ();
         }
         m_clearSelection = clearSelection;
      }
   }

   public partial class BaseSlideControl : Control
   {
      protected BaseSlideControl ()
      {
         Dimension = new Size (1280, 1024);
      }
   }

}
