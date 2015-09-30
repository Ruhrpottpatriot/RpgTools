// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckListItem.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   The check list item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System.Diagnostics.CodeAnalysis;

    using PropertyChanged;

    /// <summary>The check list item.</summary>
    [ImplementPropertyChanged]
    public class CheckListItem
    {
        /// <summary>Initializes a new instance of the <see cref="CheckListItem"/> class.</summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="isChecked">Value whether the item is checked.</param>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Reviewed")]
        public CheckListItem(string name, bool isChecked)
        {
            this.Name = name;
            this.IsChecked = isChecked;
        }

        /// <summary>Gets or sets the display name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets a value indicating whether the item is selected.</summary>
        public bool? IsChecked { get; set; }
    }
}
