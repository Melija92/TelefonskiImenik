using System.Data.Entity;
using TelefonskiImenik.Model;

namespace TelefonskiImenik.DataLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {

        }

        public DbSet<Kontakt> Kontakti { get; set; }
        public DbSet<Grad> Gradovi { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grad>().ToTable("Gradovi");
            modelBuilder.Entity<Kontakt>().ToTable("Kontatki");
            //modelBuilder.Entity<Broj>().ToTable("Brojevi");

            //konfiguiranje propertya
            modelBuilder.Entity<Kontakt>().Property(a => a.Ime).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Kontakt>().Property(a => a.Prezime).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Kontakt>().Property(a => a.Opis).HasMaxLength(100).IsOptional();

            //modelBuilder.Entity<Broj>().Property(a => a.SadrzajBroja).HasMaxLength(15).IsRequired();
            //modelBuilder.Entity<Broj>().Property(a => a.Opis).HasMaxLength(100).IsOptional();
            //modelBuilder.Entity<Broj>().Property(a => a.TipBroja).HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Grad>().Property(a => a.NazivGrada).HasMaxLength(25).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}

