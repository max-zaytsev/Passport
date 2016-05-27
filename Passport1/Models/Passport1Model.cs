namespace Passport1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Passport1Model : DbContext
    {
        public Passport1Model()
            : base("name=ModelPassportDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }
        public virtual DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            
            modelBuilder.Entity<Country>()
                .Property(e => e.name);


            modelBuilder.Entity<Country>()
                .HasMany(e => e.Passports)
                .WithRequired(e => e.CountryOfBirth)
                .HasForeignKey(e => e.CountryOfBirthID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Passport>()
                .Property(e => e.PassportIssuedBy);

            modelBuilder.Entity<Passport>()
                .Property(e => e.SubdivisionCode)
                .IsFixedLength();

            modelBuilder.Entity<Passport>()
                .Property(e => e.Surname);

            modelBuilder.Entity<Passport>()
                .Property(e => e.Name);

            modelBuilder.Entity<Passport>()
                .Property(e => e.PatronymicName);

            modelBuilder.Entity<Passport>()
                .Property(e => e.TypeOfRegistration);

            modelBuilder.Entity<Passport>()
                .Property(e => e.House);

            modelBuilder.Entity<Passport>()
                .Property(e => e.Building);

            modelBuilder.Entity<Passport>()
                .Property(e => e.RegistredBy);

            modelBuilder.Entity<Region>()
                .Property(e => e.name);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Passports)
                .WithRequired(e => e.RegionOfIssue)
                .HasForeignKey(e => e.RegionOfIssueID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Passports1)
                .WithRequired(e => e.RegionOfBirth)
                .HasForeignKey(e => e.RegionOfBirthID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Passports2)
                .WithRequired(e => e.RegionOfRegistration)
                .HasForeignKey(e => e.RgionOfRegistrationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.name);

            modelBuilder.Entity<Settlement>()
                .HasMany(e => e.Passports)
                .WithRequired(e => e.SettlementOfBirth)
                .HasForeignKey(e => e.SettlementOfBirthID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Settlement>()
                .HasMany(e => e.Passports1)
                .WithRequired(e => e.SettlementOfIssue)
                .HasForeignKey(e => e.SettlementOfIssueID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Settlement>()
                .HasMany(e => e.Passports2)
                .WithRequired(e => e.SettlementOfRegistration)
                .HasForeignKey(e => e.SettlementOfRegistrationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Street>()
                .Property(e => e.name);

 
        }
    }
}
