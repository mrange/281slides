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
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Behaviors
{
   public sealed partial class Command
   {
      public sealed class CommandHandlers : IDisposable
      {
         readonly DispatcherTimer m_updateCommands = new DispatcherTimer ();
         readonly IDictionary<Type,IDictionary<CommandHandler, bool>> m_commandHandlers =
            new Dictionary<Type, IDictionary<CommandHandler, bool>> ();

         public CommandHandlers ()
         {
            m_updateCommands.Tick += UpdateCommands;
            m_updateCommands.Interval = new TimeSpan (0,0,0,0,100);
            m_updateCommands.Start ();
         }

         void UpdateCommands (object sender, EventArgs e)
         {
            foreach (var commandHandler in m_commandHandlers.SelectMany (hnd => hnd.Value))
            {
               commandHandler.Key.CanExecuteChanged (sender, e);
            }
         }

         public void ExecuteCommand (
            object sender,
            ExecuteCommandEventArgs executeCommandEventArgs)
         {
            var type = executeCommandEventArgs.CommandType;
            var handlers = m_commandHandlers.LookupOrAdd (type, () => new Dictionary<CommandHandler, bool> ());
            foreach (var handler in handlers)
            {
               handler.Key.Execute (sender, executeCommandEventArgs);
            }
         }

         public void Register (CommandHandler commandHandler)
         {
            var type = commandHandler.CommandType;
            var handlers = m_commandHandlers.LookupOrAdd (type, () => new Dictionary<CommandHandler, bool> ());
            handlers[commandHandler] = true;
         }

         public void Unregister (CommandHandler commandHandler)
         {
            var type = commandHandler.CommandType;
            var handlers = m_commandHandlers.LookupOrAdd (type, () => new Dictionary<CommandHandler, bool> ());
            handlers.Remove (commandHandler);
         }

         public void Dispose ()
         {
            m_updateCommands.Stop ();
         }
      }

      public sealed class CommandHandler
      {
         readonly ButtonBase m_buttonBase;
         readonly ICommand m_command;

         public Type CommandType
         {
            get
            {
               return m_command.GetType ();
            }
         }

         public CommandHandler (ButtonBase buttonBase, ICommand command)
         {
            m_buttonBase = buttonBase;
            m_command = command;
         }

         public void CanExecuteChanged (object sender, EventArgs e)
         {
            if (m_buttonBase != null)
            {
               var parameter = GetParameter (sender as DependencyObject);
               m_buttonBase.IsEnabled = m_command.CanExecute (parameter);
            }
         }
         
         public void Execute (object sender, EventArgs e)
         {
            var parameter = GetParameter (sender as DependencyObject);
            if (m_command.CanExecute (parameter))
            {
               m_command.Execute (parameter);
            }
         }
      }

      static partial void OnChange_Handlers (DependencyObject dobj, CommandHandlers oldValue, CommandHandlers newValue, ref bool handled)
      {
         if (dobj.IsRoot () && oldValue != null)
         {
            oldValue.Dispose ();
         }
      }

      static partial void OnChange_Instance (
         ButtonBase dobj, 
         ICommand oldValue, 
         ICommand newValue, 
         ref bool handled
         )
      {
         if (dobj != null)
         {
            var handlers = GetOrCreateHandlers (dobj);

            var oldHandler = GetHandler (dobj);
            if (oldValue != null && oldHandler != null)
            {
               handlers.Unregister (oldHandler);
               dobj.Click -= oldHandler.Execute;
               oldValue.CanExecuteChanged -= oldHandler.CanExecuteChanged;
            }

            if (newValue != null)
            {
               var newHandler = new CommandHandler (dobj, newValue);
               SetHandler (dobj, newHandler);
               dobj.Click += newHandler.Execute;
               newValue.CanExecuteChanged += newHandler.CanExecuteChanged;
               handlers.Register (newHandler);
            }
            else
            {
               dobj.IsEnabled = false;
            }
         }
         handled = true;
      }

      public static CommandHandlers GetOrCreateHandlers (DependencyObject dependencyObject)
      {
         var handlers = GetHandlers (dependencyObject);

         if (handlers == null)
         {
            var root = dependencyObject.GetRoot ();

            handlers = GetHandlers (root);

            if (handlers == null)
            {
               handlers = new CommandHandlers ();
               SetHandlers (root, handlers);
            }

            SetHandlers (dependencyObject, handlers);
         }

         return handlers;
      }

   }

   public class ExecuteCommandEventArgs : EventArgs
   {
      public Type CommandType;
      public object Parameter;
   }

   public static class ExtensionCommand
   {
      public static void ExecuteCommand<TCommand> (
         this UIElement uiElement
         )
      {
         if (uiElement == null)
         {
            return;
         }

         var root = uiElement.GetRoot ();

         var handlers = Command.GetHandlers (root);

         if (handlers == null)
         {
            return;
         }

         handlers.ExecuteCommand (
            uiElement, 
            new ExecuteCommandEventArgs
            {
               CommandType = typeof (TCommand),
            });
      }
   }
}
