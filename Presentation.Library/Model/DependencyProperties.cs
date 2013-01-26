using System;
using System.Windows.Media.Imaging;
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

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable HeuristicUnreachableCode
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast
// ReSharper disable RedundantIfElseBlock

namespace Presentation.Library.Model
{
// ReSharper disable RedundantUsingDirective
   using global::Presentation.Library.Utility;
   using System.Collections.ObjectModel;
   using System.Diagnostics;
   using System.Windows.Media;
   using System.Windows;
// ReSharper restore RedundantUsingDirective

   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class Presentation
   {
      #region Dependency Properties for Presentation
      public static readonly DependencyProperty NotesVisibilityProperty = 
         DependencyProperty.Register (
               "NotesVisibility"
            ,  typeof (Visibility)
            ,  typeof (Presentation)            
            ,  new PropertyMetadata (
                  Visibility.Collapsed
               ,  OnChange_NotesVisibility
               )
            );

      static void OnChange_NotesVisibility (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:NotesVisibility, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as Presentation;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Visibility)e.OldValue;
         var newValue = (Visibility)e.NewValue;
         var handled = false;
         dobj.OnChange_NotesVisibility (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Visibility NotesVisibility
      {
         get
         {
            return (Visibility) GetValue (NotesVisibilityProperty);
         }
         set
         {
            var currentValue = NotesVisibility;

            if (currentValue != value)
            {
               SetValue (NotesVisibilityProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_NotesVisibility (Visibility oldValue, Visibility newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class Slide
   {
      #region Dependency Properties for Slide
      public static readonly DependencyProperty CurrentElementProperty = 
         DependencyProperty.Register (
               "CurrentElement"
            ,  typeof (BaseElement)
            ,  typeof (Slide)            
            ,  new PropertyMetadata (
                  default (BaseElement)
               ,  OnChange_CurrentElement
               )
            );

      static void OnChange_CurrentElement (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:CurrentElement, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as Slide;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (BaseElement)e.OldValue;
         var newValue = (BaseElement)e.NewValue;
         var handled = false;
         dobj.OnChange_CurrentElement (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public BaseElement CurrentElement
      {
         get
         {
            return (BaseElement) GetValue (CurrentElementProperty);
         }
         set
         {
            var currentValue = CurrentElement;

            if (currentValue != value)
            {
               SetValue (CurrentElementProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_CurrentElement (BaseElement oldValue, BaseElement newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public abstract partial class BaseElement
   {
      #region Dependency Properties for BaseElement
      public static readonly DependencyProperty OpacityProperty = 
         DependencyProperty.Register (
               "Opacity"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  1.0
               ,  OnChange_Opacity
               )
            );

      static void OnChange_Opacity (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Opacity, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         dobj.OnChange_Opacity (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty X0Property = 
         DependencyProperty.Register (
               "X0"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_X0
               )
            );

      static void OnChange_X0 (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:X0, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         dobj.OnChange_X0 (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty Y0Property = 
         DependencyProperty.Register (
               "Y0"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_Y0
               )
            );

      static void OnChange_Y0 (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Y0, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         dobj.OnChange_Y0 (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty X1Property = 
         DependencyProperty.Register (
               "X1"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_X1
               )
            );

      static void OnChange_X1 (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:X1, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         dobj.OnChange_X1 (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty Y1Property = 
         DependencyProperty.Register (
               "Y1"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_Y1
               )
            );

      static void OnChange_Y1 (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Y1, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         dobj.OnChange_Y1 (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty CenterXProperty = 
         DependencyProperty.Register (
               "CenterX"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_CenterX
               )
            );

      static void OnChange_CenterX (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:CenterX, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         dobj.OnChange_CenterX (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty CenterYProperty = 
         DependencyProperty.Register (
               "CenterY"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_CenterY
               )
            );

      static void OnChange_CenterY (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:CenterY, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         dobj.OnChange_CenterY (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty ElementTransformProperty = 
         DependencyProperty.Register (
               "ElementTransform"
            ,  typeof (Transform)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (Transform)
               ,  OnChange_ElementTransform
               )
            );

      static void OnChange_ElementTransform (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ElementTransform, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Transform)e.OldValue;
         var newValue = (Transform)e.NewValue;
         var handled = false;
         dobj.OnChange_ElementTransform (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double Opacity
      {
         get
         {
            return (double) GetValue (OpacityProperty);
         }
         set
         {
            var currentValue = Opacity;

            if (currentValue != value)
            {
               SetValue (OpacityProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Opacity (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double X0
      {
         get
         {
            return (double) GetValue (X0Property);
         }
         set
         {
            var currentValue = X0;

            if (currentValue != value)
            {
               SetValue (X0Property, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_X0 (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double Y0
      {
         get
         {
            return (double) GetValue (Y0Property);
         }
         set
         {
            var currentValue = Y0;

            if (currentValue != value)
            {
               SetValue (Y0Property, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Y0 (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double X1
      {
         get
         {
            return (double) GetValue (X1Property);
         }
         set
         {
            var currentValue = X1;

            if (currentValue != value)
            {
               SetValue (X1Property, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_X1 (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double Y1
      {
         get
         {
            return (double) GetValue (Y1Property);
         }
         set
         {
            var currentValue = Y1;

            if (currentValue != value)
            {
               SetValue (Y1Property, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Y1 (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double CenterX
      {
         get
         {
            return (double) GetValue (CenterXProperty);
         }
         set
         {
            var currentValue = CenterX;

            if (currentValue != value)
            {
               SetValue (CenterXProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_CenterX (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double CenterY
      {
         get
         {
            return (double) GetValue (CenterYProperty);
         }
         set
         {
            var currentValue = CenterY;

            if (currentValue != value)
            {
               SetValue (CenterYProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_CenterY (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Transform ElementTransform
      {
         get
         {
            return (Transform) GetValue (ElementTransformProperty);
         }
         set
         {
            var currentValue = ElementTransform;

            if (currentValue != value)
            {
               SetValue (ElementTransformProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_ElementTransform (Transform oldValue, Transform newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class TextElement
   {
      #region Dependency Properties for TextElement
      public static readonly DependencyProperty FontFamilyProperty = 
         DependencyProperty.Register (
               "FontFamily"
            ,  typeof (FontFamily)
            ,  typeof (TextElement)            
            ,  new PropertyMetadata (
                  new FontFamily ("Verdana")
               ,  OnChange_FontFamily
               )
            );

      static void OnChange_FontFamily (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:FontFamily, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as TextElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (FontFamily)e.OldValue;
         var newValue = (FontFamily)e.NewValue;
         var handled = false;
         dobj.OnChange_FontFamily (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty ForegroundBrushProperty = 
         DependencyProperty.Register (
               "ForegroundBrush"
            ,  typeof (Brush)
            ,  typeof (TextElement)            
            ,  new PropertyMetadata (
                  new SolidColorBrush (Colors.White)
               ,  OnChange_ForegroundBrush
               )
            );

      static void OnChange_ForegroundBrush (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ForegroundBrush, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as TextElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Brush)e.OldValue;
         var newValue = (Brush)e.NewValue;
         var handled = false;
         dobj.OnChange_ForegroundBrush (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty BackgroundBrushProperty = 
         DependencyProperty.Register (
               "BackgroundBrush"
            ,  typeof (Brush)
            ,  typeof (TextElement)            
            ,  new PropertyMetadata (
                  default (Brush)
               ,  OnChange_BackgroundBrush
               )
            );

      static void OnChange_BackgroundBrush (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:BackgroundBrush, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as TextElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Brush)e.OldValue;
         var newValue = (Brush)e.NewValue;
         var handled = false;
         dobj.OnChange_BackgroundBrush (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public FontFamily FontFamily
      {
         get
         {
            return (FontFamily) GetValue (FontFamilyProperty);
         }
         set
         {
            var currentValue = FontFamily;

            if (currentValue != value)
            {
               SetValue (FontFamilyProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_FontFamily (FontFamily oldValue, FontFamily newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Brush ForegroundBrush
      {
         get
         {
            return (Brush) GetValue (ForegroundBrushProperty);
         }
         set
         {
            var currentValue = ForegroundBrush;

            if (currentValue != value)
            {
               SetValue (ForegroundBrushProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_ForegroundBrush (Brush oldValue, Brush newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Brush BackgroundBrush
      {
         get
         {
            return (Brush) GetValue (BackgroundBrushProperty);
         }
         set
         {
            var currentValue = BackgroundBrush;

            if (currentValue != value)
            {
               SetValue (BackgroundBrushProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_BackgroundBrush (Brush oldValue, Brush newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class ShapeElement
   {
      #region Dependency Properties for ShapeElement
      public static readonly DependencyProperty ForegroundBrushProperty = 
         DependencyProperty.Register (
               "ForegroundBrush"
            ,  typeof (Brush)
            ,  typeof (ShapeElement)            
            ,  new PropertyMetadata (
                  new SolidColorBrush (Colors.White)
               ,  OnChange_ForegroundBrush
               )
            );

      static void OnChange_ForegroundBrush (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ForegroundBrush, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as ShapeElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Brush)e.OldValue;
         var newValue = (Brush)e.NewValue;
         var handled = false;
         dobj.OnChange_ForegroundBrush (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty BackgroundBrushProperty = 
         DependencyProperty.Register (
               "BackgroundBrush"
            ,  typeof (Brush)
            ,  typeof (ShapeElement)            
            ,  new PropertyMetadata (
                  default (Brush)
               ,  OnChange_BackgroundBrush
               )
            );

      static void OnChange_BackgroundBrush (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:BackgroundBrush, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as ShapeElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Brush)e.OldValue;
         var newValue = (Brush)e.NewValue;
         var handled = false;
         dobj.OnChange_BackgroundBrush (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Brush ForegroundBrush
      {
         get
         {
            return (Brush) GetValue (ForegroundBrushProperty);
         }
         set
         {
            var currentValue = ForegroundBrush;

            if (currentValue != value)
            {
               SetValue (ForegroundBrushProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_ForegroundBrush (Brush oldValue, Brush newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Brush BackgroundBrush
      {
         get
         {
            return (Brush) GetValue (BackgroundBrushProperty);
         }
         set
         {
            var currentValue = BackgroundBrush;

            if (currentValue != value)
            {
               SetValue (BackgroundBrushProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_BackgroundBrush (Brush oldValue, Brush newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class PictureElement
   {
      #region Dependency Properties for PictureElement
      public static readonly DependencyProperty SourceProperty = 
         DependencyProperty.Register (
               "Source"
            ,  typeof (ImageSource)
            ,  typeof (PictureElement)            
            ,  new PropertyMetadata (
                  default (ImageSource)
               ,  OnChange_Source
               )
            );

      static void OnChange_Source (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Source, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PictureElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ImageSource)e.OldValue;
         var newValue = (ImageSource)e.NewValue;
         var handled = false;
         dobj.OnChange_Source (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty DownloadProgressVisibilityProperty = 
         DependencyProperty.Register (
               "DownloadProgressVisibility"
            ,  typeof (Visibility)
            ,  typeof (PictureElement)            
            ,  new PropertyMetadata (
                  Visibility.Collapsed
               ,  OnChange_DownloadProgressVisibility
               )
            );

      static void OnChange_DownloadProgressVisibility (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:DownloadProgressVisibility, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PictureElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Visibility)e.OldValue;
         var newValue = (Visibility)e.NewValue;
         var handled = false;
         dobj.OnChange_DownloadProgressVisibility (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty DownloadProgressValueProperty = 
         DependencyProperty.Register (
               "DownloadProgressValue"
            ,  typeof (int)
            ,  typeof (PictureElement)            
            ,  new PropertyMetadata (
                  default (int)
               ,  OnChange_DownloadProgressValue
               )
            );

      static void OnChange_DownloadProgressValue (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:DownloadProgressValue, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PictureElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (int)e.OldValue;
         var newValue = (int)e.NewValue;
         var handled = false;
         dobj.OnChange_DownloadProgressValue (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ImageSource Source
      {
         get
         {
            return (ImageSource) GetValue (SourceProperty);
         }
         set
         {
            var currentValue = Source;

            if (currentValue != value)
            {
               SetValue (SourceProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Source (ImageSource oldValue, ImageSource newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Visibility DownloadProgressVisibility
      {
         get
         {
            return (Visibility) GetValue (DownloadProgressVisibilityProperty);
         }
         set
         {
            var currentValue = DownloadProgressVisibility;

            if (currentValue != value)
            {
               SetValue (DownloadProgressVisibilityProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_DownloadProgressVisibility (Visibility oldValue, Visibility newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public int DownloadProgressValue
      {
         get
         {
            return (int) GetValue (DownloadProgressValueProperty);
         }
         set
         {
            var currentValue = DownloadProgressValue;

            if (currentValue != value)
            {
               SetValue (DownloadProgressValueProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_DownloadProgressValue (int oldValue, int newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class MovieElement
   {
      #region Dependency Properties for MovieElement
      public static readonly DependencyProperty SourceProperty = 
         DependencyProperty.Register (
               "Source"
            ,  typeof (Uri)
            ,  typeof (MovieElement)            
            ,  new PropertyMetadata (
                  default (Uri)
               ,  OnChange_Source
               )
            );

      static void OnChange_Source (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Source, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as MovieElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Uri)e.OldValue;
         var newValue = (Uri)e.NewValue;
         var handled = false;
         dobj.OnChange_Source (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Uri Source
      {
         get
         {
            return (Uri) GetValue (SourceProperty);
         }
         set
         {
            var currentValue = Source;

            if (currentValue != value)
            {
               SetValue (SourceProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Source (Uri oldValue, Uri newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public abstract partial class BaseDefinition
   {
      #region Dependency Properties for BaseDefinition
      public static readonly DependencyProperty NameProperty = 
         DependencyProperty.Register (
               "Name"
            ,  typeof (string)
            ,  typeof (BaseDefinition)            
            ,  new PropertyMetadata (
                  default (string)
               ,  OnChange_Name
               )
            );

      static void OnChange_Name (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Name, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseDefinition;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (string)e.OldValue;
         var newValue = (string)e.NewValue;
         var handled = false;
         dobj.OnChange_Name (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string Name
      {
         get
         {
            return (string) GetValue (NameProperty);
         }
         set
         {
            var currentValue = Name;

            if (currentValue != value)
            {
               SetValue (NameProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Name (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class ThemeDefinition
   {
      #region Dependency Properties for ThemeDefinition
      #endregion
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class LayoutDefinition
   {
      #region Dependency Properties for LayoutDefinition
      #endregion
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class PictureHelpers
   {
      #region Dependency Properties for PictureHelpers
      public static readonly DependencyProperty PictureProperty = 
         DependencyProperty.RegisterAttached (
               "Picture"
            ,  typeof (IPicture)
            ,  typeof (PictureHelpers)            
            ,  new PropertyMetadata (
                  default (IPicture)
               ,  OnChange_Picture
               )
            );

      static void OnChange_Picture (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Picture, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as DependencyObject;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (IPicture)e.OldValue;
         var newValue = (IPicture)e.NewValue;
         var handled = false;
         OnChange_Picture (dobj, oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static IPicture GetPicture (DependencyObject dobj)
      {
         if (dobj != null)
         {
            return (IPicture) dobj.GetValue (PictureProperty);
         }
         else
         {
            return default (IPicture);
         }
      }

      public static void SetPicture (DependencyObject dobj, IPicture value)
      {
         if (dobj != null)
         {
            dobj.SetValue (PictureProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Picture (DependencyObject dobj, IPicture oldValue, IPicture newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class PictureDefinition
   {
      #region Dependency Properties for PictureDefinition
      public static readonly DependencyProperty PictureSourceProperty = 
         DependencyProperty.Register (
               "PictureSource"
            ,  typeof (string)
            ,  typeof (PictureDefinition)            
            ,  new PropertyMetadata (
                  default (string)
               ,  OnChange_PictureSource
               )
            );

      static void OnChange_PictureSource (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:PictureSource, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PictureDefinition;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (string)e.OldValue;
         var newValue = (string)e.NewValue;
         var handled = false;
         dobj.OnChange_PictureSource (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty SourceProperty = 
         DependencyProperty.Register (
               "Source"
            ,  typeof (ImageSource)
            ,  typeof (PictureDefinition)            
            ,  new PropertyMetadata (
                  default (ImageSource)
               ,  OnChange_Source
               )
            );

      static void OnChange_Source (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Source, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PictureDefinition;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ImageSource)e.OldValue;
         var newValue = (ImageSource)e.NewValue;
         var handled = false;
         dobj.OnChange_Source (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty DownloadProgressVisibilityProperty = 
         DependencyProperty.Register (
               "DownloadProgressVisibility"
            ,  typeof (Visibility)
            ,  typeof (PictureDefinition)            
            ,  new PropertyMetadata (
                  Visibility.Collapsed
               ,  OnChange_DownloadProgressVisibility
               )
            );

      static void OnChange_DownloadProgressVisibility (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:DownloadProgressVisibility, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PictureDefinition;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Visibility)e.OldValue;
         var newValue = (Visibility)e.NewValue;
         var handled = false;
         dobj.OnChange_DownloadProgressVisibility (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty DownloadProgressValueProperty = 
         DependencyProperty.Register (
               "DownloadProgressValue"
            ,  typeof (int)
            ,  typeof (PictureDefinition)            
            ,  new PropertyMetadata (
                  default (int)
               ,  OnChange_DownloadProgressValue
               )
            );

      static void OnChange_DownloadProgressValue (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:DownloadProgressValue, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PictureDefinition;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (int)e.OldValue;
         var newValue = (int)e.NewValue;
         var handled = false;
         dobj.OnChange_DownloadProgressValue (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string PictureSource
      {
         get
         {
            return (string) GetValue (PictureSourceProperty);
         }
         set
         {
            var currentValue = PictureSource;

            if (currentValue != value)
            {
               SetValue (PictureSourceProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_PictureSource (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ImageSource Source
      {
         get
         {
            return (ImageSource) GetValue (SourceProperty);
         }
         set
         {
            var currentValue = Source;

            if (currentValue != value)
            {
               SetValue (SourceProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Source (ImageSource oldValue, ImageSource newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Visibility DownloadProgressVisibility
      {
         get
         {
            return (Visibility) GetValue (DownloadProgressVisibilityProperty);
         }
         set
         {
            var currentValue = DownloadProgressVisibility;

            if (currentValue != value)
            {
               SetValue (DownloadProgressVisibilityProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_DownloadProgressVisibility (Visibility oldValue, Visibility newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public int DownloadProgressValue
      {
         get
         {
            return (int) GetValue (DownloadProgressValueProperty);
         }
         set
         {
            var currentValue = DownloadProgressValue;

            if (currentValue != value)
            {
               SetValue (DownloadProgressValueProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_DownloadProgressValue (int oldValue, int newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class MovieDefinition
   {
      #region Dependency Properties for MovieDefinition
      public static readonly DependencyProperty SourceProperty = 
         DependencyProperty.Register (
               "Source"
            ,  typeof (string)
            ,  typeof (MovieDefinition)            
            ,  new PropertyMetadata (
                  default (string)
               ,  OnChange_Source
               )
            );

      static void OnChange_Source (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Source, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as MovieDefinition;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (string)e.OldValue;
         var newValue = (string)e.NewValue;
         var handled = false;
         dobj.OnChange_Source (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string Source
      {
         get
         {
            return (string) GetValue (SourceProperty);
         }
         set
         {
            var currentValue = Source;

            if (currentValue != value)
            {
               SetValue (SourceProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Source (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class ShapeDefinition
   {
      #region Dependency Properties for ShapeDefinition
      public static readonly DependencyProperty PathProperty = 
         DependencyProperty.Register (
               "Path"
            ,  typeof (string)
            ,  typeof (ShapeDefinition)            
            ,  new PropertyMetadata (
                  default (string)
               ,  OnChange_Path
               )
            );

      static void OnChange_Path (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Path, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as ShapeDefinition;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (string)e.OldValue;
         var newValue = (string)e.NewValue;
         var handled = false;
         dobj.OnChange_Path (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string Path
      {
         get
         {
            return (string) GetValue (PathProperty);
         }
         set
         {
            var currentValue = Path;

            if (currentValue != value)
            {
               SetValue (PathProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Path (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
}

// ReSharper restore PartialMethodWithSinglePart
// ReSharper restore RedundantAssignment
// ReSharper restore PartialTypeWithSinglePart
// ReSharper restore ConditionIsAlwaysTrueOrFalse
// ReSharper restore HeuristicUnreachableCode


