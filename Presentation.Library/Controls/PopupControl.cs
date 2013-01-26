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
using System.Windows.Controls;
using Presentation.Library.Behaviors;
using Presentation.Library.Utility;

namespace Presentation.Library.Controls
{
   public delegate void PopupControlCompletionDelegate (object content, object parameter); 

   public sealed partial class PopupControl : ContentControl
   {
      PopupControlCompletionDelegate m_onComplete;

      public PopupControl ()
      {
         DefaultStyleKey = typeof (PopupControl);
         Loaded += PopupControl_Loaded;
      }

      protected override void OnContentChanged (object oldContent, object newContent)
      {
         var ctr = newContent as Control;

         if (ctr != null)
         {
            ctr.Focus ();
         }

         base.OnContentChanged (oldContent, newContent);
      }

      void PopupControl_Loaded (object sender, RoutedEventArgs e)
      {
         var handlers = Command.GetOrCreateHandlers (this);
         handlers.Register (
            new Command.CommandHandler (
               null,
               CloseCommand));
      }

      public void Show (
         object content,
         PopupControlCompletionDelegate onComplete
         )
      {
         m_onComplete = onComplete;
         Content = content;
         Visibility = Visibility.Visible;

         Focus ();
      }

      partial void Command_Close (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = true;
         if (commandType == CommandType.Execute)
         {
            Visibility = Visibility.Collapsed;
            Content = null;
            if (m_onComplete != null)
            {
               var onComplete = m_onComplete;
               m_onComplete = null;
               onComplete (this, parameter);
            }
         }
      }

   }
}
