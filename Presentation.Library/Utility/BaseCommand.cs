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
using System.Windows.Input;

namespace Presentation.Library.Utility
{
   public enum CommandType
   {
      CanExecute,
      Execute,
   }

   public abstract class BaseCommand : ICommand
   {
      readonly Func<CommandType, object, bool> m_commandAction;

      protected BaseCommand (
            Func<CommandType, object, bool> commandAction
         )
      {
         m_commandAction = commandAction;
      }

      public bool CanExecute (object parameter)
      {
         return m_commandAction (CommandType.CanExecute, parameter);
      }

      public void Execute (object parameter)
      {
         m_commandAction (CommandType.Execute, parameter);
      }

      public void RaiseCanExecuteChanged ()
      {
         var canExecuteChanged = CanExecuteChanged;
         if (canExecuteChanged != null)
         {
            canExecuteChanged (this, new EventArgs ());
         }
      }

      public event EventHandler CanExecuteChanged;
   }
}
