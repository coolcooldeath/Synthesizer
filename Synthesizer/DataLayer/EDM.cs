using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Synthesizer.DataLayer
{
    public partial class EDM : DbContext
    {
        public EDM()
            : base("name=EDM1")
        {
        }

        public virtual DbSet<factory> factory { get; set; }
        public virtual DbSet<Syntheses> Syntheses { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<factory>()
                .HasMany(e => e.Syntheses)
                .WithOptional(e => e.factory)
                .HasForeignKey(e => e.FactId);

            modelBuilder.Entity<users>()
                .HasMany(e => e.factory)
                .WithRequired(e => e.users)
                .WillCascadeOnDelete(false);
        }
    }
}
