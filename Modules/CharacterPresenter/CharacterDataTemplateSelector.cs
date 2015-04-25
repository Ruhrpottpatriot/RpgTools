namespace RpgTools.CharacterPresenter
{
    using System.Windows;
    using System.Windows.Controls;

    public class CharacterDataTemplateSelector :DataTemplateSelector
    {
        public DataTemplate Metadata { get; set; }

        public DataTemplate Appearance { get; set; }

        /// <summary>
        /// When overridden in a derived class, returns a <see cref="T:System.Windows.DataTemplate"/> based on custom logic.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="T:System.Windows.DataTemplate"/> or null. The default value is null.
        /// </returns>
        /// <param name="item">The data object for which to select the template.</param><param name="container">The data-bound object.</param>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return null;
        }
    }
}
