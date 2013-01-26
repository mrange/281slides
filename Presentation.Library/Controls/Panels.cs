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

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Presentation.Library.Utility;

namespace Presentation.Library.Controls
{
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public enum LayoutItemState
   {
      IsMeasuring,
      IsArranging,
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public class LayoutItemEventArgs : EventArgs
   {
      public LayoutItemState LayoutItemState;
      public UIElement UiElement;
      public object AccumulateState;
      public object State;
      public Size AvailableSize;
      public Size DesiredSize;
      public int Count;
      public int Index;
      public Transform Transform;
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public partial class AnimatedWrapPanel : BaseAnimatedPanel
   {
      sealed class AnimatedWrapPanelItemState
      {
         public TranslateTransform TranslateTransform;
      }

      sealed class WrapPanelAccumulatedItemState : IDisposable
      {
         public WrapPanelAccumulatedItemState (
            LayoutItemState layoutItemState,
            TimeSpan animationDuration
            )
         {
            if (layoutItemState == LayoutItemState.IsArranging)
            {
               ShowStoryboard = 
                  new Storyboard
                     {
                        Duration = animationDuration,
                     };
            }
         }

         public readonly Storyboard ShowStoryboard;

         public double X;
         public double Y;
         public double NextX;
         public double NextY;

         public void Dispose ()
         {
            if (ShowStoryboard != null)
            {
               ShowStoryboard.Begin ();
            }
         }
      }

      partial void OnChange_Orientation (Orientation oldValue, Orientation newValue, ref bool handled)
      {
         InvalidateMeasure ();
         handled = true;
      }

      protected override void OnItemLayout (LayoutItemEventArgs args)
      {
         AnimatedWrapPanelItemState state;

         var accuState =
            args.AccumulateState as WrapPanelAccumulatedItemState
            ?? new WrapPanelAccumulatedItemState (args.LayoutItemState, AnimationDuration);

         if (Orientation == Orientation.Vertical)
         {
            if (accuState.NextY + args.DesiredSize.Height > args.AvailableSize.Height)
            {
               accuState.X = accuState.NextX;
               accuState.Y = 0;
               accuState.NextX = 0;
            }
            else
            {
               accuState.Y = accuState.NextY;
            }

            accuState.NextX = Math.Max (accuState.NextX, accuState.X + args.DesiredSize.Width);
            accuState.NextY = accuState.Y + args.DesiredSize.Height;
         }
         else
         {
            if (accuState.NextX + args.DesiredSize.Width > args.AvailableSize.Width)
            {
               accuState.X = 0;
               accuState.Y = accuState.NextY;
               accuState.NextY = 0;
            }
            else
            {
               accuState.X = accuState.NextX;
            }

            accuState.NextX = accuState.X + args.DesiredSize.Width;
            accuState.NextY = Math.Max (accuState.NextY, accuState.Y + args.DesiredSize.Height);
         }

         args.AccumulateState = accuState;

         var newX = accuState.X;
         var newY = accuState.Y;

         switch (args.LayoutItemState)
         {
            case LayoutItemState.IsMeasuring:
               state = 
                  new AnimatedWrapPanelItemState
                     {
                        TranslateTransform = 
                           new TranslateTransform
                           {
                              X = newX,
                              Y = newY,
                           },
                     };
               break;
            case LayoutItemState.IsArranging:
               state = args.State as AnimatedWrapPanelItemState;

               if (state == null)
               {
                  state = 
                     new AnimatedWrapPanelItemState
                        {
                           TranslateTransform = 
                              new TranslateTransform
                              {
                                 X = newX,
                                 Y = newY,
                              },
                        };

                  AnimateOpacity (args, accuState);
               }
               else if (
                     newX != state.TranslateTransform.X 
                  || newY != state.TranslateTransform.Y 
                  )
               {
                  AnimateOpacity (args, accuState);
               }

               if (newX != state.TranslateTransform.X)
               {
                  accuState.ShowStoryboard.AnimateProperty (
                     state.TranslateTransform,
                     TranslateTransform.XProperty,
                     TimeSpan.Zero,
                     newX
                     );
               }

               if (newY != state.TranslateTransform.Y)
               {
                  accuState.ShowStoryboard.AnimateProperty (
                     state.TranslateTransform,
                     TranslateTransform.YProperty,
                     TimeSpan.Zero,
                     newY
                     );
               }

               break;
            default:
               throw new ArgumentOutOfRangeException ();
         }
         args.State = state;
         args.Transform = state.TranslateTransform;
      }

      void AnimateOpacity (LayoutItemEventArgs args, WrapPanelAccumulatedItemState accuState)
      {
         args.UiElement.Opacity = 0;

         accuState.ShowStoryboard.AnimateProperty (
            args.UiElement,
            OpacityProperty,
            AnimationDuration,
            1.0,
            0.0
            );
      }
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public abstract partial class BaseAnimatedPanel : BasePanel
   {
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
   public partial class BasePanel : Panel
   {
      static readonly Transform s_identityTransform = new ScaleTransform ();

      protected abstract void OnItemLayout (LayoutItemEventArgs layoutItemEventArgs);

      protected override Size MeasureOverride (Size availableSize)
      {
         if (Children == null || Children.Count < 1)
         {
            return new Size (0, 0);
         }

         var resultingRect = new Rect ();

         object accumulatedState = null;
         try 
         {
            var count = Children.Count;
            for (var iter = 0; iter < count; ++iter)
            {
               var child = Children[iter];
               child.Measure (availableSize);
               var desiredSize = child.DesiredSize;
               var args = new LayoutItemEventArgs
               {
                  LayoutItemState = LayoutItemState.IsMeasuring,
                  UiElement = child,
                  AccumulateState = accumulatedState,
                  State = GetUIElementState (child),
                  AvailableSize = availableSize,
                  DesiredSize = desiredSize,
                  Count = count,
                  Index = iter,
                  Transform = child.RenderTransform,
               };

               OnItemLayout (args);

               accumulatedState = args.AccumulateState;
               var childRect = (args.Transform ?? s_identityTransform).TransformBounds (new Rect (0, 0, desiredSize.Width, desiredSize.Height));
               resultingRect.Union (childRect);
            }

            return availableSize.Merge (resultingRect.ToSize ());
         }
         finally
         {
            Common.Dispose (accumulatedState);
         }
      }

      protected override Size ArrangeOverride (Size finalSize)
      {
         if (Children == null || Children.Count < 1)
         {
            return finalSize;
         }

         object accumulatedState = null;
         try 
         {
            var count = Children.Count;
            for (var iter = 0; iter < Children.Count; ++iter)
            {
               var child = Children[iter];
               var desiredSize = child.DesiredSize;
               var args = new LayoutItemEventArgs
               {
                  LayoutItemState = LayoutItemState.IsArranging,
                  UiElement = child,
                  AccumulateState = accumulatedState,
                  State = GetUIElementState (child),
                  AvailableSize = finalSize,
                  DesiredSize = desiredSize,
                  Count = count,
                  Index = iter,
                  Transform = child.RenderTransform,
               };

               OnItemLayout (args);

               accumulatedState = args.AccumulateState;
               child.RenderTransform = args.Transform ?? s_identityTransform;
               SetUIElementState (child, args.State);
               child.Arrange (new Rect (0, 0, child.DesiredSize.Width, child.DesiredSize.Height));
            }

            return finalSize;
            }
         finally
         {
            Common.Dispose (accumulatedState);
         }
      }
   }
   // -------------------------------------------------------------------------

   // -------------------------------------------------------------------------
}
