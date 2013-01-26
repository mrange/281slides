using System.Windows.Controls.Primitives;
using System.Windows.Input;
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

namespace Presentation.Library.Behaviors
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
   public  partial class ItemsControlSupport
   {
      #region Dependency Properties for ItemsControlSupport
      public static readonly DependencyProperty ZIndexProperty = 
         DependencyProperty.RegisterAttached (
               "ZIndex"
            ,  typeof (int)
            ,  typeof (ItemsControlSupport)            
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
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (int)e.OldValue;
         var newValue = (int)e.NewValue;
         var handled = false;
         OnChange_ZIndex (dobj, oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static int GetZIndex (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (int) dobj.GetValue (ZIndexProperty);
         }
         else
         {
            return default (int);
         }
      }

      public static void SetZIndex (FrameworkElement dobj, int value)
      {
         if (dobj != null)
         {
            dobj.SetValue (ZIndexProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_ZIndex (FrameworkElement dobj, int oldValue, int newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class Selection
   {
      #region Dependency Properties for Selection
      public static readonly DependencyProperty HandlerProperty = 
         DependencyProperty.RegisterAttached (
               "Handler"
            ,  typeof (SelectionHandler)
            ,  typeof (Selection)            
            ,  new PropertyMetadata (
                  default (SelectionHandler)
               ,  OnChange_Handler
               )
            );

      static void OnChange_Handler (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Handler, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (SelectionHandler)e.OldValue;
         var newValue = (SelectionHandler)e.NewValue;
         var handled = false;
         OnChange_Handler (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty InstanceProperty = 
         DependencyProperty.RegisterAttached (
               "Instance"
            ,  typeof (DependencyObject)
            ,  typeof (Selection)            
            ,  new PropertyMetadata (
                  default (DependencyObject)
               ,  OnChange_Instance
               )
            );

      static void OnChange_Instance (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Instance, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (DependencyObject)e.OldValue;
         var newValue = (DependencyObject)e.NewValue;
         var handled = false;
         OnChange_Instance (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty SelectionVisibilityProperty = 
         DependencyProperty.RegisterAttached (
               "SelectionVisibility"
            ,  typeof (Visibility)
            ,  typeof (Selection)            
            ,  new PropertyMetadata (
                  Visibility.Collapsed
               ,  OnChange_SelectionVisibility
               )
            );

      static void OnChange_SelectionVisibility (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:SelectionVisibility, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Visibility)e.OldValue;
         var newValue = (Visibility)e.NewValue;
         var handled = false;
         OnChange_SelectionVisibility (dobj, oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static SelectionHandler GetHandler (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (SelectionHandler) dobj.GetValue (HandlerProperty);
         }
         else
         {
            return default (SelectionHandler);
         }
      }

      public static void SetHandler (FrameworkElement dobj, SelectionHandler value)
      {
         if (dobj != null)
         {
            dobj.SetValue (HandlerProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Handler (FrameworkElement dobj, SelectionHandler oldValue, SelectionHandler newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static DependencyObject GetInstance (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (DependencyObject) dobj.GetValue (InstanceProperty);
         }
         else
         {
            return default (DependencyObject);
         }
      }

      public static void SetInstance (FrameworkElement dobj, DependencyObject value)
      {
         if (dobj != null)
         {
            dobj.SetValue (InstanceProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Instance (FrameworkElement dobj, DependencyObject oldValue, DependencyObject newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static Visibility GetSelectionVisibility (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (Visibility) dobj.GetValue (SelectionVisibilityProperty);
         }
         else
         {
            return Visibility.Collapsed;
         }
      }

      public static void SetSelectionVisibility (FrameworkElement dobj, Visibility value)
      {
         if (dobj != null)
         {
            dobj.SetValue (SelectionVisibilityProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_SelectionVisibility (FrameworkElement dobj, Visibility oldValue, Visibility newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class Clip
   {
      #region Dependency Properties for Clip
      public static readonly DependencyProperty HandlerProperty = 
         DependencyProperty.RegisterAttached (
               "Handler"
            ,  typeof (ClipHandler)
            ,  typeof (Clip)            
            ,  new PropertyMetadata (
                  default (ClipHandler)
               ,  OnChange_Handler
               )
            );

      static void OnChange_Handler (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Handler, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ClipHandler)e.OldValue;
         var newValue = (ClipHandler)e.NewValue;
         var handled = false;
         OnChange_Handler (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty ToBoundsProperty = 
         DependencyProperty.RegisterAttached (
               "ToBounds"
            ,  typeof (bool)
            ,  typeof (Clip)            
            ,  new PropertyMetadata (
                  default (bool)
               ,  OnChange_ToBounds
               )
            );

      static void OnChange_ToBounds (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:ToBounds, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (bool)e.OldValue;
         var newValue = (bool)e.NewValue;
         var handled = false;
         OnChange_ToBounds (dobj, oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static ClipHandler GetHandler (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (ClipHandler) dobj.GetValue (HandlerProperty);
         }
         else
         {
            return default (ClipHandler);
         }
      }

      public static void SetHandler (FrameworkElement dobj, ClipHandler value)
      {
         if (dobj != null)
         {
            dobj.SetValue (HandlerProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Handler (FrameworkElement dobj, ClipHandler oldValue, ClipHandler newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static bool GetToBounds (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (bool) dobj.GetValue (ToBoundsProperty);
         }
         else
         {
            return default (bool);
         }
      }

      public static void SetToBounds (FrameworkElement dobj, bool value)
      {
         if (dobj != null)
         {
            dobj.SetValue (ToBoundsProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_ToBounds (FrameworkElement dobj, bool oldValue, bool newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class Command
   {
      #region Dependency Properties for Command
      public static readonly DependencyProperty InstanceProperty = 
         DependencyProperty.RegisterAttached (
               "Instance"
            ,  typeof (ICommand)
            ,  typeof (Command)            
            ,  new PropertyMetadata (
                  default (ICommand)
               ,  OnChange_Instance
               )
            );

      static void OnChange_Instance (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Instance, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as ButtonBase;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (ICommand)e.OldValue;
         var newValue = (ICommand)e.NewValue;
         var handled = false;
         OnChange_Instance (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty ParameterProperty = 
         DependencyProperty.RegisterAttached (
               "Parameter"
            ,  typeof (object)
            ,  typeof (Command)            
            ,  new PropertyMetadata (
                  default (object)
               ,  OnChange_Parameter
               )
            );

      static void OnChange_Parameter (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Parameter, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as DependencyObject;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (object)e.OldValue;
         var newValue = (object)e.NewValue;
         var handled = false;
         OnChange_Parameter (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty HandlerProperty = 
         DependencyProperty.RegisterAttached (
               "Handler"
            ,  typeof (CommandHandler)
            ,  typeof (Command)            
            ,  new PropertyMetadata (
                  default (CommandHandler)
               ,  OnChange_Handler
               )
            );

      static void OnChange_Handler (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Handler, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as ButtonBase;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (CommandHandler)e.OldValue;
         var newValue = (CommandHandler)e.NewValue;
         var handled = false;
         OnChange_Handler (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty HandlersProperty = 
         DependencyProperty.RegisterAttached (
               "Handlers"
            ,  typeof (CommandHandlers)
            ,  typeof (Command)            
            ,  new PropertyMetadata (
                  default (CommandHandlers)
               ,  OnChange_Handlers
               )
            );

      static void OnChange_Handlers (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Handlers, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as DependencyObject;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (CommandHandlers)e.OldValue;
         var newValue = (CommandHandlers)e.NewValue;
         var handled = false;
         OnChange_Handlers (dobj, oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static ICommand GetInstance (ButtonBase dobj)
      {
         if (dobj != null)
         {
            return (ICommand) dobj.GetValue (InstanceProperty);
         }
         else
         {
            return default (ICommand);
         }
      }

      public static void SetInstance (ButtonBase dobj, ICommand value)
      {
         if (dobj != null)
         {
            dobj.SetValue (InstanceProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Instance (ButtonBase dobj, ICommand oldValue, ICommand newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static object GetParameter (DependencyObject dobj)
      {
         if (dobj != null)
         {
            return (object) dobj.GetValue (ParameterProperty);
         }
         else
         {
            return default (object);
         }
      }

      public static void SetParameter (DependencyObject dobj, object value)
      {
         if (dobj != null)
         {
            dobj.SetValue (ParameterProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Parameter (DependencyObject dobj, object oldValue, object newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static CommandHandler GetHandler (ButtonBase dobj)
      {
         if (dobj != null)
         {
            return (CommandHandler) dobj.GetValue (HandlerProperty);
         }
         else
         {
            return default (CommandHandler);
         }
      }

      public static void SetHandler (ButtonBase dobj, CommandHandler value)
      {
         if (dobj != null)
         {
            dobj.SetValue (HandlerProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Handler (ButtonBase dobj, CommandHandler oldValue, CommandHandler newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static CommandHandlers GetHandlers (DependencyObject dobj)
      {
         if (dobj != null)
         {
            return (CommandHandlers) dobj.GetValue (HandlersProperty);
         }
         else
         {
            return default (CommandHandlers);
         }
      }

      public static void SetHandlers (DependencyObject dobj, CommandHandlers value)
      {
         if (dobj != null)
         {
            dobj.SetValue (HandlersProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Handlers (DependencyObject dobj, CommandHandlers oldValue, CommandHandlers newValue, ref bool handled);
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public  partial class MouseInteraction
   {
      #region Dependency Properties for MouseInteraction
      public static readonly DependencyProperty DraggingHandlerProperty = 
         DependencyProperty.RegisterAttached (
               "DraggingHandler"
            ,  typeof (MouseDraggingHandler)
            ,  typeof (MouseInteraction)            
            ,  new PropertyMetadata (
                  default (MouseDraggingHandler)
               ,  OnChange_DraggingHandler
               )
            );

      static void OnChange_DraggingHandler (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:DraggingHandler, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (MouseDraggingHandler)e.OldValue;
         var newValue = (MouseDraggingHandler)e.NewValue;
         var handled = false;
         OnChange_DraggingHandler (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty RotatingHandlerProperty = 
         DependencyProperty.RegisterAttached (
               "RotatingHandler"
            ,  typeof (MouseRotatingHandler)
            ,  typeof (MouseInteraction)            
            ,  new PropertyMetadata (
                  default (MouseRotatingHandler)
               ,  OnChange_RotatingHandler
               )
            );

      static void OnChange_RotatingHandler (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:RotatingHandler, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (MouseRotatingHandler)e.OldValue;
         var newValue = (MouseRotatingHandler)e.NewValue;
         var handled = false;
         OnChange_RotatingHandler (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty RootProperty = 
         DependencyProperty.RegisterAttached (
               "Root"
            ,  typeof (MouseRootType)
            ,  typeof (MouseInteraction)            
            ,  new PropertyMetadata (
                  default (MouseRootType)
               ,  OnChange_Root
               )
            );

      static void OnChange_Root (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Root, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (MouseRootType)e.OldValue;
         var newValue = (MouseRootType)e.NewValue;
         var handled = false;
         OnChange_Root (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty XProperty = 
         DependencyProperty.RegisterAttached (
               "X"
            ,  typeof (double)
            ,  typeof (MouseInteraction)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_X
               )
            );

      static void OnChange_X (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:X, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         OnChange_X (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty YProperty = 
         DependencyProperty.RegisterAttached (
               "Y"
            ,  typeof (double)
            ,  typeof (MouseInteraction)            
            ,  new PropertyMetadata (
                  default (double)
               ,  OnChange_Y
               )
            );

      static void OnChange_Y (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Y, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         OnChange_Y (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty AngleProperty = 
         DependencyProperty.RegisterAttached (
               "Angle"
            ,  typeof (double)
            ,  typeof (MouseInteraction)            
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
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (double)e.OldValue;
         var newValue = (double)e.NewValue;
         var handled = false;
         OnChange_Angle (dobj, oldValue, newValue, ref handled);
      }

      public static readonly DependencyProperty OffsetProperty = 
         DependencyProperty.RegisterAttached (
               "Offset"
            ,  typeof (Point)
            ,  typeof (MouseInteraction)            
            ,  new PropertyMetadata (
                  default (Point)
               ,  OnChange_Offset
               )
            );

      static void OnChange_Offset (DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
#if DEBUG
         Debug.WriteLine ("ModelProperty.Change : Prop:Offset, Old:{0}, New:{1}, Instance:{2}({3})", e.OldValue, e.NewValue, d.SafeGetHashCode (), d.SafeGetTypeName ());
#endif
         var dobj = d as FrameworkElement;
         if (dobj == null)
         {
            return;
         }

         var oldValue = (Point)e.OldValue;
         var newValue = (Point)e.NewValue;
         var handled = false;
         OnChange_Offset (dobj, oldValue, newValue, ref handled);
      }

      #endregion
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static MouseDraggingHandler GetDraggingHandler (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (MouseDraggingHandler) dobj.GetValue (DraggingHandlerProperty);
         }
         else
         {
            return default (MouseDraggingHandler);
         }
      }

      public static void SetDraggingHandler (FrameworkElement dobj, MouseDraggingHandler value)
      {
         if (dobj != null)
         {
            dobj.SetValue (DraggingHandlerProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_DraggingHandler (FrameworkElement dobj, MouseDraggingHandler oldValue, MouseDraggingHandler newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static MouseRotatingHandler GetRotatingHandler (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (MouseRotatingHandler) dobj.GetValue (RotatingHandlerProperty);
         }
         else
         {
            return default (MouseRotatingHandler);
         }
      }

      public static void SetRotatingHandler (FrameworkElement dobj, MouseRotatingHandler value)
      {
         if (dobj != null)
         {
            dobj.SetValue (RotatingHandlerProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_RotatingHandler (FrameworkElement dobj, MouseRotatingHandler oldValue, MouseRotatingHandler newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static MouseRootType GetRoot (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (MouseRootType) dobj.GetValue (RootProperty);
         }
         else
         {
            return default (MouseRootType);
         }
      }

      public static void SetRoot (FrameworkElement dobj, MouseRootType value)
      {
         if (dobj != null)
         {
            dobj.SetValue (RootProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Root (FrameworkElement dobj, MouseRootType oldValue, MouseRootType newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static double GetX (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (double) dobj.GetValue (XProperty);
         }
         else
         {
            return default (double);
         }
      }

      public static void SetX (FrameworkElement dobj, double value)
      {
         if (dobj != null)
         {
            dobj.SetValue (XProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_X (FrameworkElement dobj, double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static double GetY (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (double) dobj.GetValue (YProperty);
         }
         else
         {
            return default (double);
         }
      }

      public static void SetY (FrameworkElement dobj, double value)
      {
         if (dobj != null)
         {
            dobj.SetValue (YProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Y (FrameworkElement dobj, double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static double GetAngle (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (double) dobj.GetValue (AngleProperty);
         }
         else
         {
            return default (double);
         }
      }

      public static void SetAngle (FrameworkElement dobj, double value)
      {
         if (dobj != null)
         {
            dobj.SetValue (AngleProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Angle (FrameworkElement dobj, double oldValue, double newValue, ref bool handled);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public static Point GetOffset (FrameworkElement dobj)
      {
         if (dobj != null)
         {
            return (Point) dobj.GetValue (OffsetProperty);
         }
         else
         {
            return default (Point);
         }
      }

      public static void SetOffset (FrameworkElement dobj, Point value)
      {
         if (dobj != null)
         {
            dobj.SetValue (OffsetProperty, value);
         }
      }
      // ----------------------------------------------------------------------
      static partial void OnChange_Offset (FrameworkElement dobj, Point oldValue, Point newValue, ref bool handled);
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


