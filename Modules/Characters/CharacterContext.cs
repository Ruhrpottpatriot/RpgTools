// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterContext.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   The character context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Characters
{
    using System.Data.Entity;

    using Characters.DataContracts;

    /// <summary>The character context.</summary>
    public sealed class CharacterContext : DbContext
    {
        /// <summary>Initialises a new instance of the <see cref="CharacterContext"/> class.</summary>
        public CharacterContext()
            : base("name=RpgTools")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CharacterContext, Migrations.Configuration>(true));

            this.Characters = this.Set<CharacterDataContract>();
        }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        public DbSet<CharacterDataContract> Characters { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Characters");
        }
    }
}