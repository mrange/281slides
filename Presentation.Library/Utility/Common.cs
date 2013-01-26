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
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;

namespace Presentation.Library.Utility
{
   public static class Common
   {
      public static bool IsNullOrEmpty (this string str)
      {
         return string.IsNullOrEmpty (str);
      }

      public static ObservableCollection<TSource> ToObservableCollection<TSource> (
         this IEnumerable<TSource> enumerable)
      {
         if (enumerable == null)
         {
            return new ObservableCollection<TSource> ();
         }

         var result = new ObservableCollection<TSource> ();

         foreach (var source in enumerable)
         {
            result.Add (source);
         }

         return result;
      }

      public static Size ToSize (
         this Rect rect
         )
      {
         return new Size (rect.Width, rect.Height);
      }

      public static Size Merge (this Size left , Size right
         )
      {
         return new Size
         {
            Width = double.IsPositiveInfinity (left.Width)
               ? right.Width
               : Math.Min (left.Width, right.Width),
            Height = double.IsPositiveInfinity (left.Height)
               ? right.Height
               : Math.Min (left.Height, right.Height),
         };
      }

      public static TValue Lookup<TKey, TValue> (
         this IDictionary<TKey, TValue> dictionary,
         TKey key,
         TValue defaultValue
         )
      {
         if (dictionary == null)
         {
            return defaultValue;
         }

         TValue value;
         return dictionary.TryGetValue (key, out value) 
            ? value 
            : defaultValue
            ;
      }

      public static TValue Lookup<TKey, TValue> (
         this IDictionary<TKey, TValue> dictionary,
         TKey key
         )
      {
         return dictionary.Lookup (key, default (TValue));
      }

      public static TValue LookupOrAdd<TKey, TValue> (
         this IDictionary<TKey, TValue> dictionary,
         TKey key,
         Func<TValue> valueCreator
         )
      {
         if (dictionary == null)
         {
            return valueCreator ();
         }

         TValue value;
         if (!dictionary.TryGetValue (key, out value))
         {
            value = valueCreator ();
            dictionary[key] = value;
         }

         return value;
      }

      public static TValue LookupOrAdd<TKey, TValue> (
         this IDictionary<TKey, TValue> dictionary,
         TKey key
         )
         where TValue : new ()
      {
         if (dictionary == null)
         {
            return new TValue ();
         }

         TValue value;
         if (!dictionary.TryGetValue (key, out value))
         {
            value = new TValue ();
            dictionary[key] = value;
         }

         return value;
      }

      class ComparerHelper<TSource, TComparer> : EqualityComparer<TSource>
      {
         static readonly EqualityComparer<TComparer> s_comparer = 
            EqualityComparer<TComparer>.Default;

         readonly Func<TSource, TComparer> m_comparerPredicate;

         public ComparerHelper (Func<TSource, TComparer> comparerPredicate)
         {
            m_comparerPredicate = comparerPredicate;
         }

         public override bool Equals (TSource x, TSource y)
         {
            return s_comparer.Equals (m_comparerPredicate (x), m_comparerPredicate (y));
         }

         public override int GetHashCode (TSource obj)
         {
            return s_comparer.GetHashCode (m_comparerPredicate (obj));
         }
      }

      public static IEnumerable<TSource> Except<TSource, TComparer> (
         this IEnumerable<TSource> left,
         IEnumerable<TSource> right,
         Func<TSource, TComparer> comparerPredicate)
      {
         return left.Except (
            right,
            new ComparerHelper<TSource, TComparer> (comparerPredicate)
            );
      }

      public static IEnumerable<TSource> Intersect<TSource, TComparer> (
         this IEnumerable<TSource> left,
         IEnumerable<TSource> right,
         Func<TSource, TComparer> comparerPredicate)
      {
         return left.Intersect (
            right,
            new ComparerHelper<TSource, TComparer> (comparerPredicate)
            );
      }

      public static IEnumerable<TSource> Union<TSource, TComparer> (
         this IEnumerable<TSource> left,
         IEnumerable<TSource> right,
         Func<TSource, TComparer> comparerPredicate)
      {
         return left.Union (
            right,
            new ComparerHelper<TSource, TComparer> (comparerPredicate)
            );
      }

      public static Point Add (this Point left, Point right)
      {
         return new Point (left.X + right.X, left.X + right.Y);
      }

      public static Point Subtract (this Point left, Point right)
      {
         return new Point (left.X - right.X, left.X - right.Y);
      }

