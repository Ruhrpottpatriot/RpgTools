namespace RpgTools.Main
{
    using System.Windows;

    using Caliburn.Micro;

    using MahApps.Metro.Controls;

    /// <summary>Custom window manager for the Caliburn.Micro and MahApps.Metro conbination.
    /// </summary>
    public sealed class ToolsWindowManager : WindowManager
    {
        /// <summary>Makes sure the view is a window is is wrapped by one.</summary>
        /// <param name="model">The view model.</param>
        /// <param name="view">The view.</param>
        /// <param name="isDialog">Whether or not the window is being shown as a dialog.</param>
        /// <returns>The window.</returns>
        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            MetroWindow window = view as MetroWindow;

            if (window == null)
            {
                window = new MetroWindow
                {
                    Content = view,
                    SizeToContent = SizeToContent.WidthAndHeight,
                    MinHeight = 150,
                    MinWidth = 500
                };
                
                window.SetValue(View.IsGeneratedProperty, true);
                Window owner = this.InferOwnerOf(window);

                if (owner != null)
                {
                    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    window.Owner = owner;
                }
                else
                {
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                }
            }
            else
            {
                Window owner2 = this.InferOwnerOf(window);
                if (owner2 != null && isDialog)
                {
                    window.Owner = owner2;
                }
            }

            return window;
        }
    }
}
