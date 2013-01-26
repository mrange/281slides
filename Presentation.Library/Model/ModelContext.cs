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
using System.Collections;
using System.Collections.Specialized;
using System.Windows;

namespace Presentation.Library.Model
{
   public class ModelContext
   {
      readonly ChangeTracker m_changeTracker = new ChangeTracker ();
      bool m_changeNotificationActivated = true;
      bool m_isChangeTracking = true;

      public ChangeTracker ChangeTracker
      {
         get
         {
            return m_changeTracker;
         }
      }

      public void RunWithChangeNotificationDisabled (Action action)
      {
         if (action == null)
         {
            return;
         }

         var oldChangeNotificationActivated = m_changeNotificationActivated;
         m_changeNotificationActivated = false;

         try
         {
            action ();
         }
         finally
         {
            m_changeNotificationActivated = oldChangeNotificationActivated;
         }
      }

      public T RunWithChangeNotificationDisabled<T> (Func<T> action)
      {
         if (action == null)
         {
            return default (T);
         }

         var oldChangeNotificationActivated = m_changeNotificationActivated;
         m_changeNotificationActivated = false;

         try
         {
            return action ();
         }
         finally
         {
            m_changeNotificationActivated = oldChangeNotificationActivated;
         }
      }

      public bool ChangeNotificationActivated
      {
         get
         {
            return m_changeNotificationActivated;
         }
      }

      public T RunGroup<T>(Func<T> action)
      {
         return ChangeTracker.RunGroup (action);
      }

      public void RunGroup (Action action)
      {
         ChangeTracker.RunGroup (action);
      }

      public T RunUntracked<T>(Func<T> action)
      {
         var oldIsRecording = m_isChangeTracking;
         m_isChangeTracking = false;
         try
         {
            return action ();
         }
         finally
         {
            m_isChangeTracking = oldIsRecording;
         }

      }

      public void RunUntracked (Action action)
      {
         var oldIsRecording = m_isChangeTracking;
         m_isChangeTracking = false;
         try
         {
            action ();
         }
         finally
         {
            m_isChangeTracking = oldIsRecording;
         }

      }

      public bool IsChangeTracking
      {
         get
         {
            return m_isChangeTracking;
         }
         set
         {
            m_isChangeTracking = value;
         }
      }

      public void AppendSetPropertyAction (
         DependencyObject dependencyObject,
         DependencyPropertyChangedEventArgs e         
         )
      {
         var ct = ChangeTracker;
         if (ct != null)
         {
            ct.AppendSetPropertyAction (
               dependencyObject,
               e.Property,
               e.OldValue,
               e.NewValue
               );
         }
      }

      public void AppendCollectionChangedAction (
         IList list,
         NotifyCollectionChangedEventArgs e
         )
      {
         var ct = ChangeTracker;
         if (ct != null)
         {
            ct.AppendCollectionChangedAction (
               list,
               e.Action,
               e.NewItems,
               e.NewStartingIndex,
               e.OldItems,
               e.OldStartingIndex
               );
         }
      }

   }
}
