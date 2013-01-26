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
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConvertIfStatementToNullCoalescingExpression

namespace Presentation.Library.Model
{
   using Utility;
   using System;
   using System.Windows.Input;
   partial class Presentation
   {
      #region Commands for Presentation

      NewSlideCommandType m_cmdNewSlide;

      bool Command_NewSlide (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_NewSlide (commandType, parameter, ref canExecute);
         return canExecute;
      }

      DuplicateSlideCommandType m_cmdDuplicateSlide;

      bool Command_DuplicateSlide (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_DuplicateSlide (commandType, parameter, ref canExecute);
         return canExecute;
      }

      DeleteSlideCommandType m_cmdDeleteSlide;

      bool Command_DeleteSlide (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_DeleteSlide (commandType, parameter, ref canExecute);
         return canExecute;
      }

      UndoCommandType m_cmdUndo;

      bool Command_Undo (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_Undo (commandType, parameter, ref canExecute);
         return canExecute;
      }

      RedoCommandType m_cmdRedo;

      bool Command_Redo (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_Redo (commandType, parameter, ref canExecute);
         return canExecute;
      }

      ToggleNotesCommandType m_cmdToggleNotes;

      bool Command_ToggleNotes (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_ToggleNotes (commandType, parameter, ref canExecute);
         return canExecute;
      }
      #endregion


      // ----------------------------------------------------------------------
      public class NewSlideCommandType : BaseCommand
      {
         public NewSlideCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void NewSlide (object parameter = null)
      {
         var command = NewSlideCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand NewSlideCommand
      {
         get
         {
            if (m_cmdNewSlide == null)
            {
               m_cmdNewSlide = new NewSlideCommandType (
                  Command_NewSlide);
            }
            return m_cmdNewSlide;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_NewSlide (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class DuplicateSlideCommandType : BaseCommand
      {
         public DuplicateSlideCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void DuplicateSlide (object parameter = null)
      {
         var command = DuplicateSlideCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand DuplicateSlideCommand
      {
         get
         {
            if (m_cmdDuplicateSlide == null)
            {
               m_cmdDuplicateSlide = new DuplicateSlideCommandType (
                  Command_DuplicateSlide);
            }
            return m_cmdDuplicateSlide;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_DuplicateSlide (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class DeleteSlideCommandType : BaseCommand
      {
         public DeleteSlideCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void DeleteSlide (object parameter = null)
      {
         var command = DeleteSlideCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand DeleteSlideCommand
      {
         get
         {
            if (m_cmdDeleteSlide == null)
            {
               m_cmdDeleteSlide = new DeleteSlideCommandType (
                  Command_DeleteSlide);
            }
            return m_cmdDeleteSlide;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_DeleteSlide (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class UndoCommandType : BaseCommand
      {
         public UndoCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void Undo (object parameter = null)
      {
         var command = UndoCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand UndoCommand
      {
         get
         {
            if (m_cmdUndo == null)
            {
               m_cmdUndo = new UndoCommandType (
                  Command_Undo);
            }
            return m_cmdUndo;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_Undo (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class RedoCommandType : BaseCommand
      {
         public RedoCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void Redo (object parameter = null)
      {
         var command = RedoCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand RedoCommand
      {
         get
         {
            if (m_cmdRedo == null)
            {
               m_cmdRedo = new RedoCommandType (
                  Command_Redo);
            }
            return m_cmdRedo;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_Redo (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class ToggleNotesCommandType : BaseCommand
      {
         public ToggleNotesCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void ToggleNotes (object parameter = null)
      {
         var command = ToggleNotesCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand ToggleNotesCommand
      {
         get
         {
            if (m_cmdToggleNotes == null)
            {
               m_cmdToggleNotes = new ToggleNotesCommandType (
                  Command_ToggleNotes);
            }
            return m_cmdToggleNotes;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_ToggleNotes (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

   }
   partial class Slide
   {
      #region Commands for Slide

      NewShapeCommandType m_cmdNewShape;

      bool Command_NewShape (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_NewShape (commandType, parameter, ref canExecute);
         return canExecute;
      }

      NewPictureCommandType m_cmdNewPicture;

      bool Command_NewPicture (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_NewPicture (commandType, parameter, ref canExecute);
         return canExecute;
      }

      NewTextCommandType m_cmdNewText;

      bool Command_NewText (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_NewText (commandType, parameter, ref canExecute);
         return canExecute;
      }

      BringToFrontCommandType m_cmdBringToFront;

      bool Command_BringToFront (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_BringToFront (commandType, parameter, ref canExecute);
         return canExecute;
      }

      SendToBackCommandType m_cmdSendToBack;

      bool Command_SendToBack (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_SendToBack (commandType, parameter, ref canExecute);
         return canExecute;
      }
      #endregion


      // ----------------------------------------------------------------------
      public class NewShapeCommandType : BaseCommand
      {
         public NewShapeCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void NewShape (object parameter = null)
      {
         var command = NewShapeCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand NewShapeCommand
      {
         get
         {
            if (m_cmdNewShape == null)
            {
               m_cmdNewShape = new NewShapeCommandType (
                  Command_NewShape);
            }
            return m_cmdNewShape;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_NewShape (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class NewPictureCommandType : BaseCommand
      {
         public NewPictureCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void NewPicture (object parameter = null)
      {
         var command = NewPictureCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand NewPictureCommand
      {
         get
         {
            if (m_cmdNewPicture == null)
            {
               m_cmdNewPicture = new NewPictureCommandType (
                  Command_NewPicture);
            }
            return m_cmdNewPicture;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_NewPicture (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class NewTextCommandType : BaseCommand
      {
         public NewTextCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void NewText (object parameter = null)
      {
         var command = NewTextCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand NewTextCommand
      {
         get
         {
            if (m_cmdNewText == null)
            {
               m_cmdNewText = new NewTextCommandType (
                  Command_NewText);
            }
            return m_cmdNewText;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_NewText (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class BringToFrontCommandType : BaseCommand
      {
         public BringToFrontCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void BringToFront (object parameter = null)
      {
         var command = BringToFrontCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand BringToFrontCommand
      {
         get
         {
            if (m_cmdBringToFront == null)
            {
               m_cmdBringToFront = new BringToFrontCommandType (
                  Command_BringToFront);
            }
            return m_cmdBringToFront;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_BringToFront (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class SendToBackCommandType : BaseCommand
      {
         public SendToBackCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void SendToBack (object parameter = null)
      {
         var command = SendToBackCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand SendToBackCommand
      {
         get
         {
            if (m_cmdSendToBack == null)
            {
               m_cmdSendToBack = new SendToBackCommandType (
                  Command_SendToBack);
            }
            return m_cmdSendToBack;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_SendToBack (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

   }
}


