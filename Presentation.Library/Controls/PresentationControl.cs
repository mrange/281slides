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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Presentation.Library.Behaviors;
using Presentation.Library.Model;
using Presentation.Library.Utility;

// ReSharper disable UnusedParameter.Local

namespace Presentation.Library.Controls
{
   public partial class PresentationControl : Control
   {
      static readonly SearchControlDelegate s_searchDelegate = 
         (compareWith, dobj) =>
            {
               var shapeDef = dobj as BaseDefinition;
               return 
                     shapeDef != null 
                  && (shapeDef.Name ?? "")
                     .ToUpper ()
                     .Contains ((compareWith ?? "").ToUpper ())
                  ;
            };

      readonly ModelContext m_modelContext = new ModelContext ();
      PopupControl m_popup;
      PopupControl m_plainPopup;
      UIElement m_root;

      readonly ModelCopier2 m_modelCopier = new ModelCopier2 ();
      readonly DataContractJsonSerializer m_jsonSerializer = new DataContractJsonSerializer (
         typeof (Model.Serializable.Presentation),
         Model.Serializable.Support.KnownTypes
         );

      readonly string m_serializedPresentation = @"{""Created"":""\/Date(1270587473215)\/"",""CurrentSlide"":{""Created"":""\/Date(1270587473245)\/"",""Elements"":[{""Angle"":0,""Height"":64,""Left"":40,""OpacityPercent"":100,""Top"":40,""Width"":1200,""ZIndex"":0},{""Angle"":0,""Height"":48,""Left"":40,""OpacityPercent"":100,""Top"":200,""Width"":1200,""ZIndex"":0}],""Note"":null},""CurrentTheme"":null,""IsShowingNotes"":false,""Name"":""[Untitled]"",""Slides"":[{""Created"":""\/Date(1270587473245)\/"",""Elements"":[{""Angle"":0,""Height"":64,""Left"":40,""OpacityPercent"":100,""Top"":40,""Width"":1200,""ZIndex"":0},{""Angle"":0,""Height"":48,""Left"":40,""OpacityPercent"":100,""Top"":200,""Width"":1200,""ZIndex"":0}],""Note"":null},{""Created"":""\/Date(1270587473245)\/"",""Elements"":[{""Angle"":0,""Height"":64,""Left"":40,""OpacityPercent"":100,""Top"":40,""Width"":1200,""ZIndex"":0},{""Angle"":0,""Height"":48,""Left"":40,""OpacityPercent"":100,""Top"":200,""Width"":1200,""ZIndex"":0}],""Note"":null}]}";

      public PresentationControl ()
      {
         DefaultStyleKey = typeof (PresentationControl);

         FontNames = new ObservableCollection<string>
                     {
                        "Verdana",
                        "Tahoma",
                     };

         FontSizes = new ObservableCollection<double>
                     {
                        16.0,
                        24.0,
                        32.0,
                        40.0,
                        48.0,
                     };

         Themes = new ObservableCollection<ThemeDefinition> ();
         Layouts = new ObservableCollection<LayoutDefinition> ();

         Shapes = new ObservableCollection<ShapeDefinition>
            {
               new ShapeDefinition
               {
                  Name = "Box",
                  Path = "M0,0 0,1 1,1 1,0 z",
               },
               new ShapeDefinition
               {
                  Name = "Triangle",
                  Path = "M0,0 0,1 1,1 z",
               },
               new ShapeDefinition
               {
                  Name = "Circle",
                  Path = "M 0,0 A 50,50 0 0 0 100,00 A 50,50 0 0 0 000,00 z",
               },
               new ShapeDefinition
               {
                  Name = "Blob",
                  Path = "M326.5,218.25 C207.49989,154.25067 526.5,119.25 506.5,256.25 C486.5,393.25 445.50009,282.24933 326.5,218.25 z",
               },
               new ShapeDefinition
               {
                  Name = "Star",
                  Path = "M157.875,183.875 L138.875,228.875 L96.875854,228.87492 L131.37573,257.87488 L111.8758,304.87482 L154.87566,267.37506 L187.87555,291.87485 L181.37556,253.87488 L210.37547,230.87494 L174.375,229.375 z",
               },
            };

         const string image1Uri = @"http://public.blu.livefilestore.com/y1p5Jka7jIhXWpequIN4pld2OCOA-ley1eJ-i89V-1SHBlyE-6sU3UM7vqBLeKyO6xBXQyv3OVJmtd7iFl-B8tJZA/sample.jpg";
         const string image2Uri = @"http://art.penny-arcade.com/photos/807503965_rBNbP-L.jpg";
         const string image3Uri = @"http://imgs.xkcd.com/comics/useless.jpg";
         const string image4Uri = @"http://corporate.wcom.se/resource/r/2587";
         const string image5Uri = @"http://i1.codeplex.com/Images/v16429/logo-home.png";
         Pictures = new ObservableCollection<PictureDefinition>
            {
               new PictureDefinition
               {
                  Name = "Face",
                  PictureSource = image1Uri,
               },
               new PictureDefinition
               {
                  Name = "Penny Arcade",
                  PictureSource = image2Uri,
               },
               new PictureDefinition
               {
                  Name = "xkcd",
                  PictureSource = image3Uri,
               },
               new PictureDefinition
               {
                  Name = "WCOM",
                  PictureSource = image4Uri,
               },
               new PictureDefinition
               {
                  Name = "CodePlex",
                  PictureSource = image5Uri,
               },
            };

         Loaded += PresentationControl_Loaded;

         NewPresentation ();
      }

