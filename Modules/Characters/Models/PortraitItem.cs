// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PortraitItem.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Represents a portrait as it is stored in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    /// <summary>Represents a portrait as it is stored in the database.</summary>
    [Table("Portraits", Schema = "Characters")]
    internal sealed class PortraitItem
    {
        /// <summary>Gets or sets the unique database identifier.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the portrait data.</summary>
        public byte[] Data { get; set; }
    }
}