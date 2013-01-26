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
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Presentation.Library.Behaviors;
using Presentation.Library.Utility;

namespace Presentation.Library.Controls
{
   public partial class PresentControl : Control
   {
      enum State
      {
         Start,
         ShowingFirst,
         ShowingSecond,
         Finished,
      }

      State m_state = State.Start;
      PresentingSlideControl m_first;
      PresentingSlideControl m_second;


      Storyboard m_showFirstStoryboard;
      Storyboard m_hideFirstStoryboard;
      Storyboard m_showSecondStoryboard;
      Storyboard m_hideSecondStoryboard;

      public PresentControl ()
      {
         DefaultStyleKey = typeof (PresentControl);

         KeyEventHandler keyDown = PresentControl_KeyDown;
         AddHandler (KeyDownEvent, keyDown, true);

         MouseButtonEventHandler mouseButtonDown = PresentControl_MouseButtonDown;
         AddHandler (MouseLeftButtonDownEvent, mouseButtonDown, true);
      }

      void PresentControl_MouseButtonDown (object sender, MouseButtonEventArgs e)
      {
         GotoNextSlide (1);
      }

      public override void OnApplyTemplate ()
      {
         var timeSpan = new TimeSpan (0,0,0,1);

         m_first = GetTemplateChild ("REQUIRED_FOR_FIRST_ANIMATION") as PresentingSlideControl;
         m_second = GetTemplateChild ("REQUIRED_FOR_SECOND_ANIMATION") as PresentingSlideControl;

         if (m_first != null)
         {
            m_first.Opacity = 0;

            m_showFirstStoryboard = new Storyboard ();
            m_showFirstStoryboard.AnimateProperty (
               m_first,
               OpacityProperty,
               timeSpan,
               1.0
               );

            m_hideFirstStoryboard = new Storyboard ();
            m_hideFirstStoryboard.AnimateProperty (
               m_first,
               OpacityProperty,
               timeSpan,
               0.0
               );
         }

         if (m_second != null)
         {
            m_second.Opacity = 0;

            m_showSecondStoryboard = new Storyboard ();
            m_showSecondStoryboard.AnimateProperty (
               m_second,
               OpacityProperty,
               timeSpan,
               1.0
               );

            m_hideSecondStoryboard = new Storyboard ();
            m_hideSecondStoryboard.AnimateProperty (
               m_second,
               OpacityProperty,
               timeSpan,
               0.0
               );
         }

         base.OnApplyTemplate ();
      }

      void PresentControl_KeyDown (object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Escape)
         {
            this.ExecuteCommand<PopupControl.CloseCommandType>();
         }

         if (e.Key == Key.Up)
         {
            GotoNextSlide (-1);
         }

         if (e.Key == Key.Down)
         {
            GotoNextSlide (1);
         }
      }

      void GotoNextSlide (int i)
      {
         if (Presentation == null || Presentation.Slides == null)
         {
            CurrentSlide = null;
            m_first.Slide = null;
            m_second.Slide = null;
            return;
         }

         switch (m_state)
         {
            case State.Start:
               CurrentSlide = Presentation.Slides.FirstOrDefault ();
               if (CurrentSlide != null)
               {
                  m_first.Slide = CurrentSlide;
                  m_second.Slide = null;
                  m_showFirstStoryboard.Begin ();
                  m_state = State.ShowingFirst;
               }
               break;
            case State.ShowingFirst:
               ShowHideSlide (
                  i, 
                  m_second, 
                  m_hideFirstStoryboard, 
                  m_showSecondStoryboard, 
                  State.ShowingSecond);
               break;
            case State.ShowingSecond:
               ShowHideSlide (
                  i, 
                  m_first, 
                  m_hideSecondStoryboard, 
                  m_showFirstStoryboard, 
                  State.ShowingFirst);
               break;
            case State.Finished:
               this.ExecuteCommand<PopupControl.CloseCommandType>();
               break;
            default:
               throw new ArgumentOutOfRangeException ();
         }
      }

      void ShowHideSlide (
         int i, 
         PresentingSlideControl showPresenter, 
         Storyboard hideStoryboard, 
         Storyboard showStoryboard, 
         State nextState
         )
      {
         var currentIndex = Presentation.Slides.IndexOf (CurrentSlide);
         var nextIndex = currentIndex + i;
         if (
            currentIndex < 0 
            || !nextIndex.Between (0, Presentation.Slides.Count - 1)
            )
         {
            CurrentSlide = null;
            showPresenter.Slide = null;
            hideStoryboard.Begin ();
            m_state = i > 0 ? State.Finished : State.Start;
         }
         else
         {
            CurrentSlide = Presentation.Slides[nextIndex];
            showPresenter.Slide = CurrentSlide;
            hideStoryboard.Begin ();
            showStoryboard.Begin ();
            m_state = nextState;
         }
      }
   }
}
