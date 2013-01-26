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
using System.Windows.Input;
using Presentation.Library.Controls;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Behaviors
{

   public enum MouseRootType
   {
      Ignore,
      ListenTo,
      TransformTo,
   }

   public sealed partial class MouseInteraction
   {
      public abstract class BaseMouseHandler : BaseAttachedState
      {
         public UIElement ListenTo;
         public UIElement TransformTo;

         protected BaseMouseHandler (FrameworkElement attachedObject) 
            :  base (attachedObject)
         {
         }

         protected override void OnAttached ()
         {
            ListenTo = AttachedObject.FindParentInclusive (uiElement => 
               GetRoot (uiElement as FrameworkElement) == MouseRootType.ListenTo);
            TransformTo = AttachedObject.FindParentInclusive (uiElement => 
               GetRoot (uiElement as FrameworkElement) == MouseRootType.TransformTo);
            if (ListenTo == null)
            {
               ListenTo = AttachedObject.GetRoot ();
            }

            AttachedObject.MouseLeftButtonDown += MouseLeftButtonDown;
         }

         void MouseLeftButtonDown (object sender, MouseButtonEventArgs e)
         {
            AddHandlers (e);
         }

         void AddHandlers (MouseButtonEventArgs mouseButtonEventArgs)
         {
            OnAddHandlers (mouseButtonEventArgs);

            ListenTo.MouseLeave += ListenToMouseLeave;
            ListenTo.MouseMove += ListenToMouseMove;

            MouseButtonEventHandler listenLeftButtonUp = ListenLeftButtonUp;
            ListenTo.AddHandler (UIElement.MouseLeftButtonUpEvent, listenLeftButtonUp, true);
         }

         protected abstract void OnAddHandlers (MouseEventArgs mouseEventArgs);

         void RemoveHandlers (MouseEventArgs mouseEventArgs)
         {
            MouseButtonEventHandler rootMouseLeftButtonUp = ListenLeftButtonUp;
            ListenTo.RemoveHandler (UIElement.MouseLeftButtonUpEvent, rootMouseLeftButtonUp);

            ListenTo.MouseMove -= ListenToMouseMove;
            ListenTo.MouseLeave -= ListenToMouseLeave;

            OnRemoveHandlers (mouseEventArgs);
         }

         protected abstract void OnRemoveHandlers (MouseEventArgs mouseEventArgs);

         void ListenToMouseMove (object sender, MouseEventArgs e)
         {
            OnMouseMove (e);
         }

         protected abstract void OnMouseMove (MouseEventArgs mouseEventArgs);

         void ListenLeftButtonUp (object sender, MouseButtonEventArgs e)
         {
            RemoveHandlers (e);
         }

         void ListenToMouseLeave (object sender, MouseEventArgs e)
         {
            RemoveHandlers (e);
         }

      }

      public sealed class MouseDraggingHandler : BaseMouseHandler
      {
         double m_oldX;
         double m_oldY;

         public MouseDraggingHandler (FrameworkElement attachedObject) 
            : base (attachedObject)
         {
         }

         protected override void OnAddHandlers (MouseEventArgs mouseEventArgs)
         {
            m_oldX = GetX (AttachedObject);
            m_oldY = GetY (AttachedObject);

            ListenTo.ExecuteCommand<PresentationControl.PauseChangeTrackingCommandType>();
         }

         protected override void OnRemoveHandlers (MouseEventArgs mouseEventArgs)
         {
            var x = GetX (AttachedObject);
            var y = GetY (AttachedObject);

            // This will force an update to the change after we resumed change tracking
            SetX (AttachedObject, m_oldX);
            SetY (AttachedObject, m_oldY);

            ListenTo.ExecuteCommand<PresentationControl.ResumeChangeTrackingCommandType>();

            SetX (AttachedObject, x);
            SetY (AttachedObject, y);
         }

         protected override void OnMouseMove (MouseEventArgs mouseEventArgs)
         {
            var p = mouseEventArgs.GetPosition (TransformTo ?? ListenTo);
            SetX (AttachedObject, p.X);
            SetY (AttachedObject, p.Y);
         }

      }

      public sealed class MouseRotatingHandler : BaseMouseHandler
      {
         double m_oldAngle;
         Point m_oldPoint;
         Point m_center;

         public MouseRotatingHandler (FrameworkElement attachedObject) 
            : base (attachedObject)
         {
         }

         protected override void OnAddHandlers (MouseEventArgs mouseEventArgs)
         {
            m_oldAngle = GetAngle (AttachedObject);
            var offset = GetOffset (AttachedObject);
            var transform = (TransformTo ?? ListenTo).TransformToVisual (ListenTo);
            var point = mouseEventArgs.GetPosition (TransformTo ?? ListenTo);
            m_oldPoint = transform.Transform (point);
            m_center = transform.Transform (point.Add (offset));
            ListenTo.ExecuteCommand<PresentationControl.PauseChangeTrackingCommandType>();
         }

         protected override void OnRemoveHandlers (MouseEventArgs mouseEventArgs)
         {
            var angle = GetAngle (AttachedObject);

            // This will force an update to the chnange after we resumed change tracking
            SetAngle (AttachedObject, m_oldAngle);

            ListenTo.ExecuteCommand<PresentationControl.ResumeChangeTrackingCommandType>();

            SetAngle (AttachedObject, angle);
         }

         protected override void OnMouseMove (MouseEventArgs mouseEventArgs)
         {
            // TODO: This code isn't working perfectly yet
            var p = mouseEventArgs.GetPosition (ListenTo);
            
            var newDiff = p.Subtract (m_center);
            var oldDiff = m_oldPoint.Subtract (m_center);

            var normalToOld = oldDiff.NormalTo ();
            var m = -normalToOld.Dot (m_center);

            var side = normalToOld.Dot (p) + m;

            var result = newDiff.Dot (oldDiff) / (newDiff.Length () * oldDiff.Length ());

            var angle = Math.Acos (result) * 180 / Math.PI;
            var newAngle = (side > 0 ? -angle : angle) + m_oldAngle;

            SetAngle (AttachedObject, newAngle);
         }
      }

      static void SetupDragging (FrameworkElement dobj)
      {
         var handler = GetDraggingHandler (dobj);
         if (handler == null)
         {
            handler = new MouseDraggingHandler (dobj);
            SetDraggingHandler (dobj, handler);
         }
      }

      static void SetupRotating (FrameworkElement dobj)
      {
         var handler = GetRotatingHandler (dobj);
         if (handler == null)
         {
            handler = new MouseRotatingHandler (dobj);
            SetRotatingHandler (dobj, handler);
         }
      }

      static partial void OnChange_X (FrameworkElement dobj, double oldValue, double newValue, ref bool handled)
      {
         SetupDragging (dobj);
         handled = true;
      }

      static partial void OnChange_Y (FrameworkElement dobj, double oldValue, double newValue, ref bool handled)
      {
         SetupDragging (dobj);
         handled = true;
      }

      static partial void OnChange_Angle (FrameworkElement dobj, double oldValue, double newValue, ref bool handled)
      {
         SetupRotating (dobj);
         handled = true;
      }

      static partial void OnChange_Offset (FrameworkElement dobj, Point oldValue, Point newValue, ref bool handled)
      {
         SetupRotating (dobj);
         handled = true;
      }

   }
}
