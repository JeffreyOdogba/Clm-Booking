namespace Clm_Booking.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClmEntity : DbContext
    {
        public ClmEntity()
            : base("name=ClmEntity")
        {
        }

        public virtual DbSet<AdminClm> AdminClms { get; set; }
        public virtual DbSet<ClientClm> ClientClms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminClm>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<AdminClm>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<AdminClm>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<AdminClm>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);           

            modelBuilder.Entity<AdminClm>()
                .Property(e => e.securedpassword)
                .IsUnicode(false);

            modelBuilder.Entity<ClientClm>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<ClientClm>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<ClientClm>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<ClientClm>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<ClientClm>()
                .Property(e => e.comments)
                .IsUnicode(false);
        }

    }
}
