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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Controls
{
   public partial class FixedDimension : Panel
   {
      public FixedDimension ()
      {
         Dimension = new Size (1280, 1024);
      }

      partial void OnChange_Dimension (Size oldValue, Size newValue, ref bool handled)
      {
         InvalidateMeasure ();
         handled = true;
      }

      static double SafeRatio (Size dimension)
      {
         return SafeRatio (dimension.Width, dimension.Height);
      }

      static double SafeRatio (double left, double right)
      {
         return right != 0 ? left/right : 1;
      }

      protected override Size MeasureOverride (Size availableSize)
      {
         var size = CalcSize (availableSize);

         return size;
      }

      Size CalcSize (Size availableSize)
      {
         var dimRatio = SafeRatio (Dimension);
         var sizeRatio = SafeRatio (availableSize);

         if (availableSize.Width != double.PositiveInfinity && availableSize.Height != double.PositiveInfinity)
         {
            return sizeRatio < dimRatio 
               ? new Size (availableSize.Width, availableSize.Width / dimRatio) 
               : new Size (availableSize.Height * dimRatio, availableSize.Height);
            
         }
         else if (availableSize.Width != double.PositiveInfinity)
         {
            return new Size (availableSize.Width, availableSize.Width / dimRatio);
         }
         else if (availableSize.Height != double.PositiveInfinity)
         {
            return new Size (availableSize.Height * dimRatio, availableSize.Height);
         }
         else
         {
            return Dimension;
         }
      }

      protected override Size ArrangeOverride (Size finalSize)
      {
         var dim = Dimension;
         var adjustedSize = CalcSize (finalSize);

         var scale = SafeRatio (adjustedSize.Width, dim.Width);
         var offset = new Point ((finalSize.Width - adjustedSize.Width) / 2, (finalSize.Height - adjustedSize.Height) / 2);

         foreach (var uiElement in Children)
         {
            uiElement.Arrange (
               new Rect (
                  0,
                  0,
                  dim.Width,
                  dim.Height
                  ));

            var transform = 
               new TransformGroup
               {
                     Children = 
                        new TransformCollection
                        {
                              new ScaleTransform
                              {
                                    ScaleX = scale,
                                    ScaleY = scale,
                                 },
                              new TranslateTransform
                                 {
                                    X = offset.X,
                                    Y = offset.Y,
                                 },
                           },
                  };
            uiElement.RenderTransform = transform;
         }

         return finalSize;
      }
   }
}
