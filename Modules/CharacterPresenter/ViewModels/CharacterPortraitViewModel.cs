// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterPortraitViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   The character portrait view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.CharacterPresenter.ViewModels
{
    using Caliburn.Micro;
    using PropertyChanged;

    /// <summary>The character portrait view model.</summary>
    [ImplementPropertyChanged]
    public class CharacterPortraitViewModel : Screen
    {
        public CharacterPortraitViewModel()
        {
            if (Execute.InDesignMode)
            {
                this.Portrait = null;
            }
        }

        /// <summary>Initialises a new instance of the <see cref="CharacterPortraitViewModel"/> class.</summary>
        /// <param name="portrait">The portrait to show.</param>
        public CharacterPortraitViewModel(byte[] portrait)
        {
            this.Portrait = portrait;
        }

        /// <summary>Gets or sets the character image.</summary>
        public byte[] Portrait { get; set; }

        /// <summary>Closes the window.</summary>
        public void Close()
        {
            this.TryClose();
        }
    }
}