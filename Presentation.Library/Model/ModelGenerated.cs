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
using Presentation.Library.Utility;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable HeuristicUnreachableCode
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart


namespace Presentation.Library.Model
{
   // -------------------------------------------------------------------------

   // *************************************************************************
   // MODEL CLASSES
   // *************************************************************************

   // -------------------------------------------------------------------------
   public sealed partial class Theme
      :  BaseModelEntity
      
   {
      #region Dependency Properties for Theme
      public static readonly DependencyProperty DimensionProperty = 
         DependencyProperty.Register (
               "Dimension"
            ,  typeof (Size)
            ,  typeof (Theme)            
            ,  new PropertyMetadata (
                  new Size (1280, 1024)
               ,  OnChange_Dimension
               )
            );

      static void OnChange_Dimension (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Dimension, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (Theme)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (Size)e.OldValue;
               var newValue = (Size)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Dimension (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      #endregion

      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Theme (ModelContext modelContext)
         :  base (modelContext)
      {
         OnCreate_Theme ();
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      partial void OnCreate_Theme ();
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public override void Update<TParent> (TParent parent)
      {
         var handled = false;
         OnChange_Dimension (Dimension, Dimension, ref handled);
         handled = false;

         Update (this, Dimension);
      }
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
   public sealed partial class Presentation
      :  BaseModelEntity
      
   {
      #region Dependency Properties for Presentation
      public static readonly DependencyProperty NameProperty = 
         DependencyProperty.Register (
               "Name"
            ,  typeof (string)
            ,  typeof (Presentation)            
            ,  new PropertyMetadata (
                  "[Untitled]"
               ,  OnChange_Name
               )
            );

      static void OnChange_Name (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Name, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (Presentation)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (string)e.OldValue;
               var newValue = (string)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Name (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty CreatedProperty = 
         DependencyProperty.Register (
               "Created"
            ,  typeof (DateTime)
            ,  typeof (Presentation)            
            ,  new PropertyMetadata (
                  default (DateTime)
               ,  OnChange_Created
               )
            );

      static void OnChange_Created (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Created, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (Presentation)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (DateTime)e.OldValue;
               var newValue = (DateTime)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Created (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty IsShowingNotesProperty = 
         DependencyProperty.Register (
               "IsShowingNotes"
            ,  typeof (bool)
            ,  typeof (Presentation)            
            ,  new PropertyMetadata (
                  default (bool)
               ,  OnChange_IsShowingNotes
               )
            );

      static void OnChange_IsShowingNotes (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:IsShowingNotes, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (Presentation)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (bool)e.OldValue;
               var newValue = (bool)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_IsShowingNotes (oldValue, newValue, ref handled);
               }

            }
         }
      }
      public static readonly DependencyProperty CurrentThemeProperty = 
         DependencyProperty.Register (
               "CurrentTheme"
            ,  typeof (Theme)
            ,  typeof (Presentation)            
            ,  new PropertyMetadata (
                  default (Theme)
               ,  OnChange_CurrentTheme
               )
            );

      static void OnChange_CurrentTheme (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:CurrentTheme, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (Presentation)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (Theme)e.OldValue;
               var newValue = (Theme)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_CurrentTheme (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty CurrentSlideProperty = 
         DependencyProperty.Register (
               "CurrentSlide"
            ,  typeof (Slide)
            ,  typeof (Presentation)            
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
         var dobj = (Presentation)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (Slide)e.OldValue;
               var newValue = (Slide)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_CurrentSlide (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty SlidesProperty = 
         DependencyProperty.Register (
               "Slides"
            ,  typeof (ObservableCollection<Slide>)
            ,  typeof (Presentation)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_Slides
               )
            );

      static void OnChange_Slides (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Slides, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (Presentation)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (ObservableCollection<Slide>)e.OldValue;
               var newValue = (ObservableCollection<Slide>)e.NewValue;

               if (oldValue != null)
               {
                  oldValue.CollectionChanged -= dobj.OnCollectionChanged;
               }

               if (newValue != null)
               {
                  newValue.CollectionChanged += dobj.OnCollectionChanged;
               }

               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Slides (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      #endregion

      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Presentation (ModelContext modelContext)
         :  base (modelContext)
      {
         OnCreate_Presentation ();
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      partial void OnCreate_Presentation ();
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public override void Update<TParent> (TParent parent)
      {
         var handled = false;
         OnChange_Name (Name, Name, ref handled);
         handled = false;
         OnChange_Created (Created, Created, ref handled);
         handled = false;
         OnChange_IsShowingNotes (IsShowingNotes, IsShowingNotes, ref handled);
         handled = false;
         OnChange_CurrentTheme (CurrentTheme, CurrentTheme, ref handled);
         handled = false;
         OnChange_CurrentSlide (CurrentSlide, CurrentSlide, ref handled);
         handled = false;
         OnChange_Slides (Slides, Slides, ref handled);
         handled = false;

         Update (this, Name);
         Update (this, Created);
         Update (this, IsShowingNotes);
         Update (this, CurrentTheme);
         Update (this, CurrentSlide);
         Update (this, Slides);
      }
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

      // ----------------------------------------------------------------------
      public DateTime Created
      {
         get
         {
            return (DateTime) GetValue (CreatedProperty);
         }
         set
         {
            var currentValue = Created;

            if (currentValue != value)
            {
               SetValue (CreatedProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Created (DateTime oldValue, DateTime newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public bool IsShowingNotes
      {
         get
         {
            return (bool) GetValue (IsShowingNotesProperty);
         }
         set
         {
            var currentValue = IsShowingNotes;

            if (currentValue != value)
            {
               SetValue (IsShowingNotesProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_IsShowingNotes (bool oldValue, bool newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Theme CurrentTheme
      {
         get
         {
            return (Theme) GetValue (CurrentThemeProperty);
         }
         set
         {
            var currentValue = CurrentTheme;

            if (currentValue != value)
            {
               SetValue (CurrentThemeProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_CurrentTheme (Theme oldValue, Theme newValue, ref bool handled);
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
      public ObservableCollection<Slide> Slides
      {
         get
         {
            return (ObservableCollection<Slide>) GetValue (SlidesProperty);
         }
         set
         {
            var currentValue = Slides;

            if (currentValue != value)
            {
               SetValue (SlidesProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Slides (ObservableCollection<Slide> oldValue, ObservableCollection<Slide> newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }

   // -------------------------------------------------------------------------
   public abstract partial class BaseElement
      :  BaseModelEntity
      
   {
      #region Dependency Properties for BaseElement
      public static readonly DependencyProperty ZIndexProperty = 
         DependencyProperty.Register (
               "ZIndex"
            ,  typeof (int)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (int)
               ,  OnChange_ZIndex
               )
            );

      static void OnChange_ZIndex (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ZIndex, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (BaseElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (int)e.OldValue;
               var newValue = (int)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_ZIndex (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty OpacityPercentProperty = 
         DependencyProperty.Register (
               "OpacityPercent"
            ,  typeof (int)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  100
               ,  OnChange_OpacityPercent
               )
            );

      static void OnChange_OpacityPercent (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:OpacityPercent, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (BaseElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (int)e.OldValue;
               var newValue = (int)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_OpacityPercent (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty AngleProperty = 
         DependencyProperty.Register (
               "Angle"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_Angle
               )
            );

      static void OnChange_Angle (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Angle, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (BaseElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (double)e.OldValue;
               var newValue = (double)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Angle (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty LeftProperty = 
         DependencyProperty.Register (
               "Left"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_Left
               )
            );

      static void OnChange_Left (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Left, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (BaseElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (double)e.OldValue;
               var newValue = (double)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Left (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty TopProperty = 
         DependencyProperty.Register (
               "Top"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_Top
               )
            );

      static void OnChange_Top (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Top, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (BaseElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (double)e.OldValue;
               var newValue = (double)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Top (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty WidthProperty = 
         DependencyProperty.Register (
               "Width"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  100.0
               ,  OnChange_Width
               )
            );

      static void OnChange_Width (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Width, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (BaseElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (double)e.OldValue;
               var newValue = (double)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Width (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty HeightProperty = 
         DependencyProperty.Register (
               "Height"
            ,  typeof (double)
            ,  typeof (BaseElement)            
            ,  new PropertyMetadata (
                  100.0
               ,  OnChange_Height
               )
            );

      static void OnChange_Height (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Height, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (BaseElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (double)e.OldValue;
               var newValue = (double)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Height (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      #endregion

      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      protected BaseElement (ModelContext modelContext)
         :  base (modelContext)
      {
         OnCreate_BaseElement ();
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      partial void OnCreate_BaseElement ();
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public override void Update<TParent> (TParent parent)
      {
         var handled = false;
         OnChange_ZIndex (ZIndex, ZIndex, ref handled);
         handled = false;
         OnChange_OpacityPercent (OpacityPercent, OpacityPercent, ref handled);
         handled = false;
         OnChange_Angle (Angle, Angle, ref handled);
         handled = false;
         OnChange_Left (Left, Left, ref handled);
         handled = false;
         OnChange_Top (Top, Top, ref handled);
         handled = false;
         OnChange_Width (Width, Width, ref handled);
         handled = false;
         OnChange_Height (Height, Height, ref handled);
         handled = false;

         Update (this, ZIndex);
         Update (this, OpacityPercent);
         Update (this, Angle);
         Update (this, Left);
         Update (this, Top);
         Update (this, Width);
         Update (this, Height);
      }
      // ----------------------------------------------------------------------


      // ----------------------------------------------------------------------
      public int ZIndex
      {
         get
         {
            return (int) GetValue (ZIndexProperty);
         }
         set
         {
            var currentValue = ZIndex;

            if (currentValue != value)
            {
               SetValue (ZIndexProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_ZIndex (int oldValue, int newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public int OpacityPercent
      {
         get
         {
            return (int) GetValue (OpacityPercentProperty);
         }
         set
         {
            var currentValue = OpacityPercent;

            if (currentValue != value)
            {
               SetValue (OpacityPercentProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_OpacityPercent (int oldValue, int newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double Angle
      {
         get
         {
            return (double) GetValue (AngleProperty);
         }
         set
         {
            var currentValue = Angle;

            if (currentValue != value)
            {
               SetValue (AngleProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Angle (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double Left
      {
         get
         {
            return (double) GetValue (LeftProperty);
         }
         set
         {
            var currentValue = Left;

            if (currentValue != value)
            {
               SetValue (LeftProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Left (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double Top
      {
         get
         {
            return (double) GetValue (TopProperty);
         }
         set
         {
            var currentValue = Top;

            if (currentValue != value)
            {
               SetValue (TopProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Top (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double Width
      {
         get
         {
            return (double) GetValue (WidthProperty);
         }
         set
         {
            var currentValue = Width;

            if (currentValue != value)
            {
               SetValue (WidthProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Width (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double Height
      {
         get
         {
            return (double) GetValue (HeightProperty);
         }
         set
         {
            var currentValue = Height;

            if (currentValue != value)
            {
               SetValue (HeightProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Height (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }

   // -------------------------------------------------------------------------
   public sealed partial class TextElement
      :  BaseElement
      
   {
      #region Dependency Properties for TextElement
      public static readonly DependencyProperty BackgroundColorProperty = 
         DependencyProperty.Register (
               "BackgroundColor"
            ,  typeof (Color)
            ,  typeof (TextElement)            
            ,  new PropertyMetadata (
                  Colors.Transparent
               ,  OnChange_BackgroundColor
               )
            );

      static void OnChange_BackgroundColor (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:BackgroundColor, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (TextElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (Color)e.OldValue;
               var newValue = (Color)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_BackgroundColor (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty ForegroundColorProperty = 
         DependencyProperty.Register (
               "ForegroundColor"
            ,  typeof (Color)
            ,  typeof (TextElement)            
            ,  new PropertyMetadata (
                  Colors.White
               ,  OnChange_ForegroundColor
               )
            );

      static void OnChange_ForegroundColor (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ForegroundColor, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (TextElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (Color)e.OldValue;
               var newValue = (Color)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_ForegroundColor (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty FontNameProperty = 
         DependencyProperty.Register (
               "FontName"
            ,  typeof (string)
            ,  typeof (TextElement)            
            ,  new PropertyMetadata (
                  "Verdana"
               ,  OnChange_FontName
               )
            );

      static void OnChange_FontName (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:FontName, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (TextElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (string)e.OldValue;
               var newValue = (string)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_FontName (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty FontSizeProperty = 
         DependencyProperty.Register (
               "FontSize"
            ,  typeof (double)
            ,  typeof (TextElement)            
            ,  new PropertyMetadata (
                  24.0
               ,  OnChange_FontSize
               )
            );

      static void OnChange_FontSize (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:FontSize, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (TextElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (double)e.OldValue;
               var newValue = (double)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_FontSize (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty TextProperty = 
         DependencyProperty.Register (
               "Text"
            ,  typeof (string)
            ,  typeof (TextElement)            
            ,  new PropertyMetadata (
                  "Write some text"
               ,  OnChange_Text
               )
            );

      static void OnChange_Text (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Text, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (TextElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (string)e.OldValue;
               var newValue = (string)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Text (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      #endregion

      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public TextElement (ModelContext modelContext)
         :  base (modelContext)
      {
         OnCreate_TextElement ();
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      partial void OnCreate_TextElement ();
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public override void Update<TParent> (TParent parent)
      {
         var handled = false;
         OnChange_BackgroundColor (BackgroundColor, BackgroundColor, ref handled);
         handled = false;
         OnChange_ForegroundColor (ForegroundColor, ForegroundColor, ref handled);
         handled = false;
         OnChange_FontName (FontName, FontName, ref handled);
         handled = false;
         OnChange_FontSize (FontSize, FontSize, ref handled);
         handled = false;
         OnChange_Text (Text, Text, ref handled);
         handled = false;

         Update (this, BackgroundColor);
         Update (this, ForegroundColor);
         Update (this, FontName);
         Update (this, FontSize);
         Update (this, Text);
      }
      // ----------------------------------------------------------------------


      // ----------------------------------------------------------------------
      public Color BackgroundColor
      {
         get
         {
            return (Color) GetValue (BackgroundColorProperty);
         }
         set
         {
            var currentValue = BackgroundColor;

            if (currentValue != value)
            {
               SetValue (BackgroundColorProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_BackgroundColor (Color oldValue, Color newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Color ForegroundColor
      {
         get
         {
            return (Color) GetValue (ForegroundColorProperty);
         }
         set
         {
            var currentValue = ForegroundColor;

            if (currentValue != value)
            {
               SetValue (ForegroundColorProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_ForegroundColor (Color oldValue, Color newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string FontName
      {
         get
         {
            return (string) GetValue (FontNameProperty);
         }
         set
         {
            var currentValue = FontName;

            if (currentValue != value)
            {
               SetValue (FontNameProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_FontName (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public double FontSize
      {
         get
         {
            return (double) GetValue (FontSizeProperty);
         }
         set
         {
            var currentValue = FontSize;

            if (currentValue != value)
            {
               SetValue (FontSizeProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_FontSize (double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string Text
      {
         get
         {
            return (string) GetValue (TextProperty);
         }
         set
         {
            var currentValue = Text;

            if (currentValue != value)
            {
               SetValue (TextProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Text (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }

   // -------------------------------------------------------------------------
   public sealed partial class PictureElement
      :  BaseElement
      
   {
      #region Dependency Properties for PictureElement
      public static readonly DependencyProperty PictureSourceProperty = 
         DependencyProperty.Register (
               "PictureSource"
            ,  typeof (string)
            ,  typeof (PictureElement)            
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
         var dobj = (PictureElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (string)e.OldValue;
               var newValue = (string)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_PictureSource (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      #endregion

      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public PictureElement (ModelContext modelContext)
         :  base (modelContext)
      {
         OnCreate_PictureElement ();
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      partial void OnCreate_PictureElement ();
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public override void Update<TParent> (TParent parent)
      {
         var handled = false;
         OnChange_PictureSource (PictureSource, PictureSource, ref handled);
         handled = false;

         Update (this, PictureSource);
      }
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
   }

   // -------------------------------------------------------------------------
   public sealed partial class ShapeElement
      :  BaseElement
      
   {
      #region Dependency Properties for ShapeElement
      public static readonly DependencyProperty BackgroundColorProperty = 
         DependencyProperty.Register (
               "BackgroundColor"
            ,  typeof (Color)
            ,  typeof (ShapeElement)            
            ,  new PropertyMetadata (
                  Colors.Transparent
               ,  OnChange_BackgroundColor
               )
            );

      static void OnChange_BackgroundColor (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:BackgroundColor, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (ShapeElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (Color)e.OldValue;
               var newValue = (Color)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_BackgroundColor (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty ForegroundColorProperty = 
         DependencyProperty.Register (
               "ForegroundColor"
            ,  typeof (Color)
            ,  typeof (ShapeElement)            
            ,  new PropertyMetadata (
                  Colors.White
               ,  OnChange_ForegroundColor
               )
            );

      static void OnChange_ForegroundColor (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ForegroundColor, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (ShapeElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (Color)e.OldValue;
               var newValue = (Color)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_ForegroundColor (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty PathProperty = 
         DependencyProperty.Register (
               "Path"
            ,  typeof (string)
            ,  typeof (ShapeElement)            
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
         var dobj = (ShapeElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (string)e.OldValue;
               var newValue = (string)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Path (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      #endregion

      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ShapeElement (ModelContext modelContext)
         :  base (modelContext)
      {
         OnCreate_ShapeElement ();
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      partial void OnCreate_ShapeElement ();
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public override void Update<TParent> (TParent parent)
      {
         var handled = false;
         OnChange_BackgroundColor (BackgroundColor, BackgroundColor, ref handled);
         handled = false;
         OnChange_ForegroundColor (ForegroundColor, ForegroundColor, ref handled);
         handled = false;
         OnChange_Path (Path, Path, ref handled);
         handled = false;

         Update (this, BackgroundColor);
         Update (this, ForegroundColor);
         Update (this, Path);
      }
      // ----------------------------------------------------------------------


      // ----------------------------------------------------------------------
      public Color BackgroundColor
      {
         get
         {
            return (Color) GetValue (BackgroundColorProperty);
         }
         set
         {
            var currentValue = BackgroundColor;

            if (currentValue != value)
            {
               SetValue (BackgroundColorProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_BackgroundColor (Color oldValue, Color newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Color ForegroundColor
      {
         get
         {
            return (Color) GetValue (ForegroundColorProperty);
         }
         set
         {
            var currentValue = ForegroundColor;

            if (currentValue != value)
            {
               SetValue (ForegroundColorProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_ForegroundColor (Color oldValue, Color newValue, ref bool handled);
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
   public sealed partial class MovieElement
      :  BaseElement
      
   {
      #region Dependency Properties for MovieElement
      public static readonly DependencyProperty MovieSourceProperty = 
         DependencyProperty.Register (
               "MovieSource"
            ,  typeof (string)
            ,  typeof (MovieElement)            
            ,  new PropertyMetadata (
                  default (string)
               ,  OnChange_MovieSource
               )
            );

      static void OnChange_MovieSource (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:MovieSource, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (MovieElement)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (string)e.OldValue;
               var newValue = (string)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_MovieSource (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      #endregion

      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public MovieElement (ModelContext modelContext)
         :  base (modelContext)
      {
         OnCreate_MovieElement ();
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      partial void OnCreate_MovieElement ();
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public override void Update<TParent> (TParent parent)
      {
         var handled = false;
         OnChange_MovieSource (MovieSource, MovieSource, ref handled);
         handled = false;

         Update (this, MovieSource);
      }
      // ----------------------------------------------------------------------


      // ----------------------------------------------------------------------
      public string MovieSource
      {
         get
         {
            return (string) GetValue (MovieSourceProperty);
         }
         set
         {
            var currentValue = MovieSource;

            if (currentValue != value)
            {
               SetValue (MovieSourceProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_MovieSource (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }

   // -------------------------------------------------------------------------
   public sealed partial class Slide
      :  BaseModelEntity
      
   {
      #region Dependency Properties for Slide
      public static readonly DependencyProperty CreatedProperty = 
         DependencyProperty.Register (
               "Created"
            ,  typeof (DateTime)
            ,  typeof (Slide)            
            ,  new PropertyMetadata (
                  default (DateTime)
               ,  OnChange_Created
               )
            );

      static void OnChange_Created (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Created, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (Slide)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (DateTime)e.OldValue;
               var newValue = (DateTime)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Created (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty NoteProperty = 
         DependencyProperty.Register (
               "Note"
            ,  typeof (string)
            ,  typeof (Slide)            
            ,  new PropertyMetadata (
                  default (string)
               ,  OnChange_Note
               )
            );

      static void OnChange_Note (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Note, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (Slide)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (string)e.OldValue;
               var newValue = (string)e.NewValue;


               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Note (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      public static readonly DependencyProperty ElementsProperty = 
         DependencyProperty.Register (
               "Elements"
            ,  typeof (ObservableCollection<BaseElement>)
            ,  typeof (Slide)            
            ,  new PropertyMetadata (
                  null
               ,  OnChange_Elements
               )
            );

      static void OnChange_Elements (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Elements, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = (Slide)d;
         if (dobj != null)
         {
            var mc = dobj.ModelContext;
            if (mc != null)
            {
               var oldValue = (ObservableCollection<BaseElement>)e.OldValue;
               var newValue = (ObservableCollection<BaseElement>)e.NewValue;

               if (oldValue != null)
               {
                  oldValue.CollectionChanged -= dobj.OnCollectionChanged;
               }

               if (newValue != null)
               {
                  newValue.CollectionChanged += dobj.OnCollectionChanged;
               }

               if (mc.ChangeNotificationActivated)
               {
                  var handled = false;
                  dobj.OnChange_Elements (oldValue, newValue, ref handled);
               }

               if (mc.IsChangeTracking)
               {
                  mc.AppendSetPropertyAction (
                     d,
                     e
                     );
               }
            }
         }
      }
      #endregion

      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public Slide (ModelContext modelContext)
         :  base (modelContext)
      {
         OnCreate_Slide ();
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      partial void OnCreate_Slide ();
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public override void Update<TParent> (TParent parent)
      {
         var handled = false;
         OnChange_Created (Created, Created, ref handled);
         handled = false;
         OnChange_Note (Note, Note, ref handled);
         handled = false;
         OnChange_Elements (Elements, Elements, ref handled);
         handled = false;

         Update (this, Created);
         Update (this, Note);
         Update (this, Elements);
      }
      // ----------------------------------------------------------------------


      // ----------------------------------------------------------------------
      public DateTime Created
      {
         get
         {
            return (DateTime) GetValue (CreatedProperty);
         }
         set
         {
            var currentValue = Created;

            if (currentValue != value)
            {
               SetValue (CreatedProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Created (DateTime oldValue, DateTime newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public string Note
      {
         get
         {
            return (string) GetValue (NoteProperty);
         }
         set
         {
            var currentValue = Note;

            if (currentValue != value)
            {
               SetValue (NoteProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Note (string oldValue, string newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public ObservableCollection<BaseElement> Elements
      {
         get
         {
            return (ObservableCollection<BaseElement>) GetValue (ElementsProperty);
         }
         set
         {
            var currentValue = Elements;

            if (currentValue != value)
            {
               SetValue (ElementsProperty, value);
            }
         }
      }
      // ----------------------------------------------------------------------
      partial void OnChange_Elements (ObservableCollection<BaseElement> oldValue, ObservableCollection<BaseElement> newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // *************************************************************************
   // MODEL COPIER
   // *************************************************************************

   // -------------------------------------------------------------------------
   public static partial class ModelCopier
   {
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      static void CopyImpl (
            ModelContext modelContext
         ,  Theme fromValue
         ,  Theme toValue
         )
         
      {
         CopyImpl (
               modelContext
            ,  (BaseModelEntity)fromValue
            ,  (BaseModelEntity)toValue
            );

         {        
            Size value;
            Copy (modelContext, fromValue.Dimension, out value);
            toValue.Dimension = value;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  ObservableCollection<Theme> fromValue
         ,  out ObservableCollection<Theme> toValue
         )
      {
         if (fromValue != null)
         {
            toValue = new ObservableCollection<Theme> ();

            foreach (var item in fromValue)
            {
               Theme value;
               Copy (modelContext, item, out value);
               toValue.Add (value);
            }
         }
         else
         {
            toValue = null;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  Theme fromValue
         ,  out Theme toValue
         )
      {
         toValue = new Theme (modelContext);
         CopyImpl (modelContext, fromValue, toValue);
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      static void CopyImpl (
            ModelContext modelContext
         ,  Presentation fromValue
         ,  Presentation toValue
         )
         
      {
         CopyImpl (
               modelContext
            ,  (BaseModelEntity)fromValue
            ,  (BaseModelEntity)toValue
            );

         {        
            string value;
            Copy (modelContext, fromValue.Name, out value);
            toValue.Name = value;
         }
         {        
            DateTime value;
            Copy (modelContext, fromValue.Created, out value);
            toValue.Created = value;
         }
         {        
            bool value;
            Copy (modelContext, fromValue.IsShowingNotes, out value);
            toValue.IsShowingNotes = value;
         }
         {        
            Theme value;
            Copy (modelContext, fromValue.CurrentTheme, out value);
            toValue.CurrentTheme = value;
         }
         {        
            Slide value;
            Copy (modelContext, fromValue.CurrentSlide, out value);
            toValue.CurrentSlide = value;
         }
         {        
            ObservableCollection<Slide> value;
            Copy (modelContext, fromValue.Slides, out value);
            toValue.Slides = value;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  ObservableCollection<Presentation> fromValue
         ,  out ObservableCollection<Presentation> toValue
         )
      {
         if (fromValue != null)
         {
            toValue = new ObservableCollection<Presentation> ();

            foreach (var item in fromValue)
            {
               Presentation value;
               Copy (modelContext, item, out value);
               toValue.Add (value);
            }
         }
         else
         {
            toValue = null;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  Presentation fromValue
         ,  out Presentation toValue
         )
      {
         toValue = new Presentation (modelContext);
         CopyImpl (modelContext, fromValue, toValue);
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      static void CopyImpl (
            ModelContext modelContext
         ,  BaseElement fromValue
         ,  BaseElement toValue
         )
         
      {
         CopyImpl (
               modelContext
            ,  (BaseModelEntity)fromValue
            ,  (BaseModelEntity)toValue
            );

         {        
            int value;
            Copy (modelContext, fromValue.ZIndex, out value);
            toValue.ZIndex = value;
         }
         {        
            int value;
            Copy (modelContext, fromValue.OpacityPercent, out value);
            toValue.OpacityPercent = value;
         }
         {        
            double value;
            Copy (modelContext, fromValue.Angle, out value);
            toValue.Angle = value;
         }
         {        
            double value;
            Copy (modelContext, fromValue.Left, out value);
            toValue.Left = value;
         }
         {        
            double value;
            Copy (modelContext, fromValue.Top, out value);
            toValue.Top = value;
         }
         {        
            double value;
            Copy (modelContext, fromValue.Width, out value);
            toValue.Width = value;
         }
         {        
            double value;
            Copy (modelContext, fromValue.Height, out value);
            toValue.Height = value;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  ObservableCollection<BaseElement> fromValue
         ,  out ObservableCollection<BaseElement> toValue
         )
      {
         if (fromValue != null)
         {
            toValue = new ObservableCollection<BaseElement> ();

            foreach (var item in fromValue)
            {
               BaseElement value;
               Copy (modelContext, item, out value);
               toValue.Add (value);
            }
         }
         else
         {
            toValue = null;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  BaseElement fromValue
         ,  out BaseElement toValue
         )
      {
         toValue = null;
         if (fromValue is TextElement)
         {
            TextElement value;
            Copy (
                  modelContext
               ,  (TextElement)fromValue
               ,  out value
               );
            toValue = value;
         }
         if (fromValue is PictureElement)
         {
            PictureElement value;
            Copy (
                  modelContext
               ,  (PictureElement)fromValue
               ,  out value
               );
            toValue = value;
         }
         if (fromValue is ShapeElement)
         {
            ShapeElement value;
            Copy (
                  modelContext
               ,  (ShapeElement)fromValue
               ,  out value
               );
            toValue = value;
         }
         if (fromValue is MovieElement)
         {
            MovieElement value;
            Copy (
                  modelContext
               ,  (MovieElement)fromValue
               ,  out value
               );
            toValue = value;
         }
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      static void CopyImpl (
            ModelContext modelContext
         ,  TextElement fromValue
         ,  TextElement toValue
         )
         
      {
         CopyImpl (
               modelContext
            ,  (BaseElement)fromValue
            ,  (BaseElement)toValue
            );

         {        
            Color value;
            Copy (modelContext, fromValue.BackgroundColor, out value);
            toValue.BackgroundColor = value;
         }
         {        
            Color value;
            Copy (modelContext, fromValue.ForegroundColor, out value);
            toValue.ForegroundColor = value;
         }
         {        
            string value;
            Copy (modelContext, fromValue.FontName, out value);
            toValue.FontName = value;
         }
         {        
            double value;
            Copy (modelContext, fromValue.FontSize, out value);
            toValue.FontSize = value;
         }
         {        
            string value;
            Copy (modelContext, fromValue.Text, out value);
            toValue.Text = value;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  ObservableCollection<TextElement> fromValue
         ,  out ObservableCollection<TextElement> toValue
         )
      {
         if (fromValue != null)
         {
            toValue = new ObservableCollection<TextElement> ();

            foreach (var item in fromValue)
            {
               TextElement value;
               Copy (modelContext, item, out value);
               toValue.Add (value);
            }
         }
         else
         {
            toValue = null;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  TextElement fromValue
         ,  out TextElement toValue
         )
      {
         toValue = new TextElement (modelContext);
         CopyImpl (modelContext, fromValue, toValue);
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      static void CopyImpl (
            ModelContext modelContext
         ,  PictureElement fromValue
         ,  PictureElement toValue
         )
         
      {
         CopyImpl (
               modelContext
            ,  (BaseElement)fromValue
            ,  (BaseElement)toValue
            );

         {        
            string value;
            Copy (modelContext, fromValue.PictureSource, out value);
            toValue.PictureSource = value;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  ObservableCollection<PictureElement> fromValue
         ,  out ObservableCollection<PictureElement> toValue
         )
      {
         if (fromValue != null)
         {
            toValue = new ObservableCollection<PictureElement> ();

            foreach (var item in fromValue)
            {
               PictureElement value;
               Copy (modelContext, item, out value);
               toValue.Add (value);
            }
         }
         else
         {
            toValue = null;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  PictureElement fromValue
         ,  out PictureElement toValue
         )
      {
         toValue = new PictureElement (modelContext);
         CopyImpl (modelContext, fromValue, toValue);
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      static void CopyImpl (
            ModelContext modelContext
         ,  ShapeElement fromValue
         ,  ShapeElement toValue
         )
         
      {
         CopyImpl (
               modelContext
            ,  (BaseElement)fromValue
            ,  (BaseElement)toValue
            );

         {        
            Color value;
            Copy (modelContext, fromValue.BackgroundColor, out value);
            toValue.BackgroundColor = value;
         }
         {        
            Color value;
            Copy (modelContext, fromValue.ForegroundColor, out value);
            toValue.ForegroundColor = value;
         }
         {        
            string value;
            Copy (modelContext, fromValue.Path, out value);
            toValue.Path = value;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  ObservableCollection<ShapeElement> fromValue
         ,  out ObservableCollection<ShapeElement> toValue
         )
      {
         if (fromValue != null)
         {
            toValue = new ObservableCollection<ShapeElement> ();

            foreach (var item in fromValue)
            {
               ShapeElement value;
               Copy (modelContext, item, out value);
               toValue.Add (value);
            }
         }
         else
         {
            toValue = null;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  ShapeElement fromValue
         ,  out ShapeElement toValue
         )
      {
         toValue = new ShapeElement (modelContext);
         CopyImpl (modelContext, fromValue, toValue);
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      static void CopyImpl (
            ModelContext modelContext
         ,  MovieElement fromValue
         ,  MovieElement toValue
         )
         
      {
         CopyImpl (
               modelContext
            ,  (BaseElement)fromValue
            ,  (BaseElement)toValue
            );

         {        
            string value;
            Copy (modelContext, fromValue.MovieSource, out value);
            toValue.MovieSource = value;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  ObservableCollection<MovieElement> fromValue
         ,  out ObservableCollection<MovieElement> toValue
         )
      {
         if (fromValue != null)
         {
            toValue = new ObservableCollection<MovieElement> ();

            foreach (var item in fromValue)
            {
               MovieElement value;
               Copy (modelContext, item, out value);
               toValue.Add (value);
            }
         }
         else
         {
            toValue = null;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  MovieElement fromValue
         ,  out MovieElement toValue
         )
      {
         toValue = new MovieElement (modelContext);
         CopyImpl (modelContext, fromValue, toValue);
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      static void CopyImpl (
            ModelContext modelContext
         ,  Slide fromValue
         ,  Slide toValue
         )
         
      {
         CopyImpl (
               modelContext
            ,  (BaseModelEntity)fromValue
            ,  (BaseModelEntity)toValue
            );

         {        
            DateTime value;
            Copy (modelContext, fromValue.Created, out value);
            toValue.Created = value;
         }
         {        
            string value;
            Copy (modelContext, fromValue.Note, out value);
            toValue.Note = value;
         }
         {        
            ObservableCollection<BaseElement> value;
            Copy (modelContext, fromValue.Elements, out value);
            toValue.Elements = value;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  ObservableCollection<Slide> fromValue
         ,  out ObservableCollection<Slide> toValue
         )
      {
         if (fromValue != null)
         {
            toValue = new ObservableCollection<Slide> ();

            foreach (var item in fromValue)
            {
               Slide value;
               Copy (modelContext, item, out value);
               toValue.Add (value);
            }
         }
         else
         {
            toValue = null;
         }
      }
      // ----------------------------------------------------------------------
      public static void Copy (
            ModelContext modelContext
         ,  Slide fromValue
         ,  out Slide toValue
         )
      {
         toValue = new Slide (modelContext);
         CopyImpl (modelContext, fromValue, toValue);
      }
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // *************************************************************************
   // SERIALIZABLE MODEL 
   // *************************************************************************

   // -------------------------------------------------------------------------
   namespace Serializable
   {
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static class Support
      {
         public static Type[] KnownTypes
         {
            get
            {
               return new Type[]
                  {
                     typeof (Theme),
                     typeof (Presentation),
                     typeof (BaseElement),
                     typeof (TextElement),
                     typeof (PictureElement),
                     typeof (ShapeElement),
                     typeof (MovieElement),
                     typeof (Slide),
                  };
            }
         }
      }
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      [DataContract]
      public class Theme
         : object
      {
         [DataMember]
         public Size Dimension {get; set;}
      }

      // ----------------------------------------------------------------------
      [DataContract]
      public class Presentation
         : object
      {
         [DataMember]
         public string Name {get; set;}
         [DataMember]
         public DateTime Created {get; set;}
         [DataMember]
         public bool IsShowingNotes {get; set;}
         [DataMember]
         public Theme CurrentTheme {get; set;}
         [DataMember]
         public Slide CurrentSlide {get; set;}
         [DataMember]
         public Slide[] Slides {get; set;}
      }

      // ----------------------------------------------------------------------
      [DataContract]
      public class BaseElement
         : object
      {
         [DataMember]
         public int ZIndex {get; set;}
         [DataMember]
         public int OpacityPercent {get; set;}
         [DataMember]
         public double Angle {get; set;}
         [DataMember]
         public double Left {get; set;}
         [DataMember]
         public double Top {get; set;}
         [DataMember]
         public double Width {get; set;}
         [DataMember]
         public double Height {get; set;}
      }

      // ----------------------------------------------------------------------
      [DataContract]
      public class TextElement
         : BaseElement
      {
         [DataMember]
         public Color BackgroundColor {get; set;}
         [DataMember]
         public Color ForegroundColor {get; set;}
         [DataMember]
         public string FontName {get; set;}
         [DataMember]
         public double FontSize {get; set;}
         [DataMember]
         public string Text {get; set;}
      }

      // ----------------------------------------------------------------------
      [DataContract]
      public class PictureElement
         : BaseElement
      {
         [DataMember]
         public string PictureSource {get; set;}
      }

      // ----------------------------------------------------------------------
      [DataContract]
      public class ShapeElement
         : BaseElement
      {
         [DataMember]
         public Color BackgroundColor {get; set;}
         [DataMember]
         public Color ForegroundColor {get; set;}
         [DataMember]
         public string Path {get; set;}
      }

      // ----------------------------------------------------------------------
      [DataContract]
      public class MovieElement
         : BaseElement
      {
         [DataMember]
         public string MovieSource {get; set;}
      }

      // ----------------------------------------------------------------------
      [DataContract]
      public class Slide
         : object
      {
         [DataMember]
         public DateTime Created {get; set;}
         [DataMember]
         public string Note {get; set;}
         [DataMember]
         public BaseElement[] Elements {get; set;}
      }
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
}

