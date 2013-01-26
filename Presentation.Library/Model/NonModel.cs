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
using System.Windows.Media;

namespace Presentation.Library.Model
{
   public partial class PictureDefinition : BaseDefinition, IPicture
   {
      partial void OnChange_PictureSource (string oldValue, string newValue, ref bool handled)
      {
         
         this.ChangePictureSource (oldValue, newValue);
         handled = true;
      }

      partial void OnChange_Source (ImageSource oldValue, ImageSource newValue, ref bool handled)
      {
         this.ChangeSource (oldValue, newValue);
         handled = true;
      }
   }

   public partial class BaseDefinition : DependencyObject
   {}

   public partial class ThemeDefinition : BaseDefinition
   {
      
   }

   public partial class LayoutDefinition : BaseDefinition
   {
      
   }

   public partial class MovieDefinition : BaseDefinition
   {
      
   }

   public partial class ShapeDefinition : BaseDefinition
   {
      
   }
}
