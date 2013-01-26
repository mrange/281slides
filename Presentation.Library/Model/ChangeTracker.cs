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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;

namespace Presentation.Library.Model
{
   public sealed class ChangeTracker
   {
      struct ChangeTrackerItem
      {
         public IAction Action;
         public int Group;

         public static ChangeTrackerItem Create (
            IAction action, 
            int group
            )
         {
            return new ChangeTrackerItem
               {
                  Action = action,
                  Group = group,
               };
         }
      }

      interface IAction
      {
         void Undo ();
         void Redo ();
      }

      sealed class SetPropertyAction : IAction
      {
         DependencyObject DependencyObject { get; set; }
         DependencyProperty DependencyProperty { get; set; }
         object OldValue { get; set; }
         object NewValue { get; set; }

         public static SetPropertyAction Create (
            DependencyObject dependencyObject,
            DependencyProperty dependencyProperty,
            object oldValue,
            object newValue)
         {
            return new SetPropertyAction
                          {
                             DependencyObject = dependencyObject,
                             DependencyProperty = dependencyProperty,
                             OldValue = oldValue,
                             NewValue = newValue
                          };
         }

         public void Undo ()
         {
            DependencyObject.SetValue (DependencyProperty, OldValue);
         }

         public void Redo ()
         {
            DependencyObject.SetValue (DependencyProperty, NewValue);
         }

         public override string ToString ()
         {
            return new
                      {
                         Type = typeof (SetPropertyAction).Name,
                         DependencyObject,
                         DependencyProperty,
                         OldValue,
                         NewValue,
                      }.ToString ();
         }
      }

      sealed class CollectionChangedAction : IAction
      {
         IList List { get; set; }

         int OldStartingIndex { get; set; }

         IList OldItems { get; set; }

         int NewStartingIndex { get; set; }

         IList NewItems { get; set; }

         NotifyCollectionChangedAction Action { get; set; }

         static void InsertItems (
            IList list,
            int startingIndex, 
            IList items)
         {
            for (var iter = 0; iter < items.Count; ++iter)
            {
               list.Insert (iter + startingIndex, items[iter]);
            }
            
         }

         static void RemoveItems (
            IList list,
            int startingIndex,
            IList items)
         {
            for (var iter = items.Count - 1; iter >= 0; --iter)
            {
               list.RemoveAt (iter + startingIndex);
            }
         }

         static void ReplaceItems (
            IList list,
            int startingIndex,
            IList items)
         {
            for (var iter = 0; iter < items.Count; ++iter)
            {
               list[iter + startingIndex] = items[iter];
            }
         }

         static void ResetItems (
            IList list,
            IList items)
         {
            list.Clear ();

            foreach (var item in items)
            {
               list.Add (item);
            }
         }

         public void Undo ()
         {
            switch (Action)
            {
               case NotifyCollectionChangedAction.Add:
                  RemoveItems (List, NewStartingIndex, NewItems);
                  break;
               case NotifyCollectionChangedAction.Remove:
                  InsertItems (List, OldStartingIndex, OldItems);
                  break;
               case NotifyCollectionChangedAction.Replace:
                  ReplaceItems (List, NewStartingIndex, OldItems);
                  break;
               case NotifyCollectionChangedAction.Reset:
                  ResetItems (List, OldItems);
                  break;
               default:
                  throw new ArgumentOutOfRangeException ();
            }
         }

         public void Redo ()
         {
            switch (Action)
            {
               case NotifyCollectionChangedAction.Add:
                  InsertItems (List, NewStartingIndex, NewItems);
                  break;
               case NotifyCollectionChangedAction.Remove:
                  RemoveItems (List, OldStartingIndex, OldItems);
                  break;
               case NotifyCollectionChangedAction.Replace:
                  ReplaceItems (List, NewStartingIndex, NewItems);
                  break;
               case NotifyCollectionChangedAction.Reset:
                  ResetItems (List, NewItems);
                  break;
               default:
                  throw new ArgumentOutOfRangeException ();
            }
         }

         public static CollectionChangedAction Create (
            IList list,
            NotifyCollectionChangedAction action,
            IList newItems,
            int newStartingIndex,
            IList oldItems,
            int oldStartingIndex)
         {
            return new CollectionChangedAction
                      {
                         List = list,
                         Action = action,
                         NewItems = newItems,
                         NewStartingIndex = newStartingIndex,
                         OldItems = oldItems,
                         OldStartingIndex = oldStartingIndex,
                      };

         }