      public override void OnApplyTemplate ()
      {
         m_root = GetTemplateChild ("REQUIRED_FOR_PRESENT") as UIElement;
         m_popup = GetTemplateChild ("REQUIRED_FOR_POPUP") as PopupControl;
         m_plainPopup = GetTemplateChild ("REQUIRED_FOR_PLAIN_POPUP") as PopupControl;

         base.OnApplyTemplate ();
      }

      void PresentationControl_Loaded (object sender, RoutedEventArgs e)
      {
         var handlers = Command.GetOrCreateHandlers (this);
         handlers.Register (
            new Command.CommandHandler (
               null,
               ResumeChangeTrackingCommand));
         handlers.Register (
            new Command.CommandHandler (
               null,
               PauseChangeTrackingCommand));
      }

      ModelContext ModelContext
      {
         get
         {
            return m_modelContext;
         }
      }

      partial void Command_NewPresentation (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = true;
         if (CommandType.Execute == commandType)
         {
            ModelContext.ChangeTracker.Clear ();
            ModelContext.RunUntracked (() =>
               {
                  Presentation = new Model.Presentation (ModelContext);

                  Presentation.Update (null as BaseModelEntity);

                  Presentation.NewSlide ();
               });
         }
      }

      public sealed class ModelFactory : IFactory
      {
         readonly ModelContext m_modelContext;

         public ModelFactory (ModelContext modelContext)
         {
            m_modelContext = modelContext;
         }

         public object CreateCollection (Type itemType, IEnumerable e)
         {
            var genericObservableCollectionType = typeof (ObservableCollection<>);
            var observableCollectionType = genericObservableCollectionType.MakeGenericType (itemType);
            var observableCollection = (IList)Activator.CreateInstance (observableCollectionType);

            foreach (var val in e)
            {
               observableCollection.Add (val);
            }

            return observableCollection;
         }

         public object CreateInstance (Type type)
         {
            return Activator.CreateInstance (type, m_modelContext);
         }
      }

      partial void Command_OpenPresentation (CommandType commandType, object parameter, ref bool canExecute)
      {
         // TODO: Disables open and save for now
         canExecute = false;

         if (CommandType.Execute == commandType)
         {
            Model.Serializable.Presentation presentation;
            using (var ms = new MemoryStream (Encoding.UTF8.GetBytes (m_serializedPresentation)))
            {
               presentation = (Model.Serializable.Presentation) m_jsonSerializer.ReadObject (ms);
            }

            ModelContext.ChangeTracker.Clear ();

            ModelContext.RunUntracked (() =>
               {
                  Model.Presentation newPresentation;
                  m_modelCopier.Copy (new ModelFactory (ModelContext), presentation, out newPresentation);

                  if (newPresentation != null)
                  {
                     newPresentation.Update (null as BaseModelEntity);
                     Presentation = newPresentation;
                  }
               });
         }

      }

      public sealed class SerializableFactory : IFactory
      {
         public object CreateCollection (Type itemType, IEnumerable e)
         {
            var arr = e.Cast<object> ().ToArray ();

            var result = Array.CreateInstance (itemType, arr.Length);

