// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmationViewModel.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the ConfirmationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.ViewModels
{
    using Caliburn.Micro;
    using PropertyChanged;

    /// <summary>Represents the logic for a confirmation window.</summary>
    [ImplementPropertyChanged]
    public sealed class ConfirmationViewModel : ResultScreen<bool>
    {
        /// <summary>Stores the message.</summary>
        private string message;

        /// <summary>Initializes a new instance of the <see cref="ConfirmationViewModel"/> class.</summary>
        public ConfirmationViewModel()
        {
            if (Execute.InDesignMode)
            {
                this.Message = "Do you want to do something?";
            }
        }

        /// <summary>Initializes a new instance of the <see cref="ConfirmationViewModel"/> class.</summary>
        /// <param name="title">The window title.</param>
        /// <param name="message">The window message.</param>
        public ConfirmationViewModel(string title, string message)
            : this()
        {
            this.Message = message;
            this.DisplayName = title;
        }

        /// <summary>Gets or sets the message.</summary>
        public string Message
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.message) ? "Are you sure?" : this.message;
            }

            set
            {
                this.message = value;
            }
        }
    }
}
