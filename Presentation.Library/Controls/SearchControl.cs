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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Presentation.Library.Behaviors;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Controls
{
   public delegate bool SearchControlDelegate (string compareWith, DependencyObject obj);


   public partial class SearchControl : Control
   {
      static readonly TimeSpan s_minTimeOut = new TimeSpan (0,0,0,0,200);

      static readonly SearchControlDelegate s_delegate = (compareWith, obj) => 
         obj != null ? (compareWith ?? "").Equals (obj.ToString ()) : compareWith.IsNullOrEmpty ();

      readonly DispatcherTimer m_timer = new DispatcherTimer ();
      bool m_doSearch;

      public SearchControl ()
      {
         DefaultStyleKey = typeof (SearchControl);
         m_timer.Interval = SearchTimeOut.Max (s_minTimeOut);
         m_timer.Tick += SearchControl_Tick;
         m_timer.Start ();

         KeyEventHandler keyDown = SearchControl_KeyDown;
         AddHandler (KeyDownEvent, keyDown, true);

      }

      public override void OnApplyTemplate ()
      {
         var control = GetTemplateChild ("REQUIRED_FOR_SEARCH") as Control;
         if (control != null)
         {
            control.Focus ();
         }
         base.OnApplyTemplate ();
      }

      DependencyObject GetSearchResult ()
      {
         if (SearchResultItems == null || SearchResultItems.Count <= 0)
         {
            return null;
         }

         var currentSearchResultItem = CurrentSearchResultItem;

         return SearchResultItems
            .FirstOrDefault (item => ReferenceEquals (item, currentSearchResultItem)) 
            ?? SearchResultItems[0]
            ;
      }

      void SearchControl_KeyDown (object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Enter)
         {
            Command.SetParameter (this, GetSearchResult ());
            this.ExecuteCommand<PopupControl.CloseCommandType>();
         }
         else if (e.Key == Key.Escape)
         {
            Command.SetParameter (this, null);
            this.ExecuteCommand<PopupControl.CloseCommandType>();
         }
      }

      void SearchControl_Tick (object sender, EventArgs e)
      {
         DoSearch ();
      }

      void DoSearch ()
      {
         if (m_doSearch)
         {
            m_doSearch = true;

            var searchItems      = SearchItemsSource;
            var searchResultItems= SearchResultItems;
            var searchString     = SearchString;
            var searchDelegate   = SearchDelegate ?? s_delegate;

            if (searchResultItems == null)
            {
               searchResultItems = new ObservableCollection<DependencyObject> ();
               SearchResultItems = searchResultItems;
            }

            if (searchItems == null)
            {
               SearchResultItems.Clear ();
               return;
            }

            var interestingSearchItems = searchItems
               .Where (searchITem => searchITem != null)
               .ToArray ();

            var filteredSearchItems = 
               searchString.IsNullOrEmpty () 
                  ?  interestingSearchItems
                  :  interestingSearchItems
                     .Where (dobj => searchDelegate (searchString, dobj))
                     .ToArray ();

            SetIndexProperty (IdProperty, interestingSearchItems);
            SetIndexProperty (DesiredIndexProperty, filteredSearchItems);

            var removed = searchResultItems.Except (filteredSearchItems, GetId).ToArray ();
            var added = filteredSearchItems.Except (searchResultItems, GetId).ToArray ();

            SetIndexProperty (CurrentIndexProperty, searchResultItems);
            foreach (var toBeRemoved in removed.OrderByDescending (GetCurrentIndex))
            {
               var index = GetCurrentIndex (toBeRemoved);
               searchResultItems.RemoveAt (index);
            }

            foreach (var toBeAdded in added.OrderBy (GetDesiredIndex))
            {
               var index = GetDesiredIndex (toBeAdded);
               searchResultItems.Insert (index, toBeAdded);
            }

            var potentiallyMoved = filteredSearchItems.Intersect (searchResultItems, GetId).ToArray ();

            SetIndexProperty (CurrentIndexProperty, searchResultItems);
            foreach (var toBeMoved in potentiallyMoved)
            {
               var desired = GetDesiredIndex (toBeMoved);
               var current = GetCurrentIndex (toBeMoved);
               if (desired != current)
               {
                  searchResultItems.Move (desired, current);
                  SetCurrentIndex (searchResultItems[desired], desired);
                  SetCurrentIndex (searchResultItems[current], current);
               }
            }
         }
      }

      static void SetIndexProperty (DependencyProperty dependencyProperty, IList<DependencyObject> items)
      {
         var length = items.Count;
         for (var iter = 0; iter < length; ++iter)
         {
            items[iter].SetValue (dependencyProperty, iter);
         }
      }

      partial void  OnChange_SearchItemsSource (ObservableCollection<DependencyObject> oldValue, ObservableCollection<DependencyObject> newValue, ref bool handled)
      {
         if (oldValue != null)
         {
            oldValue.CollectionChanged -= CollectionChanged;
         }
         
         if (newValue != null)
         {
            newValue.CollectionChanged += CollectionChanged;
         }

         m_doSearch |= true;
         handled = true;
      }

      void CollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
      {
         m_doSearch |= true;
      }

      partial void OnChange_SearchString (string oldValue, string newValue, ref bool handled)
      {
         m_doSearch |= !(oldValue ?? "").Equals (newValue);
         handled = true;
      }

      partial void OnChange_SearchDelegate (SearchControlDelegate oldValue, SearchControlDelegate newValue, ref bool handled)
      {
         m_doSearch |= true;
         handled = true;
      }

   }
}
