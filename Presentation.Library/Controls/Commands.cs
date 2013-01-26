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

namespace Presentation.Library.Controls
{
   using Utility;
   using System;
   using System.Windows.Input;
   partial class PresentationControl
   {
      #region Commands for PresentationControl

      PresentCommandType m_cmdPresent;

      bool Command_Present (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_Present (commandType, parameter, ref canExecute);
         return canExecute;
      }

      NewPresentationCommandType m_cmdNewPresentation;

      bool Command_NewPresentation (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_NewPresentation (commandType, parameter, ref canExecute);
         return canExecute;
      }

      OpenPresentationCommandType m_cmdOpenPresentation;

      bool Command_OpenPresentation (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_OpenPresentation (commandType, parameter, ref canExecute);
         return canExecute;
      }

      SavePresentationCommandType m_cmdSavePresentation;

      bool Command_SavePresentation (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_SavePresentation (commandType, parameter, ref canExecute);
         return canExecute;
      }

      SharePresentationCommandType m_cmdSharePresentation;

      bool Command_SharePresentation (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_SharePresentation (commandType, parameter, ref canExecute);
         return canExecute;
      }

      FeedbackCommandType m_cmdFeedback;

      bool Command_Feedback (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_Feedback (commandType, parameter, ref canExecute);
         return canExecute;
      }

      SessionCommandType m_cmdSession;

      bool Command_Session (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_Session (commandType, parameter, ref canExecute);
         return canExecute;
      }

      PauseChangeTrackingCommandType m_cmdPauseChangeTracking;

      bool Command_PauseChangeTracking (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_PauseChangeTracking (commandType, parameter, ref canExecute);
         return canExecute;
      }

      ResumeChangeTrackingCommandType m_cmdResumeChangeTracking;

      bool Command_ResumeChangeTracking (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_ResumeChangeTracking (commandType, parameter, ref canExecute);
         return canExecute;
      }

      InsertTextElementCommandType m_cmdInsertTextElement;

      bool Command_InsertTextElement (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_InsertTextElement (commandType, parameter, ref canExecute);
         return canExecute;
      }

      InsertPhotoElementCommandType m_cmdInsertPhotoElement;

      bool Command_InsertPhotoElement (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_InsertPhotoElement (commandType, parameter, ref canExecute);
         return canExecute;
      }

      InsertMovieElementCommandType m_cmdInsertMovieElement;

      bool Command_InsertMovieElement (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_InsertMovieElement (commandType, parameter, ref canExecute);
         return canExecute;
      }

      InsertShapeElementCommandType m_cmdInsertShapeElement;

      bool Command_InsertShapeElement (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_InsertShapeElement (commandType, parameter, ref canExecute);
         return canExecute;
      }

      SelectThemeCommandType m_cmdSelectTheme;

      bool Command_SelectTheme (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_SelectTheme (commandType, parameter, ref canExecute);
         return canExecute;
      }

      SelectLayoutCommandType m_cmdSelectLayout;

      bool Command_SelectLayout (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_SelectLayout (commandType, parameter, ref canExecute);
         return canExecute;
      }
      #endregion


