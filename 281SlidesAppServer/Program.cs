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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace _281SlidesAppServer
{
   public abstract class BaseDisposable : IDisposable
   {
      int m_disposeFlag;

      public bool IsDisposed
      {
         get
         {
            return m_disposeFlag != 0;
         }
      }

      protected abstract void OnDispose ();

      public void Dispose ()
      {
         if (Interlocked.Exchange(ref m_disposeFlag, 1) == 0)
         {
            try
            {
               OnDispose ();
            }
            catch (Exception exc)
            {
               Console.WriteLine ("{0}.Dipose : {1}", GetType ().Name, exc);
            }
         }
      }
   }

   public sealed class AppServer : BaseDisposable
   {
      readonly HttpListener m_listener;
      IAsyncResult m_asyncResult;
      readonly string m_baseDir;

      public AppServer ()
      {
         m_baseDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));

         m_listener = new HttpListener ();

         const string prefix = "http://+:8080/281Slides.Web/";

         Console.WriteLine("Prefix: {0}", prefix);

         m_listener.Prefixes.Add(prefix);

         Console.WriteLine("Starting...");

         m_listener.Start ();

         Console.WriteLine("Started...");

         m_asyncResult = m_listener.BeginGetContext(OnGetContext, null);

         Console.WriteLine("Waiting for request...");
      }

      void OnGetContext (IAsyncResult ar)
      {
         try
         {
            if (IsDisposed)
            {
               return;
            }

            var context = m_listener.EndGetContext (ar);

            Console.WriteLine ("Accepted request...");

            ThreadPool.QueueUserWorkItem (OnProcessRequest, context);

            Console.WriteLine("Dispatched request...");

            m_asyncResult = m_listener.BeginGetContext (OnGetContext, null);

            Console.WriteLine ("Waiting for request...");
         }
         catch (ThreadAbortException)
         {
            
         }
         catch (Exception exc)
         {
            Console.WriteLine ("OnGetContext : {0}", exc);            
         }
      }

      void OnProcessRequest (object state)
      {
         HttpListenerContext context = null;

         try
         {
            Console.WriteLine("Processing request...");

            context = (HttpListenerContext)state;

            using (var output = context.Response.OutputStream)
            {
               Console.WriteLine (context.Request.RawUrl);

               var fullPath = Path.Combine (m_baseDir,context.Request.RawUrl.Substring(1).Replace('/', '\\'));

               Console.WriteLine (fullPath);

               var ext = Path.GetExtension (fullPath).ToLower ();

               var mime = "application/octet-stream";

               switch (ext)
               {
                  case ".js":
                     mime = "application/javascript";
                     break;
                  case ".xml":
                     mime = "text/xml";
                     break;
                  case ".htm":
                  case ".html":
                     mime = "text/html";
                     break;
                  case ".xap":
                     mime = "application/x-silverlight-app";
                     break;
                  default:
                     Debug.Assert (false);
                     break;
               }

               context.Response.ContentType = mime;
               context.Response.SendChunked = true;

               var buffer = new byte[4096];

               using (var input = File.OpenRead (fullPath))
               {
                  int read;
                  while ((read = input.Read (buffer, 0, buffer.Length)) > 0)
                  {
                     output.Write (buffer, 0, read);
                     output.Flush ();
                  }
               }

            }

            context.Response.Close();
         }
         catch (ThreadAbortException)
         {
            if (context != null)
            {
               context.Response.StatusCode = 500;
               context.Response.StatusDescription = "Server shutting down";
               context.Response.Abort ();
            }
         }
         catch (Exception exc)
         {
            Console.WriteLine ("OnProcessRequest : {0}", exc);            

            if (context != null)
            {
               context.Response.StatusCode = 500;
               context.Response.StatusDescription = "Server error";
               context.Response.Abort ();
            }
         }
      }

      protected override void OnDispose ()
      {
         m_listener.Abort ();
      }
   }

   public sealed class Program
   {
      static void Main(string[] args)
      {
         try
         {
            using (var server = new AppServer ())
            {
               do
               {
                  Console.WriteLine ("Press space to exit");
               }
               while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
         }
         catch (Exception exc)
         {
            Console.WriteLine (exc);
            Console.WriteLine("\r\nREMEMBER: This program has to be run as administrator");
            Environment.ExitCode = 101;
         }

      }

   }
}
