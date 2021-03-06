﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharactersViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   View model to display general character data and operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.CharacterPresenter.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows;
    using Caliburn.Micro;
    using PropertyChanged;
    using RpgTools.Core;
    using RpgTools.Core.Common;
    using RpgTools.Core.Contracts;
    using RpgTools.Core.Models;
    using RpgTools.Core.ViewModels;

    /// <summary>View model to display general character data and operations.</summary>
    [ImplementPropertyChanged]
    [RpgModuleMetadata(Name = "Characters")]
    [Export(typeof(IRpgModuleContract))]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Methods are loosly bound by Caliburn.Micro")]
    public class CharactersViewModel : Conductor<CharacterDetailsViewModel>.Collection.OneActive, IRpgModuleContract
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // -------------------------------------------------------------------------------------------------------------------

        /// <summary>Holds a reference to the character repository.</summary>
        private readonly ICharacterRepository characterRepository;

        /// <summary>Holds a reference to the tags repository.</summary>
        private readonly ITagsRepository tagsRepository;

        /// <summary>Holds a reference to the window manager.</summary>
        private readonly IWindowManager windowManager;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="CharactersViewModel"/> class.</summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Reviewed")]
        public CharactersViewModel()
        {
            if (Execute.InDesignMode)
            {
                this.SelectorVisible = true;
                this.CheckListItems = new ObservableCollection<CheckListItem>
                                      {
                                          new CheckListItem("All", true),
                                          new CheckListItem("N/A", false)
                                      };

                var guids = new[] { Guid.NewGuid(), Guid.NewGuid() };

                this.Characters = new DictionaryRange<Guid, Character>
                                  {
                                      {
                                          guids[0],
                                          new Character(guids[0]) { Name = "Ravia Hagen" }
                                      },
                                      {
                                          guids[1],
                                          new Character(guids[1]) { Name = "Sarah Fenix" }
                                      }
                                  };
            }
        }

        /// <summary>Initializes a new instance of the <see cref="CharactersViewModel"/> class.</summary>
        /// <param name="windowManager">The window manager instance.</param>
        /// <param name="tagsRepository">The tags repository.</param>
        /// <param name="characterRepository">The character repository.</param>
        [ImportingConstructor, SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Reviewed")]
        public CharactersViewModel(IWindowManager windowManager, ITagsRepository tagsRepository, ICharacterRepository characterRepository)
        {
            this.windowManager = windowManager;
            this.tagsRepository = tagsRepository;
            this.characterRepository = characterRepository;

            // Set the initial visibilities of controls.
            this.SelectorVisible = true;
            this.SaveButtonVisible = false;
            this.TabControlVisible = false;

            // Generate the check list items
            this.CheckListItems = new ObservableCollection<CheckListItem>();
            this.CheckListItems.Insert(0, new CheckListItem(Constants.AllOptions, true));
            this.CheckListItems.Insert(1, new CheckListItem(Constants.NotAvailable, true));
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // -------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets or sets a value indicating whether the character selector is visible.</summary>
        public bool SelectorVisible { get; set; }

        /// <summary>Gets or sets a value indicating whether the save button is visible.</summary>
        public bool SaveButtonVisible { get; set; }

        /// <summary>Gets or sets a value indicating whether the tab control is visible.
        /// </summary>
        public bool TabControlVisible { get; set; }

        /// <summary>Gets or sets the characters.</summary>
        public IDictionaryRange<Guid, Character> Characters { get; set; }

        /// <summary>Gets or sets the check list items.</summary>
        public ObservableCollection<CheckListItem> CheckListItems { get; set; }

        // --------------------------------------------------------------------------------------------------------------------
        // Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Toggles the character selector.</summary>
        public void ToggleSelector()
        {
            this.SelectorVisible = !this.SelectorVisible;
        }

        /// <summary>Opens a tab based on a <see cref="CharacterDetailsViewModel"/>.</summary>
        /// <param name="character">The character to open the tab for.</param>
        public void OpenTab(KeyValuePair<Guid, Character> character)
        {
            this.TabControlVisible = true;

            if (this.Items.All(s => s.DisplayName != character.Value.Name) && character.Value != null)
            {
                // Make the tab control viosible to the user.
                this.TabControlVisible = true;

                this.ActivateItem(new CharacterDetailsViewModel(this.windowManager)
                {
                    Character = character.Value
                });

                this.SelectorVisible = false;
                this.SaveButtonVisible = true;
            }
        }

        /// <summary>Closes a character tab and hides the tab control if there are no more items in the collection.</summary>
        /// <param name="detailsViewModel">The view model that is going to be closed.</param>
        public void CloseTab(CharacterDetailsViewModel detailsViewModel)
        {
            this.CloseItem(detailsViewModel);

            if (!this.Items.Any())
            {
                this.TabControlVisible = false;
                this.SelectorVisible = true;
                this.SaveButtonVisible = false;
            }
        }

        /// <summary>Loads all characters from the repository.</summary>
        public async void LoadCharacters()
        {
            this.Characters = await this.characterRepository.FindAllAsync();
        }

        /// <summary>Filters the characters based on the check list item selection.</summary>
        public async void FilterCharacters()
        {
            if (this.Characters == null)
            {
                return;
            }

            if (this.CheckListItems.Any(i => (i.Name == Constants.AllOptions && (i.IsChecked != null && (bool)i.IsChecked))))
            {
                this.Characters = await this.characterRepository.FindAllAsync();
                return;
            }

            var checkedItems = this.CheckListItems.Where(i => (i.IsChecked != null && (bool)i.IsChecked));

            this.Characters = new DictionaryRange<Guid, Character>((await this.characterRepository.FindAllAsync()).Where(c => c.Value.Metadata.Tags.Any(t => checkedItems.Any(i => i.Name == t.Value))).ToDictionary(x => x.Key, x => x.Value));
        }

        /// <summary>Updates the check list.</summary>
        /// <param name="sender">The name of the item that changed.</param>
        /// <param name="isChecked">A value whether the item is checked or not.</param>
        public void UpdateChecklist(string sender, bool isChecked)
        {
            // Check if the character list has been loaded, if not return
            if (this.Characters == null)
            {
                return;
            }

            // Check if the sender was the "all" item.
            if (sender == Constants.AllOptions)
            {
                // set all items to be set if "isChecked" was set to true.
                if (isChecked)
                {
                    foreach (CheckListItem item in this.CheckListItems)
                    {
                        item.IsChecked = true;
                    }
                }
                else
                {
                    foreach (CheckListItem item in this.CheckListItems)
                    {
                        item.IsChecked = false;
                    }
                }
            }
            else
            {
                // Since we didn't change the all item
                // we have to check if all others are checked
                // to determine the correct state of the all item.
                var allItem = this.CheckListItems.Single(i => i.Name == Constants.AllOptions);

                var itemsWithoutAll = new List<CheckListItem>(this.CheckListItems.Where(i => i != allItem));

                if (itemsWithoutAll.All(i => i.IsChecked != null && (bool)i.IsChecked))
                {
                    allItem.IsChecked = true;
                }
                else if (itemsWithoutAll.Any(i => i.IsChecked != null && (bool)i.IsChecked))
                {
                    allItem.IsChecked = null;
                }
                else
                {
                    allItem.IsChecked = false;
                }
            }
        }

        /// <summary>Generates the check list based on character tags.</summary>
        public async void GenerateCheckListItems()
        {
            foreach (Tag tag in (await this.tagsRepository.FindByTypeAsync("Character")).Values)
            {
                var item = new CheckListItem(tag.Value, true);

                if (this.CheckListItems.All(i => i.Name != item.Name))
                {
                    this.CheckListItems.Add(item);
                }
            }
        }

        /// <summary>Opens the character creation window.</summary>
        public async void CreateCharacter()
        {
            CharacterDetailsViewModel viewModel = new CharacterDetailsViewModel(this.windowManager)
            {
                Character = new Character(Guid.NewGuid())
            };

            Dictionary<string, object> settingsDictionary = new Dictionary<string, object>
            {
                { "ResizeMode", ResizeMode.NoResize }
            };

            bool? answer = this.windowManager.ShowDialog(viewModel, null, settingsDictionary);

            if (answer.HasValue && answer.Value)
            {
                await this.characterRepository.CreateAsync(new DataContainer<Character> { Content = viewModel.Character });
            }

            this.FilterCharacters();
        }

        /// <summary>Saves a character to the repository.</summary>
        /// <param name="viewModel">The view model of the character to save.</param>
        public async void Save(CharacterDetailsViewModel viewModel)
        {
            Character character = viewModel.Character;

            await this.characterRepository.UpdateAsync(new DataContainer<Character> { Content = character });

            this.CloseTab(viewModel);
            this.OpenTab(new KeyValuePair<Guid, Character>(character.Id, character));
        }

        /// <summary>Deletes a character from the repository.</summary>
        /// <param name="viewModel">The view model of the character to delete.</param>
        public async void Delete(CharacterDetailsViewModel viewModel)
        {
            Character character = viewModel.Character;
            ConfirmationViewModel confirmationViewModel = new ConfirmationViewModel("Delete Character", string.Format("Do you want to delete {0} ({1})", character.Name, character.Id));

            Dictionary<string, object> settingsDictionary = new Dictionary<string, object>
            {
                { "ResizeMode", ResizeMode.NoResize }
            };

            bool? answer = this.windowManager.ShowDialog(confirmationViewModel, null, settingsDictionary);

            if (answer != null && answer == true)
            {
                this.Characters.Remove(character.Id);
                await this.characterRepository.DeleteAsync(character.Id);
            }
        }
    }
}
