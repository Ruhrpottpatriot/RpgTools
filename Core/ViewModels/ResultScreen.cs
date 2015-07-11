// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultScreen.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Base class for screens that return a result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.ViewModels
{
    using System.ComponentModel;
    using Caliburn.Micro;

    /// <summary>Generic base class for screens that return a result.</summary>
    /// <typeparam name="TResult">The type of the result to return.</typeparam>
    public class ResultScreen<TResult> : Screen
    {
        /// <summary>Gets or sets the result.</summary>
        public TResult Result { get; protected set; }

        /// <summary>Closes the screen with a confirmation.</summary>
        public virtual void Confirm()
        {
            this.TryClose(true);
        }

        /// <summary>Closes the screen with a cancelation.</summary>
        public virtual void Cancel()
        {
            this.TryClose(false);
        }

        /// <summary>Called when the view is closing. Does check if the closing is a cancel.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnClose(object sender, CancelEventArgs args)
        {
            if (args.Cancel)
            {
                this.TryClose(false);
            }
        }
    }
}