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
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Presentation.Library.Model
{
   public interface IPicture
   {
      ImageSource Source { get; set; }
      Visibility DownloadProgressVisibility { get; set; }
      int DownloadProgressValue { get; set; }
   }

   public static partial class PictureHelpers
   {
      public static void ChangePictureSource (this IPicture picture, string oldValue, string newValue)
      {
         if (newValue != null)
         {
            var uri = new Uri (newValue, UriKind.Absolute);
            picture.Source = new BitmapImage (uri);
         }
         else
         {
            picture.Source = null;
         }
      }

      public static void ChangeSource (this IPicture picture, ImageSource oldValue, ImageSource newValue)
      {
         var oldBitmapImage = oldValue as BitmapImage;
         var newBitmapImage = newValue as BitmapImage;
         if (oldBitmapImage != null)
         {
            oldBitmapImage.DownloadProgress -= DownloadProgress;
            oldBitmapImage.ImageOpened -= ImageOpened;
            oldBitmapImage.ImageFailed -= ImageFailed;
         }

         if (newBitmapImage != null)
         {
            newBitmapImage.DownloadProgress += DownloadProgress;
            newBitmapImage.ImageOpened += ImageOpened;
            newBitmapImage.ImageFailed += ImageFailed;
         }
      }

      static void DownloadProgress (object sender, DownloadProgressEventArgs e)
      {
         var picture = GetPicture (sender as DependencyObject);

         if (picture != null)
         {
            picture.DownloadProgressValue = e.Progress;
            picture.DownloadProgressVisibility = e.Progress < 100 
               ? Visibility.Visible 
               : Visibility.Collapsed
               ;
         }
      }

      static void ImageOpened (object sender, RoutedEventArgs e)
      {
         var picture = GetPicture (sender as DependencyObject);

         if (picture != null)
         {
            picture.DownloadProgressVisibility = Visibility.Collapsed;
         }
      }

      static void ImageFailed (object sender, ExceptionRoutedEventArgs e)
      {
         var picture = GetPicture (sender as DependencyObject);

         if (picture != null)
         {
            Debug.WriteLine (e);
            picture.Source = null;
         }
      }
   }
}