            for (var iter = 0; iter < arr.Length; ++iter)
            {
               result.SetValue (arr[iter], iter);
            }

            return result;
         }

         public object CreateInstance (Type type)
         {
            return Activator.CreateInstance (type);
         }
      }

      partial void Command_SavePresentation (CommandType commandType, object parameter, ref bool canExecute)
      {
         // TODO: Disables open and save for now
         canExecute = Presentation != null && ModelContext.ChangeTracker.CanUndo && false;
         if (canExecute && CommandType.Execute == commandType)
         {
            Model.Serializable.Presentation presentation;
            m_modelCopier.Copy (new SerializableFactory (), Presentation, out presentation);

            if (presentation != null)
            {
               using (var ms = new MemoryStream ())
               {
                  m_jsonSerializer.WriteObject (ms, presentation);

                  ms.Flush ();

                  var bytes = ms.ToArray ();

                  var json = Encoding.UTF8.GetString (bytes, 0, bytes.Length);

                  Debug.WriteLine (json);
               }
               
            }

         }
      }

      partial void Command_Feedback (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = false;
      }

      partial void Command_Session (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = false;
      }

      partial void Command_SharePresentation (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = Presentation != null;
      }

      partial void Command_PauseChangeTracking (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = ModelContext.IsChangeTracking;
         if (canExecute && commandType == CommandType.Execute)
         {
            ModelContext.IsChangeTracking = false;
         }
      } 

      partial void Command_ResumeChangeTracking (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = !ModelContext.IsChangeTracking;
         if (canExecute && commandType == CommandType.Execute)
         {
            ModelContext.IsChangeTracking = true;
         }
      } 

      partial void Command_Present (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = Presentation != null && m_plainPopup != null;
         if (canExecute && commandType == CommandType.Execute)
         {
            var pc = new PresentControl {Presentation = Presentation};
            m_root.Visibility = Visibility.Collapsed;
            m_plainPopup.Show (pc, OnClosePresent);
         }
      }

      void OnClosePresent (object content, object parameter)
      {
         m_root.Visibility = Visibility.Visible;
      }

      partial void Command_InsertMovieElement (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = GetCurrentSlide () != null && false;
      }

      partial void Command_InsertPhotoElement (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = GetCurrentSlide () != null && m_popup != null;
         if (canExecute && commandType == CommandType.Execute)
         {
            var searchControl = 
               new SearchControl
               {
                     SearchDelegate = s_searchDelegate,
                     SearchItemsSource = Pictures.Cast<DependencyObject> ().ToObservableCollection (),
                     SearchItemTemplate = PictureTemplate,
                  };

            m_popup.Show (searchControl, OnCloseSearchForPicture);
         }
      }

      void OnCloseSearchForPicture (object content, object parameter)
      {
         var pictureDefinition = parameter as PictureDefinition;
         var slide = GetCurrentSlide ();

         if (pictureDefinition != null && slide != null)
         {
            slide.NewPicture (pictureDefinition);
         }
      }

      partial void Command_InsertShapeElement (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = GetCurrentSlide () != null && m_popup != null;
         if (canExecute && commandType == CommandType.Execute)
         {
            var searchControl = 
               new SearchControl
               {
                     SearchDelegate = s_searchDelegate,
                     SearchItemsSource = Shapes.Cast<DependencyObject> ().ToObservableCollection (),
                     SearchItemTemplate = ShapeTemplate,
                  };

            m_popup.Show (searchControl, OnCloseSearchForShape);
         }
      }

      Slide GetCurrentSlide ()
      {
         return Presentation != null ? Presentation.CurrentSlide : null;
      }

      void OnCloseSearchForShape (object content, object parameter)
      {
         var shapeDefinition = parameter as ShapeDefinition;
         var slide = GetCurrentSlide ();

         if (shapeDefinition != null && slide != null)
         {
            slide.NewShape (shapeDefinition);
         }
      }

      partial void Command_InsertTextElement (CommandType commandType, object parameter, ref bool canExecute)
      {
         var slide = GetCurrentSlide ();
         canExecute = slide != null;

         if (canExecute && commandType == CommandType.Execute)
         {
            slide.NewText ();
         }

      }

      partial void Command_SelectLayout (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = Presentation != null && false;
      }

      partial void Command_SelectTheme (CommandType commandType, object parameter, ref bool canExecute)
      {
         canExecute = Presentation != null && false;
      }
   }
}
