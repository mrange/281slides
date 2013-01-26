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
using System.Windows.Media;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Model
{
   public partial class Presentation
   {
      partial void OnChange_IsShowingNotes (bool oldValue, bool newValue, ref bool handled)
      {
         NotesVisibility = newValue ? Visibility.Visible : Visibility.Collapsed;
      }
   }

   // TODO: I mix the concepts of ViewModel and Model
   // This makes initial development a bit more straightforward 
   // (as I don't have to duplicate state or forward data) 
   // I should seperate the view model related concepts into controls

   public partial class BaseElement
   {
      bool m_isUpdating;

      void UpdatePos (
         DependencyProperty anchorProperty,
         DependencyProperty dimensionProperty,
         DependencyProperty centerProperty,
         DependencyProperty pos0Property,
         DependencyProperty pos1Property,
         double anchor,
         double dimension,
         double center,
         double pos0,
         double pos1
         )
      {
         if (m_isUpdating)
         {
            return;
         }

         m_isUpdating = true;

         try
         {
            if (pos1 < pos0)
            {
               SetValue (anchorProperty, pos1);
               SetValue (dimensionProperty, pos0 - pos1);
               SetValue (centerProperty, pos1 + (pos0 - pos1) / 2);
            }
            else
            {
               SetValue (anchorProperty, pos0);
               SetValue (dimensionProperty, pos1 - pos0);
               SetValue (centerProperty, pos0 + (pos1 - pos0) / 2);
            }
         }
         finally
         {
            m_isUpdating = false;
         }
      }

      // TODO: Make sure update position functions take only required args

      void UpdatePos0 (
         DependencyProperty anchorProperty,
         DependencyProperty dimensionProperty,
         DependencyProperty centerProperty,
         DependencyProperty pos0Property,
         DependencyProperty pos1Property,
         double anchor,
         double dimension,
         double center,
         double pos0,
         double pos1
         )
      {
         UpdatePos (
            anchorProperty,
            dimensionProperty,
            centerProperty,
            pos0Property,
            pos1Property,
            anchor,
            dimension,
            center,
            pos0,
            pos1);
      }

      void UpdatePos1 (
         DependencyProperty anchorProperty,
         DependencyProperty dimensionProperty,
         DependencyProperty centerProperty,
         DependencyProperty pos0Property,
         DependencyProperty pos1Property,
         double anchor,
         double dimension,
         double center,
         double pos0,
         double pos1
         )
      {
         UpdatePos (
            anchorProperty,
            dimensionProperty,
            centerProperty,
            pos1Property,
            pos0Property,
            anchor,
            dimension,
            center,
            pos1,
            pos0);
      }

      void UpdateAnchor (
         DependencyProperty anchorProperty,
         DependencyProperty dimensionProperty,
         DependencyProperty centerProperty,
         DependencyProperty pos0Property,
         DependencyProperty pos1Property,
         double anchor,
         double dimension,
         double center,
         double pos0,
         double pos1
         )
      {
         if (m_isUpdating)
         {
            return;
         }

         m_isUpdating = true;

         try
         {
            var dim = Math.Max (dimension ,0);

            if (pos1 < pos0)
            {
               SetValue (pos1Property, anchor);
               SetValue (pos0Property, anchor + dim);
            }
            else
            {
               SetValue (pos0Property, anchor);
               SetValue (pos1Property, anchor + dim);
            }
            SetValue (centerProperty, anchor + dim / 2);
         }
         finally
         {
            m_isUpdating = false;
         }
      }

      void UpdateDimension (
         DependencyProperty anchorProperty,
         DependencyProperty dimensionProperty,
         DependencyProperty centerProperty,
         DependencyProperty pos0Property,
         DependencyProperty pos1Property,
         double anchor,
         double dimension,
         double center,
         double pos0,
         double pos1
         )
      {
         if (m_isUpdating)
         {
            return;
         }

         m_isUpdating = true;

         try
         {
            var dim = Math.Max (dimension ,0);

            if (pos1 < pos0)
            {
               SetValue (pos0Property, dim + pos1);
            }
            else
            {
               SetValue (pos1Property, dim + pos0);
            }
            SetValue (centerProperty, anchor + dim / 2);
         }
         finally
         {
            m_isUpdating = false;
         }
      }

      void UpdateCenter (
         DependencyProperty anchorProperty,
         DependencyProperty dimensionProperty,
         DependencyProperty centerProperty,
         DependencyProperty pos0Property,
         DependencyProperty pos1Property,
         double anchor,
         double dimension,
         double center,
         double pos0,
         double pos1
         )
      {
         if (m_isUpdating)
         {
            return;
         }

         m_isUpdating = true;

         try
         {
            var minPos = center - dimension / 2;
            var maxPos = center + dimension / 2;
            SetValue (anchorProperty, minPos);

            if (pos1 < pos0)
            {
               SetValue (pos1Property, minPos);
               SetValue (pos0Property, maxPos);
            }
            else
            {
               SetValue (pos0Property, minPos);
               SetValue (pos1Property, maxPos);
            }
         }
         finally
         {
            m_isUpdating = false;
         }
      }

      partial void OnChange_OpacityPercent (int oldValue, int newValue, ref bool handled)
      {
         Opacity = newValue.Clamp (0, 100) / 100.0;
      }

      partial void OnChange_X0 (double oldValue, double newValue, ref bool handled)
      {
         UpdatePos0 (
            LeftProperty,
            WidthProperty,
            CenterXProperty,
            X0Property,
            X1Property,
            Left,
            Width,
            CenterX,
            X0,
            X1
            );
         handled = true;
      }
      partial void OnChange_Y0 (double oldValue, double newValue, ref bool handled)
      {
         UpdatePos0 (
            TopProperty,
            HeightProperty,
            CenterYProperty,
            Y0Property,
            Y1Property,
            Top,
            Height,
            CenterY,
            Y0,
            Y1
            );
         handled = true;
      }
      partial void OnChange_X1 (double oldValue, double newValue, ref bool handled)
      {
         UpdatePos1 (
            LeftProperty,
            WidthProperty,
            CenterXProperty,
            X0Property,
            X1Property,
            Left,
            Width,
            CenterX,
            X0,
            X1
            );
         handled = true;
      }
      partial void OnChange_Y1 (double oldValue, double newValue, ref bool handled)
      {
         UpdatePos1 (
            TopProperty,
            HeightProperty,
            CenterYProperty,
            Y0Property,
            Y1Property,
            Top,
            Height,
            CenterY,
            Y0,
            Y1
            );
         handled = true;
      }

      partial void OnChange_Left (double oldValue, double newValue, ref bool handled)
      {
         UpdateAnchor (
            LeftProperty,
            WidthProperty,
            CenterXProperty,
            X0Property,
            X1Property,
            Left,
            Width,
            CenterX,
            X0,
            X1
            );
         UpdateTransform ();
         handled = true;
      }

      partial void OnChange_Top (double oldValue, double newValue, ref bool handled)
      {
         UpdateAnchor (
            TopProperty,
            HeightProperty,
            CenterYProperty,
            Y0Property,
            Y1Property,
            Top,
            Height,
            CenterY,
            Y0,
            Y1
            );
         UpdateTransform ();
         handled = true;
      }

      partial void OnChange_Width (double oldValue, double newValue, ref bool handled)
      {
         UpdateDimension (
            LeftProperty,
            WidthProperty,
            CenterXProperty,
            X0Property,
            X1Property,
            Left,
            Width,
            CenterX,
            X0,
            X1
            );
         handled = true;
      }
      partial void OnChange_Height (double oldValue, double newValue, ref bool handled)
      {
         UpdateDimension (
            TopProperty,
            HeightProperty,
            CenterYProperty,
            Y0Property,
            Y1Property,
            Top,
            Height,
            CenterY,
            Y0,
            Y1
            );
         handled = true;
      }

      partial void OnChange_CenterX (double oldValue, double newValue, ref bool handled)
      {
         UpdateCenter (
            LeftProperty,
            WidthProperty,
            CenterXProperty,
            X0Property,
            X1Property,
            Left,
            Width,
            CenterX,
            X0,
            X1
            );
         handled = true;
      }

      partial void OnChange_CenterY (double oldValue, double newValue, ref bool handled)
      {
         UpdateCenter (
            TopProperty,
            HeightProperty,
            CenterYProperty,
            Y0Property,
            Y1Property,
            Top,
            Height,
            CenterY,
            Y0,
            Y1
            );
         handled = true;
      }

      partial void OnChange_Angle (double oldValue, double newValue, ref bool handled)
      {
         UpdateTransform ();
      }

      void UpdateTransform ()
      {
         ElementTransform = new RotateTransform
            {
               Angle = Angle,
               CenterX = Left,
               CenterY = Top,
            };
      }

   }

   public partial class TextElement
   {
      partial void OnChange_FontName (string oldValue, string newValue, ref bool handled)
      {
         if (newValue.IsNullOrEmpty ())
         {
            FontFamily = new FontFamily (@"Verdana");
         }
         else
         {
            FontFamily = new FontFamily (newValue);
         }
         handled = true;
      }

      partial void OnChange_BackgroundColor (Color oldValue, Color newValue, ref bool handled)
      {
         BackgroundBrush = new SolidColorBrush (newValue);
         handled = true;
      }

      partial void OnChange_ForegroundColor (Color oldValue, Color newValue, ref bool handled)
      {
         ForegroundBrush = new SolidColorBrush (newValue);
         handled = true;
      }
   }

   public partial class ShapeElement
   {
      partial void OnChange_BackgroundColor (Color oldValue, Color newValue, ref bool handled)
      {
         BackgroundBrush = new SolidColorBrush (newValue);
         handled = true;
      }

      partial void OnChange_ForegroundColor (Color oldValue, Color newValue, ref bool handled)
      {
         ForegroundBrush = new SolidColorBrush (newValue);
         handled = true;
      }
   }

   public partial class PictureElement : IPicture
   {
      partial void OnChange_PictureSource (string oldValue, string newValue, ref bool handled)
      {
         this.ChangePictureSource (oldValue, newValue);
         handled = true;
      }

      partial void OnChange_Source (ImageSource oldValue, ImageSource newValue, ref bool handled)
      {
         this.ChangeSource (oldValue, newValue);
         handled = true;
      }
   }

}
