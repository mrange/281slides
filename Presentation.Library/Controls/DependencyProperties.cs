using System;
using System.Windows.Controls;
using Presentation.Library.Model;
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

namespace Presentation.Library.Controls
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
   public  partial class PresentationControl
   {
      #region Dependency Properties for PresentationControl
      public static readonly DependencyProperty PresentationProperty = 
         DependencyProperty.Register (
               "Presentation"
            ,  typeof (Model.Presentation)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  default (Model.Presentation)
               ,  OnChange_Presentation
               )
            );

      static void OnChange_Presentation (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Presentation, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Model.Presentation)e.OldValue;
         var newValue = (Model.Presentation)e.NewValue;
         var handled = false;
         dobj.OnChange_Presentation (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty ThemesProperty = 
         DependencyProperty.Register (
               "Themes"
            ,  typeof (ObservableCollection<ThemeDefinition>)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_Themes
               )
            );

      static void OnChange_Themes (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Themes, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ObservableCollection<ThemeDefinition>)e.OldValue;
         var newValue = (ObservableCollection<ThemeDefinition>)e.NewValue;
         var handled = false;
         dobj.OnChange_Themes (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty LayoutsProperty = 
         DependencyProperty.Register (
               "Layouts"
            ,  typeof (ObservableCollection<LayoutDefinition>)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_Layouts
               )
            );

      static void OnChange_Layouts (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Layouts, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ObservableCollection<LayoutDefinition>)e.OldValue;
         var newValue = (ObservableCollection<LayoutDefinition>)e.NewValue;
         var handled = false;
         dobj.OnChange_Layouts (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty PicturesProperty = 
         DependencyProperty.Register (
               "Pictures"
            ,  typeof (ObservableCollection<PictureDefinition>)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_Pictures
               )
            );

      static void OnChange_Pictures (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Pictures, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ObservableCollection<PictureDefinition>)e.OldValue;
         var newValue = (ObservableCollection<PictureDefinition>)e.NewValue;
         var handled = false;
         dobj.OnChange_Pictures (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty MoviesProperty = 
         DependencyProperty.Register (
               "Movies"
            ,  typeof (ObservableCollection<MovieDefinition>)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_Movies
               )
            );

      static void OnChange_Movies (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Movies, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ObservableCollection<MovieDefinition>)e.OldValue;
         var newValue = (ObservableCollection<MovieDefinition>)e.NewValue;
         var handled = false;
         dobj.OnChange_Movies (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty ShapesProperty = 
         DependencyProperty.Register (
               "Shapes"
            ,  typeof (ObservableCollection<ShapeDefinition>)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_Shapes
               )
            );

      static void OnChange_Shapes (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Shapes, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ObservableCollection<ShapeDefinition>)e.OldValue;
         var newValue = (ObservableCollection<ShapeDefinition>)e.NewValue;
         var handled = false;
         dobj.OnChange_Shapes (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty FontNamesProperty = 
         DependencyProperty.Register (
               "FontNames"
            ,  typeof (ObservableCollection<string>)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_FontNames
               )
            );

      static void OnChange_FontNames (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:FontNames, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ObservableCollection<string>)e.OldValue;
         var newValue = (ObservableCollection<string>)e.NewValue;
         var handled = false;
         dobj.OnChange_FontNames (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty FontSizesProperty = 
         DependencyProperty.Register (
               "FontSizes"
            ,  typeof (ObservableCollection<double>)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_FontSizes
               )
            );

      static void OnChange_FontSizes (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:FontSizes, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ObservableCollection<double>)e.OldValue;
         var newValue = (ObservableCollection<double>)e.NewValue;
         var handled = false;
         dobj.OnChange_FontSizes (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty PictureTemplateProperty = 
         DependencyProperty.Register (
               "PictureTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_PictureTemplate
               )
            );

      static void OnChange_PictureTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:PictureTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_PictureTemplate (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty MovieTemplateProperty = 
         DependencyProperty.Register (
               "MovieTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_MovieTemplate
               )
            );

      static void OnChange_MovieTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:MovieTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_MovieTemplate (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty ShapeTemplateProperty = 
         DependencyProperty.Register (
               "ShapeTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (PresentationControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_ShapeTemplate
               )
            );

      static void OnChange_ShapeTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ShapeTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentationControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_ShapeTemplate (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Model.Presentation Presentation
      {
         get
         {
            return (Model.Presentation) GetValue (PresentationProperty);
         }
         set
         {
            var currentValue = Presentation;

            if (currentValue != value)
            {
               SetValue (PresentationProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Presentation (Model.Presentation oldValue, Model.Presentation newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<ThemeDefinition> Themes
      {
         get
         {
            return (ObservableCollection<ThemeDefinition>) GetValue (ThemesProperty);
         }
         set
         {
            var currentValue = Themes;

            if (currentValue != value)
            {
               SetValue (ThemesProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Themes (ObservableCollection<ThemeDefinition> oldValue, ObservableCollection<ThemeDefinition> newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<LayoutDefinition> Layouts
      {
         get
         {
            return (ObservableCollection<LayoutDefinition>) GetValue (LayoutsProperty);
         }
         set
         {
            var currentValue = Layouts;

            if (currentValue != value)
            {
               SetValue (LayoutsProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Layouts (ObservableCollection<LayoutDefinition> oldValue, ObservableCollection<LayoutDefinition> newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<PictureDefinition> Pictures
      {
         get
         {
            return (ObservableCollection<PictureDefinition>) GetValue (PicturesProperty);
         }
         set
         {
            var currentValue = Pictures;

            if (currentValue != value)
            {
               SetValue (PicturesProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Pictures (ObservableCollection<PictureDefinition> oldValue, ObservableCollection<PictureDefinition> newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<MovieDefinition> Movies
      {
         get
         {
            return (ObservableCollection<MovieDefinition>) GetValue (MoviesProperty);
         }
         set
         {
            var currentValue = Movies;

            if (currentValue != value)
            {
               SetValue (MoviesProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Movies (ObservableCollection<MovieDefinition> oldValue, ObservableCollection<MovieDefinition> newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<ShapeDefinition> Shapes
      {
         get
         {
            return (ObservableCollection<ShapeDefinition>) GetValue (ShapesProperty);
         }
         set
         {
            var currentValue = Shapes;

            if (currentValue != value)
            {
               SetValue (ShapesProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Shapes (ObservableCollection<ShapeDefinition> oldValue, ObservableCollection<ShapeDefinition> newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<string> FontNames
      {
         get
         {
            return (ObservableCollection<string>) GetValue (FontNamesProperty);
         }
         set
         {
            var currentValue = FontNames;

            if (currentValue != value)
            {
               SetValue (FontNamesProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_FontNames (ObservableCollection<string> oldValue, ObservableCollection<string> newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<double> FontSizes
      {
         get
         {
            return (ObservableCollection<double>) GetValue (FontSizesProperty);
         }
         set
         {
            var currentValue = FontSizes;

            if (currentValue != value)
            {
               SetValue (FontSizesProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_FontSizes (ObservableCollection<double> oldValue, ObservableCollection<double> newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate PictureTemplate
      {
         get
         {
            return (DataTemplate) GetValue (PictureTemplateProperty);
         }
         set
         {
            var currentValue = PictureTemplate;

            if (currentValue != value)
            {
               SetValue (PictureTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_PictureTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate MovieTemplate
      {
         get
         {
            return (DataTemplate) GetValue (MovieTemplateProperty);
         }
         set
         {
            var currentValue = MovieTemplate;

            if (currentValue != value)
            {
               SetValue (MovieTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_MovieTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate ShapeTemplate
      {
         get
         {
            return (DataTemplate) GetValue (ShapeTemplateProperty);
         }
         set
         {
            var currentValue = ShapeTemplate;

            if (currentValue != value)
            {
               SetValue (ShapeTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_ShapeTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class PresentControl
   {
      #region Dependency Properties for PresentControl
      public static readonly DependencyProperty PresentationProperty = 
         DependencyProperty.Register (
               "Presentation"
            ,  typeof (Model.Presentation)
            ,  typeof (PresentControl)            
            ,  new PropertyMetadata (
                  default (Model.Presentation)
               ,  OnChange_Presentation
               )
            );

      static void OnChange_Presentation (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Presentation, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Model.Presentation)e.OldValue;
         var newValue = (Model.Presentation)e.NewValue;
         var handled = false;
         dobj.OnChange_Presentation (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty CurrentSlideProperty = 
         DependencyProperty.Register (
               "CurrentSlide"
            ,  typeof (Slide)
            ,  typeof (PresentControl)            
            ,  new PropertyMetadata (
                  default (Slide)
               ,  OnChange_CurrentSlide
               )
            );

      static void OnChange_CurrentSlide (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:CurrentSlide, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Slide)e.OldValue;
         var newValue = (Slide)e.NewValue;
         var handled = false;
         dobj.OnChange_CurrentSlide (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty FirstSlideProperty = 
         DependencyProperty.Register (
               "FirstSlide"
            ,  typeof (Slide)
            ,  typeof (PresentControl)            
            ,  new PropertyMetadata (
                  default (Slide)
               ,  OnChange_FirstSlide
               )
            );

      static void OnChange_FirstSlide (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:FirstSlide, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Slide)e.OldValue;
         var newValue = (Slide)e.NewValue;
         var handled = false;
         dobj.OnChange_FirstSlide (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty SecondSlideProperty = 
         DependencyProperty.Register (
               "SecondSlide"
            ,  typeof (Slide)
            ,  typeof (PresentControl)            
            ,  new PropertyMetadata (
                  default (Slide)
               ,  OnChange_SecondSlide
               )
            );

      static void OnChange_SecondSlide (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SecondSlide, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as PresentControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Slide)e.OldValue;
         var newValue = (Slide)e.NewValue;
         var handled = false;
         dobj.OnChange_SecondSlide (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Model.Presentation Presentation
      {
         get
         {
            return (Model.Presentation) GetValue (PresentationProperty);
         }
         set
         {
            var currentValue = Presentation;

            if (currentValue != value)
            {
               SetValue (PresentationProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Presentation (Model.Presentation oldValue, Model.Presentation newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Slide CurrentSlide
      {
         get
         {
            return (Slide) GetValue (CurrentSlideProperty);
         }
         set
         {
            var currentValue = CurrentSlide;

            if (currentValue != value)
            {
               SetValue (CurrentSlideProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_CurrentSlide (Slide oldValue, Slide newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Slide FirstSlide
      {
         get
         {
            return (Slide) GetValue (FirstSlideProperty);
         }
         set
         {
            var currentValue = FirstSlide;

            if (currentValue != value)
            {
               SetValue (FirstSlideProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_FirstSlide (Slide oldValue, Slide newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Slide SecondSlide
      {
         get
         {
            return (Slide) GetValue (SecondSlideProperty);
         }
         set
         {
            var currentValue = SecondSlide;

            if (currentValue != value)
            {
               SetValue (SecondSlideProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SecondSlide (Slide oldValue, Slide newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public abstract partial class BaseSlideControl
   {
      #region Dependency Properties for BaseSlideControl
      public static readonly DependencyProperty SlideProperty = 
         DependencyProperty.Register (
               "Slide"
            ,  typeof (Slide)
            ,  typeof (BaseSlideControl)            
            ,  new PropertyMetadata (
                  default (Slide)
               ,  OnChange_Slide
               )
            );

      static void OnChange_Slide (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Slide, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseSlideControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Slide)e.OldValue;
         var newValue = (Slide)e.NewValue;
         var handled = false;
         dobj.OnChange_Slide (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty DimensionProperty = 
         DependencyProperty.Register (
               "Dimension"
            ,  typeof (Size)
            ,  typeof (BaseSlideControl)            
            ,  new PropertyMetadata (
                  default (Size)
               ,  OnChange_Dimension
               )
            );

      static void OnChange_Dimension (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Dimension, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseSlideControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Size)e.OldValue;
         var newValue = (Size)e.NewValue;
         var handled = false;
         dobj.OnChange_Dimension (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Slide Slide
      {
         get
         {
            return (Slide) GetValue (SlideProperty);
         }
         set
         {
            var currentValue = Slide;

            if (currentValue != value)
            {
               SetValue (SlideProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Slide (Slide oldValue, Slide newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Size Dimension
      {
         get
         {
            return (Size) GetValue (DimensionProperty);
         }
         set
         {
            var currentValue = Dimension;

            if (currentValue != value)
            {
               SetValue (DimensionProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Dimension (Size oldValue, Size newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class EditingSlideControl
   {
      #region Dependency Properties for EditingSlideControl
      public static readonly DependencyProperty SelectedElementProperty = 
         DependencyProperty.Register (
               "SelectedElement"
            ,  typeof (DependencyObject)
            ,  typeof (EditingSlideControl)            
            ,  new PropertyMetadata (
                  default (DependencyObject)
               ,  OnChange_SelectedElement
               )
            );

      static void OnChange_SelectedElement (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SelectedElement, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as EditingSlideControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DependencyObject)e.OldValue;
         var newValue = (DependencyObject)e.NewValue;
         var handled = false;
         dobj.OnChange_SelectedElement (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DependencyObject SelectedElement
      {
         get
         {
            return (DependencyObject) GetValue (SelectedElementProperty);
         }
         set
         {
            var currentValue = SelectedElement;

            if (currentValue != value)
            {
               SetValue (SelectedElementProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SelectedElement (DependencyObject oldValue, DependencyObject newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public abstract partial class BaseElementControl
   {
      #region Dependency Properties for BaseElementControl
      public static readonly DependencyProperty ElementProperty = 
         DependencyProperty.Register (
               "Element"
            ,  typeof (BaseElement)
            ,  typeof (BaseElementControl)            
            ,  new PropertyMetadata (
                  default (BaseElement)
               ,  OnChange_Element
               )
            );

      static void OnChange_Element (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Element, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElementControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (BaseElement)e.OldValue;
         var newValue = (BaseElement)e.NewValue;
         var handled = false;
         dobj.OnChange_Element (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty ElementTemplateProperty = 
         DependencyProperty.Register (
               "ElementTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (BaseElementControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_ElementTemplate
               )
            );

      static void OnChange_ElementTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ElementTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElementControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_ElementTemplate (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty DefaultElementTemplateProperty = 
         DependencyProperty.Register (
               "DefaultElementTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (BaseElementControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_DefaultElementTemplate
               )
            );

      static void OnChange_DefaultElementTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:DefaultElementTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElementControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_DefaultElementTemplate (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty TextElementTemplateProperty = 
         DependencyProperty.Register (
               "TextElementTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (BaseElementControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_TextElementTemplate
               )
            );

      static void OnChange_TextElementTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:TextElementTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElementControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_TextElementTemplate (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty ShapeElementTemplateProperty = 
         DependencyProperty.Register (
               "ShapeElementTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (BaseElementControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_ShapeElementTemplate
               )
            );

      static void OnChange_ShapeElementTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ShapeElementTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElementControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_ShapeElementTemplate (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty PictureElementTemplateProperty = 
         DependencyProperty.Register (
               "PictureElementTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (BaseElementControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_PictureElementTemplate
               )
            );

      static void OnChange_PictureElementTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:PictureElementTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElementControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_PictureElementTemplate (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty MovieElementTemplateProperty = 
         DependencyProperty.Register (
               "MovieElementTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (BaseElementControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_MovieElementTemplate
               )
            );

      static void OnChange_MovieElementTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:MovieElementTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseElementControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_MovieElementTemplate (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public BaseElement Element
      {
         get
         {
            return (BaseElement) GetValue (ElementProperty);
         }
         set
         {
            var currentValue = Element;

            if (currentValue != value)
            {
               SetValue (ElementProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Element (BaseElement oldValue, BaseElement newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate ElementTemplate
      {
         get
         {
            return (DataTemplate) GetValue (ElementTemplateProperty);
         }
         set
         {
            var currentValue = ElementTemplate;

            if (currentValue != value)
            {
               SetValue (ElementTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_ElementTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate DefaultElementTemplate
      {
         get
         {
            return (DataTemplate) GetValue (DefaultElementTemplateProperty);
         }
         set
         {
            var currentValue = DefaultElementTemplate;

            if (currentValue != value)
            {
               SetValue (DefaultElementTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_DefaultElementTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate TextElementTemplate
      {
         get
         {
            return (DataTemplate) GetValue (TextElementTemplateProperty);
         }
         set
         {
            var currentValue = TextElementTemplate;

            if (currentValue != value)
            {
               SetValue (TextElementTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_TextElementTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate ShapeElementTemplate
      {
         get
         {
            return (DataTemplate) GetValue (ShapeElementTemplateProperty);
         }
         set
         {
            var currentValue = ShapeElementTemplate;

            if (currentValue != value)
            {
               SetValue (ShapeElementTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_ShapeElementTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate PictureElementTemplate
      {
         get
         {
            return (DataTemplate) GetValue (PictureElementTemplateProperty);
         }
         set
         {
            var currentValue = PictureElementTemplate;

            if (currentValue != value)
            {
               SetValue (PictureElementTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_PictureElementTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate MovieElementTemplate
      {
         get
         {
            return (DataTemplate) GetValue (MovieElementTemplateProperty);
         }
         set
         {
            var currentValue = MovieElementTemplate;

            if (currentValue != value)
            {
               SetValue (MovieElementTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_MovieElementTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public abstract partial class BasePanel
   {
      #region Dependency Properties for BasePanel
      public static readonly DependencyProperty UIElementStateProperty = 
         DependencyProperty.RegisterAttached (
               "UIElementState"
            ,  typeof (object)
            ,  typeof (BasePanel)            
            ,  new PropertyMetadata (
                  default (object)
               ,  OnChange_UIElementState
               )
            );

      static void OnChange_UIElementState (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:UIElementState, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as UIElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (object)e.OldValue;
         var newValue = (object)e.NewValue;
         var handled = false;
         OnChange_UIElementState (dobj, oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static object GetUIElementState (UIElement dobj)
      {
         if (dobj != null)
         {
            return (object) dobj.GetValue (UIElementStateProperty);
         }
         else
         {
            return default (object);
         }
      }

      public static void SetUIElementState (UIElement dobj, object value)
      {
         if (dobj != null)
         {
            dobj.SetValue (UIElementStateProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_UIElementState (UIElement dobj, object oldValue, object newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public abstract partial class BaseAnimatedPanel
   {
      #region Dependency Properties for BaseAnimatedPanel
      public static readonly DependencyProperty AnimationDurationProperty = 
         DependencyProperty.Register (
               "AnimationDuration"
            ,  typeof (TimeSpan)
            ,  typeof (BaseAnimatedPanel)            
            ,  new PropertyMetadata (
                  new TimeSpan (0,0,0,0,400)
               ,  OnChange_AnimationDuration
               )
            );

      static void OnChange_AnimationDuration (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:AnimationDuration, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as BaseAnimatedPanel;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (TimeSpan)e.OldValue;
         var newValue = (TimeSpan)e.NewValue;
         var handled = false;
         dobj.OnChange_AnimationDuration (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public TimeSpan AnimationDuration
      {
         get
         {
            return (TimeSpan) GetValue (AnimationDurationProperty);
         }
         set
         {
            var currentValue = AnimationDuration;

            if (currentValue != value)
            {
               SetValue (AnimationDurationProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_AnimationDuration (TimeSpan oldValue, TimeSpan newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class AnimatedWrapPanel
   {
      #region Dependency Properties for AnimatedWrapPanel
      public static readonly DependencyProperty OrientationProperty = 
         DependencyProperty.Register (
               "Orientation"
            ,  typeof (Orientation)
            ,  typeof (AnimatedWrapPanel)            
            ,  new PropertyMetadata (
                  default (Orientation)
               ,  OnChange_Orientation
               )
            );

      static void OnChange_Orientation (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Orientation, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as AnimatedWrapPanel;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Orientation)e.OldValue;
         var newValue = (Orientation)e.NewValue;
         var handled = false;
         dobj.OnChange_Orientation (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Orientation Orientation
      {
         get
         {
            return (Orientation) GetValue (OrientationProperty);
         }
         set
         {
            var currentValue = Orientation;

            if (currentValue != value)
            {
               SetValue (OrientationProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Orientation (Orientation oldValue, Orientation newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class FixedDimension
   {
      #region Dependency Properties for FixedDimension
      public static readonly DependencyProperty DimensionProperty = 
         DependencyProperty.Register (
               "Dimension"
            ,  typeof (Size)
            ,  typeof (FixedDimension)            
            ,  new PropertyMetadata (
                  default (Size)
               ,  OnChange_Dimension
               )
            );

      static void OnChange_Dimension (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Dimension, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FixedDimension;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Size)e.OldValue;
         var newValue = (Size)e.NewValue;
         var handled = false;
         dobj.OnChange_Dimension (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Size Dimension
      {
         get
         {
            return (Size) GetValue (DimensionProperty);
         }
         set
         {
            var currentValue = Dimension;

            if (currentValue != value)
            {
               SetValue (DimensionProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Dimension (Size oldValue, Size newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class ImageCaptionButton
   {
      #region Dependency Properties for ImageCaptionButton
      public static readonly DependencyProperty ImageProperty = 
         DependencyProperty.Register (
               "Image"
            ,  typeof (ImageSource)
            ,  typeof (ImageCaptionButton)            
            ,  new PropertyMetadata (
                  default (ImageSource)
               ,  OnChange_Image
               )
            );

      static void OnChange_Image (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Image, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as ImageCaptionButton;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ImageSource)e.OldValue;
         var newValue = (ImageSource)e.NewValue;
         var handled = false;
         dobj.OnChange_Image (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty CaptionProperty = 
         DependencyProperty.Register (
               "Caption"
            ,  typeof (string)
            ,  typeof (ImageCaptionButton)            
            ,  new PropertyMetadata (
                  default (string)
               ,  OnChange_Caption
               )
            );

      static void OnChange_Caption (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Caption, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as ImageCaptionButton;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (string)e.OldValue;
         var newValue = (string)e.NewValue;
         var handled = false;
         dobj.OnChange_Caption (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ImageSource Image
      {
         get
         {
            return (ImageSource) GetValue (ImageProperty);
         }
         set
         {
            var currentValue = Image;

            if (currentValue != value)
            {
               SetValue (ImageProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Image (ImageSource oldValue, ImageSource newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string Caption
      {
         get
         {
            return (string) GetValue (CaptionProperty);
         }
         set
         {
            var currentValue = Caption;

            if (currentValue != value)
            {
               SetValue (CaptionProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Caption (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class WatermarkTextBox
   {
      #region Dependency Properties for WatermarkTextBox
      public static readonly DependencyProperty WatermarkProperty = 
         DependencyProperty.Register (
               "Watermark"
            ,  typeof (string)
            ,  typeof (WatermarkTextBox)            
            ,  new PropertyMetadata (
                  "Type to search..."
               ,  OnChange_Watermark
               )
            );

      static void OnChange_Watermark (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Watermark, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as WatermarkTextBox;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (string)e.OldValue;
         var newValue = (string)e.NewValue;
         var handled = false;
         dobj.OnChange_Watermark (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty WatermarkBrushProperty = 
         DependencyProperty.Register (
               "WatermarkBrush"
            ,  typeof (Brush)
            ,  typeof (WatermarkTextBox)            
            ,  new PropertyMetadata (
                  new SolidColorBrush (Colors.Gray)
               ,  OnChange_WatermarkBrush
               )
            );

      static void OnChange_WatermarkBrush (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:WatermarkBrush, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as WatermarkTextBox;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Brush)e.OldValue;
         var newValue = (Brush)e.NewValue;
         var handled = false;
         dobj.OnChange_WatermarkBrush (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty WatermarkVisibilityProperty = 
         DependencyProperty.Register (
               "WatermarkVisibility"
            ,  typeof (Visibility)
            ,  typeof (WatermarkTextBox)            
            ,  new PropertyMetadata (
                  Visibility.Visible
               ,  OnChange_WatermarkVisibility
               )
            );

      static void OnChange_WatermarkVisibility (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:WatermarkVisibility, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as WatermarkTextBox;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Visibility)e.OldValue;
         var newValue = (Visibility)e.NewValue;
         var handled = false;
         dobj.OnChange_WatermarkVisibility (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string Watermark
      {
         get
         {
            return (string) GetValue (WatermarkProperty);
         }
         set
         {
            var currentValue = Watermark;

            if (currentValue != value)
            {
               SetValue (WatermarkProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Watermark (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Brush WatermarkBrush
      {
         get
         {
            return (Brush) GetValue (WatermarkBrushProperty);
         }
         set
         {
            var currentValue = WatermarkBrush;

            if (currentValue != value)
            {
               SetValue (WatermarkBrushProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_WatermarkBrush (Brush oldValue, Brush newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Visibility WatermarkVisibility
      {
         get
         {
            return (Visibility) GetValue (WatermarkVisibilityProperty);
         }
         set
         {
            var currentValue = WatermarkVisibility;

            if (currentValue != value)
            {
               SetValue (WatermarkVisibilityProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_WatermarkVisibility (Visibility oldValue, Visibility newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class SearchTextBox
   {
      #region Dependency Properties for SearchTextBox
      public static readonly DependencyProperty SearchTextProperty = 
         DependencyProperty.Register (
               "SearchText"
            ,  typeof (string)
            ,  typeof (SearchTextBox)            
            ,  new PropertyMetadata (
                  default (string)
               ,  OnChange_SearchText
               )
            );

      static void OnChange_SearchText (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SearchText, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as SearchTextBox;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (string)e.OldValue;
         var newValue = (string)e.NewValue;
         var handled = false;
         dobj.OnChange_SearchText (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty SearchTimeOutProperty = 
         DependencyProperty.Register (
               "SearchTimeOut"
            ,  typeof (TimeSpan)
            ,  typeof (SearchTextBox)            
            ,  new PropertyMetadata (
                  new TimeSpan (0,0,0,0,500)
               ,  OnChange_SearchTimeOut
               )
            );

      static void OnChange_SearchTimeOut (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SearchTimeOut, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as SearchTextBox;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (TimeSpan)e.OldValue;
         var newValue = (TimeSpan)e.NewValue;
         var handled = false;
         dobj.OnChange_SearchTimeOut (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string SearchText
      {
         get
         {
            return (string) GetValue (SearchTextProperty);
         }
         set
         {
            var currentValue = SearchText;

            if (currentValue != value)
            {
               SetValue (SearchTextProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SearchText (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public TimeSpan SearchTimeOut
      {
         get
         {
            return (TimeSpan) GetValue (SearchTimeOutProperty);
         }
         set
         {
            var currentValue = SearchTimeOut;

            if (currentValue != value)
            {
               SetValue (SearchTimeOutProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SearchTimeOut (TimeSpan oldValue, TimeSpan newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class OptionalContentControl
   {
      #region Dependency Properties for OptionalContentControl
      public static readonly DependencyProperty OptionalContentProperty = 
         DependencyProperty.Register (
               "OptionalContent"
            ,  typeof (object)
            ,  typeof (OptionalContentControl)            
            ,  new PropertyMetadata (
                  default (object)
               ,  OnChange_OptionalContent
               )
            );

      static void OnChange_OptionalContent (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:OptionalContent, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as OptionalContentControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (object)e.OldValue;
         var newValue = (object)e.NewValue;
         var handled = false;
         dobj.OnChange_OptionalContent (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty OptionalContentTemplateProperty = 
         DependencyProperty.Register (
               "OptionalContentTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (OptionalContentControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_OptionalContentTemplate
               )
            );

      static void OnChange_OptionalContentTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:OptionalContentTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as OptionalContentControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_OptionalContentTemplate (oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public object OptionalContent
      {
         get
         {
            return (object) GetValue (OptionalContentProperty);
         }
         set
         {
            var currentValue = OptionalContent;

            if (currentValue != value)
            {
               SetValue (OptionalContentProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_OptionalContent (object oldValue, object newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate OptionalContentTemplate
      {
         get
         {
            return (DataTemplate) GetValue (OptionalContentTemplateProperty);
         }
         set
         {
            var currentValue = OptionalContentTemplate;

            if (currentValue != value)
            {
               SetValue (OptionalContentTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_OptionalContentTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class PopupControl
   {
      #region Dependency Properties for PopupControl
      #endregion
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class SearchControl
   {
      #region Dependency Properties for SearchControl
      public static readonly DependencyProperty SearchStringProperty = 
         DependencyProperty.Register (
               "SearchString"
            ,  typeof (string)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  default (string)
               ,  OnChange_SearchString
               )
            );

      static void OnChange_SearchString (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SearchString, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as SearchControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (string)e.OldValue;
         var newValue = (string)e.NewValue;
         var handled = false;
         dobj.OnChange_SearchString (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty SearchDelegateProperty = 
         DependencyProperty.Register (
               "SearchDelegate"
            ,  typeof (SearchControlDelegate)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  default (SearchControlDelegate)
               ,  OnChange_SearchDelegate
               )
            );

      static void OnChange_SearchDelegate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SearchDelegate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as SearchControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (SearchControlDelegate)e.OldValue;
         var newValue = (SearchControlDelegate)e.NewValue;
         var handled = false;
         dobj.OnChange_SearchDelegate (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty SearchItemTemplateProperty = 
         DependencyProperty.Register (
               "SearchItemTemplate"
            ,  typeof (DataTemplate)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  default (DataTemplate)
               ,  OnChange_SearchItemTemplate
               )
            );

      static void OnChange_SearchItemTemplate (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SearchItemTemplate, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as SearchControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DataTemplate)e.OldValue;
         var newValue = (DataTemplate)e.NewValue;
         var handled = false;
         dobj.OnChange_SearchItemTemplate (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty SearchItemsSourceProperty = 
         DependencyProperty.Register (
               "SearchItemsSource"
            ,  typeof (ObservableCollection<DependencyObject>)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_SearchItemsSource
               )
            );

      static void OnChange_SearchItemsSource (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SearchItemsSource, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as SearchControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ObservableCollection<DependencyObject>)e.OldValue;
         var newValue = (ObservableCollection<DependencyObject>)e.NewValue;
         var handled = false;
         dobj.OnChange_SearchItemsSource (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty SearchResultItemsProperty = 
         DependencyProperty.Register (
               "SearchResultItems"
            ,  typeof (ObservableCollection<DependencyObject>)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_SearchResultItems
               )
            );

      static void OnChange_SearchResultItems (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SearchResultItems, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as SearchControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ObservableCollection<DependencyObject>)e.OldValue;
         var newValue = (ObservableCollection<DependencyObject>)e.NewValue;
         var handled = false;
         dobj.OnChange_SearchResultItems (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty CurrentSearchResultItemProperty = 
         DependencyProperty.Register (
               "CurrentSearchResultItem"
            ,  typeof (DependencyObject)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  default (DependencyObject)
               ,  OnChange_CurrentSearchResultItem
               )
            );

      static void OnChange_CurrentSearchResultItem (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:CurrentSearchResultItem, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as SearchControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DependencyObject)e.OldValue;
         var newValue = (DependencyObject)e.NewValue;
         var handled = false;
         dobj.OnChange_CurrentSearchResultItem (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty SearchTimeOutProperty = 
         DependencyProperty.Register (
               "SearchTimeOut"
            ,  typeof (TimeSpan)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  new TimeSpan (0,0,0,0,500)
               ,  OnChange_SearchTimeOut
               )
            );

      static void OnChange_SearchTimeOut (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SearchTimeOut, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as SearchControl;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (TimeSpan)e.OldValue;
         var newValue = (TimeSpan)e.NewValue;
         var handled = false;
         dobj.OnChange_SearchTimeOut (oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty IdProperty = 
         DependencyProperty.RegisterAttached (
               "Id"
            ,  typeof (int)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  default (int)
               ,  OnChange_Id
               )
            );

      static void OnChange_Id (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Id, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as DependencyObject;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (int)e.OldValue;
         var newValue = (int)e.NewValue;
         var handled = false;
         OnChange_Id (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty CurrentIndexProperty = 
         DependencyProperty.RegisterAttached (
               "CurrentIndex"
            ,  typeof (int)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  default (int)
               ,  OnChange_CurrentIndex
               )
            );

      static void OnChange_CurrentIndex (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:CurrentIndex, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as DependencyObject;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (int)e.OldValue;
         var newValue = (int)e.NewValue;
         var handled = false;
         OnChange_CurrentIndex (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty DesiredIndexProperty = 
         DependencyProperty.RegisterAttached (
               "DesiredIndex"
            ,  typeof (int)
            ,  typeof (SearchControl)            
            ,  new PropertyMetadata (
                  default (int)
               ,  OnChange_DesiredIndex
               )
            );

      static void OnChange_DesiredIndex (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:DesiredIndex, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as DependencyObject;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (int)e.OldValue;
         var newValue = (int)e.NewValue;
         var handled = false;
         OnChange_DesiredIndex (dobj, oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string SearchString
      {
         get
         {
            return (string) GetValue (SearchStringProperty);
         }
         set
         {
            var currentValue = SearchString;

            if (currentValue != value)
            {
               SetValue (SearchStringProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SearchString (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public SearchControlDelegate SearchDelegate
      {
         get
         {
            return (SearchControlDelegate) GetValue (SearchDelegateProperty);
         }
         set
         {
            var currentValue = SearchDelegate;

            if (currentValue != value)
            {
               SetValue (SearchDelegateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SearchDelegate (SearchControlDelegate oldValue, SearchControlDelegate newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DataTemplate SearchItemTemplate
      {
         get
         {
            return (DataTemplate) GetValue (SearchItemTemplateProperty);
         }
         set
         {
            var currentValue = SearchItemTemplate;

            if (currentValue != value)
            {
               SetValue (SearchItemTemplateProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SearchItemTemplate (DataTemplate oldValue, DataTemplate newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<DependencyObject> SearchItemsSource
      {
         get
         {
            return (ObservableCollection<DependencyObject>) GetValue (SearchItemsSourceProperty);
         }
         set
         {
            var currentValue = SearchItemsSource;

            if (currentValue != value)
            {
               SetValue (SearchItemsSourceProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SearchItemsSource (ObservableCollection<DependencyObject> oldValue, ObservableCollection<DependencyObject> newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<DependencyObject> SearchResultItems
      {
         get
         {
            return (ObservableCollection<DependencyObject>) GetValue (SearchResultItemsProperty);
         }
         set
         {
            var currentValue = SearchResultItems;

            if (currentValue != value)
            {
               SetValue (SearchResultItemsProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SearchResultItems (ObservableCollection<DependencyObject> oldValue, ObservableCollection<DependencyObject> newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public DependencyObject CurrentSearchResultItem
      {
         get
         {
            return (DependencyObject) GetValue (CurrentSearchResultItemProperty);
         }
         set
         {
            var currentValue = CurrentSearchResultItem;

            if (currentValue != value)
            {
               SetValue (CurrentSearchResultItemProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_CurrentSearchResultItem (DependencyObject oldValue, DependencyObject newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public TimeSpan SearchTimeOut
      {
         get
         {
            return (TimeSpan) GetValue (SearchTimeOutProperty);
         }
         set
         {
            var currentValue = SearchTimeOut;

            if (currentValue != value)
            {
               SetValue (SearchTimeOutProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_SearchTimeOut (TimeSpan oldValue, TimeSpan newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static int GetId (DependencyObject dobj)
      {
         if (dobj != null)
         {
            return (int) dobj.GetValue (IdProperty);
         }
         else
         {
            return default (int);
         }
      }

      public static void SetId (DependencyObject dobj, int value)
      {
         if (dobj != null)
         {
            dobj.SetValue (IdProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Id (DependencyObject dobj, int oldValue, int newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static int GetCurrentIndex (DependencyObject dobj)
      {
         if (dobj != null)
         {
            return (int) dobj.GetValue (CurrentIndexProperty);
         }
         else
         {
            return default (int);
         }
      }

      public static void SetCurrentIndex (DependencyObject dobj, int value)
      {
         if (dobj != null)
         {
            dobj.SetValue (CurrentIndexProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_CurrentIndex (DependencyObject dobj, int oldValue, int newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static int GetDesiredIndex (DependencyObject dobj)
      {
         if (dobj != null)
         {
            return (int) dobj.GetValue (DesiredIndexProperty);
         }
         else
         {
            return default (int);
         }
      }

      public static void SetDesiredIndex (DependencyObject dobj, int value)
      {
         if (dobj != null)
         {
            dobj.SetValue (DesiredIndexProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_DesiredIndex (DependencyObject dobj, int oldValue, int newValue, ref bool handled);
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


