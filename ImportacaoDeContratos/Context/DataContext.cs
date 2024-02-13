using ImportacaoDeContratos.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace ImportacaoDeContratos.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=C@Io;Persist Security Info=True;User ID=sa;Initial Catalog=BDContratos;Data Source=NEXUM-000006");
        }

        public DbSet<Contratos> Contrato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contratos>().HasNoKey();
            modelBuilder.Entity<Contratos>().Property(c => c.Valor).HasPrecision(18, 2); // Adjust precision and scale as needed
        }

    }
}