      public static double Dot (this Point left, Point right)
      {
         return left.X * right.X + left.Y * right.Y;
      }

      public static Point NormalTo (this Point left)
      {
         return new Point (left.Y, -left.X);
      }

      public static double L2 (this Point left)
      {
         return left.Dot (left);
      }

      public static double Length (this Point left)
      {
         return Math.Sqrt (left.L2 ());
      }

      public static void Dispose (object accumulatedState)
      {
         try
         {
            var dispose = accumulatedState as IDisposable;
            if (dispose != null)
            {
               dispose.Dispose ();
            }
         }
         catch (Exception exc)
         {
            Debug.WriteLine (exc);
         }
      }

      public static TValue Max<TSource, TValue> (
         this IEnumerable<TSource> e,
         TValue defaultValue,
         Func<TSource, TValue> selector
         )
         where TValue : struct, IComparable<TValue>
      {
         if (e == null)
         {
            return defaultValue;
         }

         TValue? seed = null;

         var result = e.Aggregate (
            seed,
            (acc, val) => acc != null ? selector (val).Max (acc.Value) : selector (val)
            );

         return result != null ? result.Value : defaultValue;
      }

      public static TValue Min<TSource, TValue> (
         this IEnumerable<TSource> e,
         TValue defaultValue,
         Func<TSource, TValue> selector
         )
         where TValue : struct, IComparable<TValue>
      {
         if (e == null)
         {
            return defaultValue;
         }

         TValue? seed = null;

         var result = e.Aggregate (
            seed,
            (acc, val) => acc != null ? selector (val).Min (acc.Value) : selector (val)
            );

         return result != null ? result.Value : defaultValue;
      }

      public static TValue Max<TValue> (this TValue left, TValue right)
         where TValue : struct, IComparable<TValue>
      {
         var comp = left.CompareTo (right);
         return comp > 0 ? left : right;
      }

      public static TValue Min<TValue> (this TValue left, TValue right)
         where TValue : struct, IComparable<TValue>
      {
         var comp = left.CompareTo (right);
         return comp < 0 ? left : right;
      }

      public static void AnimateProperty (
         this Storyboard storyboard,
         DependencyObject dobj,
         DependencyProperty dependencyProperty,
         TimeSpan animationDuration,
         double toValue,
         double? fromValue = null,
         TimeSpan? beginTime = null
         )  
      {
         if (storyboard == null || dobj == null || dependencyProperty == null)
         {
            return;
         }

         var animation = new DoubleAnimation
                         {
                            BeginTime = beginTime,
                            From = fromValue,
                            To = toValue,
                            Duration = animationDuration,
                         };

         storyboard.Children.Add (animation);

         Storyboard.SetTarget (animation, dobj);
         Storyboard.SetTargetProperty (animation, new PropertyPath (dependencyProperty));
      }

      public static bool Between<TSource> (
         this TSource value,
         TSource min,
         TSource max
         )
         where TSource : IComparable<TSource>
      {
         if (value.CompareTo (min) < 0)
         {
            return false;
         }

         if (max.CompareTo (value) < 0)
         {
            return false;
         }

         return true;
      }

      public static TSource Between<TSource> (
         this TSource value,
         TSource defaultValue,
         TSource min,
         TSource max
         )
         where TSource : IComparable<TSource>
      {
         if (value.CompareTo (min) < 0)
         {
            return defaultValue;
         }

         if (max.CompareTo (value) < 0)
         {
            return defaultValue;
         }

         return value;
      }

      public static TSource Clamp<TSource> (
         this TSource value,
         TSource min,
         TSource max
         )
         where TSource : IComparable<TSource>
      {
         if (value.CompareTo (min) < 0)
         {
            return min;
         }

         if (max.CompareTo (value) < 0)
         {
            return max;
         }

         return value;
      }

      public static void Move<TSource> (
         this ObservableCollection<TSource> observableCollection,
         int from,
         int to)
      {
         if (
               observableCollection != null 
            && from != to
            && from.Between (0, observableCollection.Count - 1) 
            && to.Between (0, observableCollection.Count - 1)
            )
         {
            var tmp = observableCollection[from];
            observableCollection[from] = observableCollection[to];
            observableCollection[to] = tmp;
         }
      }


      public static int SafeGetHashCode<T> (this T value)
         where T : class
      {
         return value != null ? value.GetHashCode () : 0x55555555;
      }

      public static string SafeGetTypeName<T> (this T value)
         where T : class
      {
         return value != null ? value.GetType ().Name : "<NULL>";
      }
   }
}
