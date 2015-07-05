namespace RpgTools.Characters
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    /// <summary>Represents the data of a portrait.</summary>
    [Table("Portraits")]
    internal sealed class PortraitItem
    {
        /// <summary>Gets or sets the unique database identifier.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the portrait data.</summary>
        public byte[] Data { get; set; }
    }
}