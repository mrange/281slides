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

// ReSharper disable EmptyGeneralCatchClause

namespace _281slides
{
   public sealed partial class App
   {

      public App ()
      {
         Startup += Application_Startup;
         Exit += Application_Exit;
         UnhandledException += Application_UnhandledException;

         InitializeComponent ();
      }

      void Application_Startup (object sender, StartupEventArgs e)
      {
         RootVisual = new MainPage ();
      }

      static void Application_Exit (object sender, EventArgs e)
      {

      }

      static void Application_UnhandledException (object sender, ApplicationUnhandledExceptionEventArgs e)
      {
         // If the app is running outside of the debugger then report the exception using
         // the browser's exception mechanism. On IE this will display it a yellow alert 
         // icon in the status bar and Firefox will display a script error.
         if (!System.Diagnostics.Debugger.IsAttached)
         {

            // NOTE: This will allow the application to continue running after an exception has been thrown
            // but not handled. 
            // For production applications this error handling should be replaced with something that will 
            // report the error to the website and stop the application.
            e.Handled = true;
            Deployment.Current.Dispatcher.BeginInvoke (() => ReportErrorToDom (e));
         }
      }

      static void ReportErrorToDom (ApplicationUnhandledExceptionEventArgs e)
      {
         try
         {
            var errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
            errorMsg = errorMsg.Replace ('"', '\'').Replace ("\r\n", @"\n");

            System.Windows.Browser.HtmlPage.Window.Eval ("throw new Error (\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
         }
         catch
         {
         }
      }
   }
}
