// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterDetailsViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the CharacterDetailsViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.CharacterPresenter.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using Caliburn.Micro;
    using Microsoft.Win32;
    using PropertyChanged;
    using RpgTools.Core.Models;
    using RpgTools.Core.ViewModels;

    /// <summary>Represents the logic for a character details view.</summary>
    [ImplementPropertyChanged]
    public class CharacterDetailsViewModel : Screen
    {
        /// <summary>Stores an instance of the window manager.</summary>
        private readonly IWindowManager windowManager;

        /// <summary>Initializes a new instance of the <see cref="CharacterDetailsViewModel"/> class.</summary>
        public CharacterDetailsViewModel()
        {
            if (Execute.InDesignMode)
            {
                this.Character = new Character(Guid.NewGuid())
                {
                    Age = 22,
                    Appearance = new Character.PhysicalAppearance
                    {
                        Bust = 89,
                        CupSize = 'C',
                        EyeColour = "Green",
                        Gender = Genders.Female,
                        HairColour = "Red",
                        Height = 186,
                        HeterochromiaIridum = true,
                        Hip = 76,
                        LipColour = "red",
                        SkinColour = "Fair",
                        Waist = 87,
                        Weight = 77
                    },
                    Metadata = new Character.CharacterMetadata
                    {
                        Occurrences = null,
                        IsAlive = true,
                        Tags = new[]
                        {
                            new Tag
                            {
                                    Value = "Protagonist",
                                    Culture = CultureInfo.InvariantCulture
                            },
                            new Tag
                            {
                                Value = "Noctus",
                                Culture = CultureInfo.InvariantCulture
                            }
                        },
                        VoiceActor = string.Empty
                    },
                    Name = "Sarah Fenix"
                };
            }
        }

        /// <summary>Initializes a new instance of the <see cref="CharacterDetailsViewModel"/> class.</summary>
        /// <param name="windowManager">The window manager.</param>
        public CharacterDetailsViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
        }

        /// <summary>Gets or sets the character.</summary>
        public Character Character { get; set; }

        /// <summary>Gets or Sets the Display Name</summary>
        public override sealed string DisplayName
        {
            get
            {
                return this.Character.Name;
            }

            set
            {
                this.Character.Name = value;
            }
        }

        /// <summary>Zooms a portrait.</summary>
        /// <param name="senderButton">The sender.</param>
        public void ZoomPortrait(Button senderButton)
        {
            if (senderButton != null)
            {
                Dictionary<string, object> settingsDictionary = new Dictionary<string, object>
                {
                    { "ResizeMode", ResizeMode.NoResize },
                    { "ShowInTaskbar", false },
                    { "WindowStyle", WindowStyle.None },
                    { "WindowStartupLocation", WindowStartupLocation.Manual }
                };

                Point location = senderButton.PointToScreen(new Point(0, 0));

                settingsDictionary.Add("Left", location.X);
                settingsDictionary.Add("Top", location.Y);

                CharacterPortraitViewModel characterPortraitViewModel = new CharacterPortraitViewModel(this.Character.Portrait);

                this.windowManager.ShowWindow(characterPortraitViewModel, null, settingsDictionary);
            }
        }

        /// <summary>Changes a character portrait.</summary>
        public void ChangePortrait()
        {
            // ToDo: Implement this in a way, so it does not violate the MVVM pattern.
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Select Portrait",
                Multiselect = false,
                Filter = "Images (.jpg, .png)| *.jpg; *.png"
            };

            fileDialog.FileOk += this.FileDialogFileOk;

            fileDialog.ShowDialog();
        }

        /// <summary>Deletes a character portrait.</summary>
        public void DeletePortrait()
        {
            ConfirmationViewModel confirmationViewModel = new ConfirmationViewModel("Delete Portrait?", "Do you really want to delete the portrait?");

            Dictionary<string, object> settingsDictionary = new Dictionary<string, object>
            {
                { "ResizeMode", ResizeMode.NoResize }
            };

            bool? answer = this.windowManager.ShowDialog(confirmationViewModel, null, settingsDictionary);

            if (answer != null && answer == true)
            {
                this.Character.Portrait = null;
            }
        }

        /// <summary>Event to handle the image when the user hits the ok button with a file selected.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void FileDialogFileOk(object sender, CancelEventArgs eventArgs)
        {
            string file = ((OpenFileDialog)sender).FileName;

            BitmapImage image = new BitmapImage(new Uri(file));

            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            this.Character.Portrait = data;
        }
    }
}