      // ----------------------------------------------------------------------
      public class PresentCommandType : BaseCommand
      {
         public PresentCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void Present (object parameter = null)
      {
         var command = PresentCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand PresentCommand
      {
         get
         {
            if (m_cmdPresent == null)
            {
               m_cmdPresent = new PresentCommandType (
                  Command_Present);
            }
            return m_cmdPresent;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_Present (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class NewPresentationCommandType : BaseCommand
      {
         public NewPresentationCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void NewPresentation (object parameter = null)
      {
         var command = NewPresentationCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand NewPresentationCommand
      {
         get
         {
            if (m_cmdNewPresentation == null)
            {
               m_cmdNewPresentation = new NewPresentationCommandType (
                  Command_NewPresentation);
            }
            return m_cmdNewPresentation;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_NewPresentation (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class OpenPresentationCommandType : BaseCommand
      {
         public OpenPresentationCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void OpenPresentation (object parameter = null)
      {
         var command = OpenPresentationCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand OpenPresentationCommand
      {
         get
         {
            if (m_cmdOpenPresentation == null)
            {
               m_cmdOpenPresentation = new OpenPresentationCommandType (
                  Command_OpenPresentation);
            }
            return m_cmdOpenPresentation;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_OpenPresentation (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class SavePresentationCommandType : BaseCommand
      {
         public SavePresentationCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void SavePresentation (object parameter = null)
      {
         var command = SavePresentationCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand SavePresentationCommand
      {
         get
         {
            if (m_cmdSavePresentation == null)
            {
               m_cmdSavePresentation = new SavePresentationCommandType (
                  Command_SavePresentation);
            }
            return m_cmdSavePresentation;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_SavePresentation (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class SharePresentationCommandType : BaseCommand
      {
         public SharePresentationCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void SharePresentation (object parameter = null)
      {
         var command = SharePresentationCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand SharePresentationCommand
      {
         get
         {
            if (m_cmdSharePresentation == null)
            {
               m_cmdSharePresentation = new SharePresentationCommandType (
                  Command_SharePresentation);
            }
            return m_cmdSharePresentation;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_SharePresentation (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class FeedbackCommandType : BaseCommand
      {
         public FeedbackCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void Feedback (object parameter = null)
      {
         var command = FeedbackCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand FeedbackCommand
      {
         get
         {
            if (m_cmdFeedback == null)
            {
               m_cmdFeedback = new FeedbackCommandType (
                  Command_Feedback);
            }
            return m_cmdFeedback;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_Feedback (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class SessionCommandType : BaseCommand
      {
         public SessionCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void Session (object parameter = null)
      {
         var command = SessionCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand SessionCommand
      {
         get
         {
            if (m_cmdSession == null)
            {
               m_cmdSession = new SessionCommandType (
                  Command_Session);
            }
            return m_cmdSession;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_Session (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class PauseChangeTrackingCommandType : BaseCommand
      {
         public PauseChangeTrackingCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void PauseChangeTracking (object parameter = null)
      {
         var command = PauseChangeTrackingCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand PauseChangeTrackingCommand
      {
         get
         {
            if (m_cmdPauseChangeTracking == null)
            {
               m_cmdPauseChangeTracking = new PauseChangeTrackingCommandType (
                  Command_PauseChangeTracking);
            }
            return m_cmdPauseChangeTracking;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_PauseChangeTracking (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class ResumeChangeTrackingCommandType : BaseCommand
      {
         public ResumeChangeTrackingCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void ResumeChangeTracking (object parameter = null)
      {
         var command = ResumeChangeTrackingCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand ResumeChangeTrackingCommand
      {
         get
         {
            if (m_cmdResumeChangeTracking == null)
            {
               m_cmdResumeChangeTracking = new ResumeChangeTrackingCommandType (
                  Command_ResumeChangeTracking);
            }
            return m_cmdResumeChangeTracking;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_ResumeChangeTracking (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class InsertTextElementCommandType : BaseCommand
      {
         public InsertTextElementCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void InsertTextElement (object parameter = null)
      {
         var command = InsertTextElementCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand InsertTextElementCommand
      {
         get
         {
            if (m_cmdInsertTextElement == null)
            {
               m_cmdInsertTextElement = new InsertTextElementCommandType (
                  Command_InsertTextElement);
            }
            return m_cmdInsertTextElement;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_InsertTextElement (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class InsertPhotoElementCommandType : BaseCommand
      {
         public InsertPhotoElementCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void InsertPhotoElement (object parameter = null)
      {
         var command = InsertPhotoElementCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand InsertPhotoElementCommand
      {
         get
         {
            if (m_cmdInsertPhotoElement == null)
            {
               m_cmdInsertPhotoElement = new InsertPhotoElementCommandType (
                  Command_InsertPhotoElement);
            }
            return m_cmdInsertPhotoElement;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_InsertPhotoElement (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class InsertMovieElementCommandType : BaseCommand
      {
         public InsertMovieElementCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void InsertMovieElement (object parameter = null)
      {
         var command = InsertMovieElementCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand InsertMovieElementCommand
      {
         get
         {
            if (m_cmdInsertMovieElement == null)
            {
               m_cmdInsertMovieElement = new InsertMovieElementCommandType (
                  Command_InsertMovieElement);
            }
            return m_cmdInsertMovieElement;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_InsertMovieElement (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class InsertShapeElementCommandType : BaseCommand
      {
         public InsertShapeElementCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void InsertShapeElement (object parameter = null)
      {
         var command = InsertShapeElementCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand InsertShapeElementCommand
      {
         get
         {
            if (m_cmdInsertShapeElement == null)
            {
               m_cmdInsertShapeElement = new InsertShapeElementCommandType (
                  Command_InsertShapeElement);
            }
            return m_cmdInsertShapeElement;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_InsertShapeElement (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class SelectThemeCommandType : BaseCommand
      {
         public SelectThemeCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void SelectTheme (object parameter = null)
      {
         var command = SelectThemeCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand SelectThemeCommand
      {
         get
         {
            if (m_cmdSelectTheme == null)
            {
               m_cmdSelectTheme = new SelectThemeCommandType (
                  Command_SelectTheme);
            }
            return m_cmdSelectTheme;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_SelectTheme (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

      // ----------------------------------------------------------------------
      public class SelectLayoutCommandType : BaseCommand
      {
         public SelectLayoutCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void SelectLayout (object parameter = null)
      {
         var command = SelectLayoutCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand SelectLayoutCommand
      {
         get
         {
            if (m_cmdSelectLayout == null)
            {
               m_cmdSelectLayout = new SelectLayoutCommandType (
                  Command_SelectLayout);
            }
            return m_cmdSelectLayout;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_SelectLayout (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

   }
   partial class PopupControl
   {
      #region Commands for PopupControl

      CloseCommandType m_cmdClose;

      bool Command_Close (CommandType commandType, object parameter)
      {
         var canExecute = false;
         Command_Close (commandType, parameter, ref canExecute);
         return canExecute;
      }
      #endregion


      // ----------------------------------------------------------------------
      public class CloseCommandType : BaseCommand
      {
         public CloseCommandType (
            Func<CommandType, object, bool> commandAction
            ) 
            :  base (commandAction)
         {
         }
      }
      // ----------------------------------------------------------------------
      public void Close (object parameter = null)
      {
         var command = CloseCommand;
         command.Execute (parameter);
      }
      // ----------------------------------------------------------------------
      public ICommand CloseCommand
      {
         get
         {
            if (m_cmdClose == null)
            {
               m_cmdClose = new CloseCommandType (
                  Command_Close);
            }
            return m_cmdClose;
         }
      }
      // ----------------------------------------------------------------------
      partial void Command_Close (CommandType commandType, object parameter, ref bool canExecute);
      // ----------------------------------------------------------------------

   }
}


