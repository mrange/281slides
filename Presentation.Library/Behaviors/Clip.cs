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
using System.Windows;
using System.Windows.Media;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Behaviors
{
   public sealed partial class Clip
   {
      public sealed class ClipHandler : BaseAttachedState
      {
         public ClipHandler (FrameworkElement attachedObject) : base (attachedObject)
         {
         }

         public void ClipToBounds ()
         {
            if (GetToBounds (AttachedObject))
            {
               AttachedObject.Clip = new RectangleGeometry
                  {
                     Rect = new Rect (0, 0, AttachedObject.ActualWidth, AttachedObject.ActualHeight)
                  };
            }
            else
            {
               AttachedObject.Clip = null;
            }
         }

         protected override void OnAttached ()
         {
            AttachedObject.SizeChanged += SizeChanged;
            ClipToBounds ();
         }

         void SizeChanged (object sender, SizeChangedEventArgs e)
         {
            ClipToBounds ();
         }
      }

      static partial void OnChange_ToBounds (FrameworkElement dobj, bool oldValue, bool newValue, ref bool handled)
      {
         var handler = Setup (dobj);
         handler.ClipToBounds ();
      }

      static ClipHandler Setup (FrameworkElement dobj)
      {
         var handler = GetHandler (dobj);
         if (handler == null)
         {
            handler = new ClipHandler (dobj);
            SetHandler (dobj, handler);
         }
         return handler;
      }
   }
}
