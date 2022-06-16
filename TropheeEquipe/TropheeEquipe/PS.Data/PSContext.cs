using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PS.Domain;
using System;
using System.Linq;

namespace PS.Data
{
    public class PSContext:DbContext
    {
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Trophee> Trohpees { get; set; }
        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Entraineur> Entraineurs { get; set; }
        public PSContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = ExamanFederation; 
                                        Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration direct dans le context
            modelBuilder.Entity<Membre>()
                .HasDiscriminator<String>("Type")
                .HasValue<Joueur>("J").HasValue<Entraineur>("E");
            //////////

            modelBuilder.Entity<Trophee>().HasOne(t => t.equipe)
                .WithMany(e => e.trophees).HasForeignKey
                (t => t.EquipeId);
            /////////
            modelBuilder.Entity<Contrat>().HasKey(v => new { v.EquipeId,
                v.MembreId, v.DateContrat });
        }
    }
}
