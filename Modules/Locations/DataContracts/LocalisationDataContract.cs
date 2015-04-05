// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalisationDataContract.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Defines the LocalisationDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Locations.DataContracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Localisations")]
    internal class LocalisationDataContract
    {
        [Key, ForeignKey("Location")]
        public Guid EntryId { get; set; }

        public string Culture { get; set; }

        public LocationDataContract Location { get; set; }
    }
}
