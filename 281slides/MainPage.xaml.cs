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
using System.Windows.Threading;
using Presentation.Library.Utility;

namespace _281slides
{
   public sealed partial class MainPage
   {
      readonly DispatcherTimer m_timer = new DispatcherTimer ();

      int m_tick;

      public MainPage ()
      {
         InitializeComponent ();
         m_timer.Interval = new TimeSpan(0,0,0,1);
         m_timer.Tick += Timer_Tick;
         m_timer.Start ();
      }

      void Timer_Tick(object sender, EventArgs e)
      {
         Debug.WriteLine ("------------------------ {0,8} ----------------------", ++m_tick);
      }

      private void Button_Click (object sender, System.Windows.RoutedEventArgs e)
      {
         this.TraceVisualTree ();
      }
   }
}