         public override string ToString ()
         {
            return new
                      {
                         typeof (CollectionChangedAction).Name,
                         List,
                         Action,
                         NewItems,
                         NewStartingIndex,
                         OldItems,
                         OldStartingIndex,
                      }.ToString ();
         }

      }

      readonly IList<ChangeTrackerItem> m_buffer = new List<ChangeTrackerItem>();

      int m_currentPosition;
      int? m_currentGroup;
      int m_changeSet;
      bool m_doNotRecording;

      public bool CanUndo
      {
         get
         {
            return m_currentPosition > 0;
         }
      }

      public bool CanRedo
      {
         get
         {
            return m_currentPosition < m_buffer.Count;
         }
      }

      public void Undo ()
      {
         if (CanUndo)
         {
            var doNotRecord = m_doNotRecording;

            m_doNotRecording = true;
            try
            {
               var iter = m_currentPosition - 1;

               var group = m_buffer[iter].Group;

               while (iter > -1 && m_buffer[iter].Group == group)
               {
                  var item = m_buffer[iter];
                  item.Action.Undo ();
                  --iter;
               }

               m_currentPosition = iter + 1;
            }
            finally
            {
               m_doNotRecording = doNotRecord;
            }
         }
      }

      public void Redo ()
      {
         if (CanRedo)
         {
            var doNotRecord = m_doNotRecording;

            m_doNotRecording = true;
            try
            {
               var iter = m_currentPosition;

               var group = m_buffer[iter].Group;

               while (iter < m_buffer.Count && m_buffer[iter].Group == group)
               {
                  var item = m_buffer[iter];
                  item.Action.Redo ();
                  ++iter;
               }

               m_currentPosition = iter;
            }
            finally
            {
               m_doNotRecording = doNotRecord;
            }
         }
      }

      int? BeginGroup ()
      {
         if (m_currentGroup != null)
         {
            return m_currentGroup;
         }

         ++m_changeSet;
         m_currentGroup = m_changeSet;

         return null;
      }

      void EndGroup (int? oldGroup)
      {
         m_currentGroup = oldGroup;
      }

      public void Clear ()
      {
         m_currentPosition = 0;
         m_buffer.Clear ();
      }

      public int ChangeSet
      {
         get
         {
            return m_changeSet;
         }
      }

      public bool HasNewerChangeSets (int compareWithChangeSet)
      {
         return compareWithChangeSet < m_changeSet;
      }

      void AppendAction (
         Func<IAction> action)
      {
         if (!m_doNotRecording)
         {
            ++m_changeSet;

            for (var iter = m_buffer.Count - 1; m_currentPosition <= iter; --iter)
            {
               m_buffer.RemoveAt (iter);
            }

            m_buffer.Add (
               ChangeTrackerItem.Create (
                  action (),
                  m_currentGroup ?? m_changeSet));

            m_currentPosition = m_buffer.Count;
         }
      }

      public void AppendSetPropertyAction (
         DependencyObject dependencyObject,
         DependencyProperty dependencyProperty,
         object previousValue,
         object newValue
         )
      {
         AppendAction (
            () => SetPropertyAction.Create (
                     dependencyObject,
                     dependencyProperty,
                     previousValue,
                     newValue));
      }


      public void AppendCollectionChangedAction (
         IList list,
         NotifyCollectionChangedAction action,
         IList newItems,
         int newStartingIndex,
         IList oldItems,
         int oldStartingIndex)
      {
         AppendAction (
            () => CollectionChangedAction.Create (
               list,
               action,
               newItems,
               newStartingIndex,
               oldItems,
               oldStartingIndex));
      }

      public T RunGroup<T>(Func<T> action)
      {
         var oldGroup = BeginGroup ();
         try
         {
            return action ();
         }
         finally
         {
            EndGroup (oldGroup);
         }

      }

      public void RunGroup (Action action)
      {
         var oldGroup = BeginGroup ();
         try
         {
            action ();
         }
         finally
         {
            EndGroup (oldGroup);
         }

      }
   }
}
