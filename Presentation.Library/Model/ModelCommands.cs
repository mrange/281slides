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
using System.Collections.ObjectModel;
using System.Linq;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Model
{
   public partial class Presentation
   {
      partial void Command_Undo (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = ModelContext.ChangeTracker.CanUndo;
         if (canExecute && commandType == CommandType.Execute)
         {
            ModelContext.ChangeTracker.Undo ();
         }
      }

      partial void Command_Redo (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = ModelContext.ChangeTracker.CanRedo;
         if (canExecute && commandType == CommandType.Execute)
         {
            ModelContext.ChangeTracker.Redo ();
         }
      }

      partial void Command_ToggleNotes (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = true;
         if (CommandType.Execute == commandType)
         {
            IsShowingNotes = !IsShowingNotes;
         }
      }

      partial void Command_DuplicateSlide (CommandType commandType, object parameter, ref bool canExecute)
      {
         var slides = Slides;
         var slideToDuplicate = (parameter as Slide) ?? CurrentSlide;
         var index = slides != null ? slides.IndexOf (slideToDuplicate) : -1;
         canExecute = slideToDuplicate != null && slides != null && index > -1;
         if (canExecute && CommandType.Execute == commandType)
         {
            ModelContext.RunGroup (() =>
               {
                  Slide newSlide;
                  ModelCopier.Copy (ModelContext, slideToDuplicate, out newSlide);

                  slides.Insert (index, newSlide);

                  newSlide.Update (this);

                  CurrentSlide = newSlide;
               });

         }
      }

      partial void Command_DeleteSlide (CommandType commandType, object parameter, ref bool canExecute)
      {
         var slides = Slides;
         var slideToDuplicate = (parameter as Slide) ?? CurrentSlide;
         var index = slides != null ? slides.IndexOf (slideToDuplicate) : -1;
         canExecute = slideToDuplicate != null && slides != null && index > -1;
         if (canExecute && CommandType.Execute == commandType)
         {
            ModelContext.RunGroup (() =>
               {
                  slides.RemoveAt (index);
                  var newIndex = Math.Min (index, Slides.Count - 1);

                  CurrentSlide = newIndex > -1 ? Slides[newIndex] : null;
               });

         }
      }

      partial void Command_NewSlide (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = true;
         if (CommandType.Execute == commandType)
         {
            ModelContext.RunGroup (() =>
               {
                  var slides = GetSlides ();

                  var newSlide =
                     new Slide (ModelContext)
                     {
                        Elements = 
                           new ObservableCollection<BaseElement>
                           {
                              new TextElement (ModelContext)
                                 {
                                    Left = 40,
                                    Top = 40,
                                    Width = 1200,
                                    Height = 64,
                                    Text = "Title Text",
                                    FontSize = 48,
                                 },
                              new TextElement (ModelContext)
                                 {
                                    Left = 40,
                                    Top = 200,
                                    Width = 1200,
                                    Height = 48,
                                    Text = "Content Text",
                                    FontSize = 32,
                                 },
                           },
                     };

                  slides.Add (newSlide);
                  newSlide.Update (this);
                  CurrentSlide = slides[slides.Count - 1];
               });
         }
      }

      ObservableCollection<Slide> GetSlides ()
      {
         var slides = Slides;
         if (slides == null)
         {
            slides = new ObservableCollection<Slide> ();
            Slides = slides;
         }
         return slides;
      }
   }

   public partial class Slide
   {
      partial void Command_BringToFront (CommandType commandType, object parameter, ref bool canExecute)
      {
         var elements = Elements;
         var elementToBack = (parameter as BaseElement) ?? CurrentElement;
         var elementMaxValue = elementToBack != null ? elementToBack.ZIndex : int.MinValue;
         var globalMaxValue = elements
            .Where (be => !ReferenceEquals (be, elementToBack))
            .Max (int.MaxValue, be => be.ZIndex);

         canExecute = elements != null && elementToBack != null && elementMaxValue <= globalMaxValue;

         if (canExecute && commandType == CommandType.Execute)
         {
            elementToBack.ZIndex = globalMaxValue + 1;
         }
      }

      partial void Command_SendToBack (CommandType commandType, object parameter, ref bool canExecute)
      {
         var elements = Elements;
         var elementToBack = (parameter as BaseElement) ?? CurrentElement;
         var elementMinValue = elementToBack != null ? elementToBack.ZIndex : int.MaxValue;
         var globalMinValue = elements
            .Where (be => !ReferenceEquals (be, elementToBack))
            .Min (int.MinValue, be => be.ZIndex);

         canExecute = elements != null && elementToBack != null && elementMinValue >= globalMinValue;

         if (canExecute && commandType == CommandType.Execute)
         {
            elementToBack.ZIndex = globalMinValue - 1;
         }
      }

      partial void Command_NewShape (CommandType commandType, object parameter, ref bool canExecute)
      {
         var def = parameter as ShapeDefinition;

         canExecute = def != null;

         if (canExecute && commandType == CommandType.Execute)
         {
            ModelContext.RunGroup (() =>
               {
                  var elements = GetElements ();

                  elements.Add (
                     new ShapeElement (ModelContext)
                        {
                           Left = 100,
                           Top = 100,
                           Width = 200,
                           Height = 200,
                           Path = def.Path,
                        });
               });
         }
      }

      partial void Command_NewPicture (CommandType commandType, object parameter, ref bool canExecute)
      {
         var def = parameter as PictureDefinition;

         canExecute = def != null;

         if (canExecute && commandType == CommandType.Execute)
         {
            ModelContext.RunGroup (() =>
               {
                  var elements = GetElements ();

                  elements.Add (
                     new PictureElement (ModelContext)
                        {
                           Left = 100,
                           Top = 100,
                           Width = 200,
                           Height = 200,
                           PictureSource = def.PictureSource,
                        });
               });
         }
      }

      partial void Command_NewText (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = true;
         if (commandType == CommandType.Execute)
         {
            ModelContext.RunGroup (() =>
               {
                  var elements = GetElements ();

                  elements.Add (
                     new TextElement (ModelContext)
                        {
                           Left = 100,
                           Top = 500,
                           Width = 400,
                           Height = 48,
                           FontSize = 36,
                           Text = "Write some text....",
                        });
               });
         }
      }

      ObservableCollection<BaseElement> GetElements ()
      {
         var elements = Elements;

         if (elements == null)
         {
            elements = new ObservableCollection<BaseElement> ();
            Elements = elements;
         }
         return elements;
      }
   }
}
