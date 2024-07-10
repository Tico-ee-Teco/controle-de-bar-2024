using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Compartilhado
{
    public class ControleDeBarDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Garcom> Garcom{ get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = 
                "Server=(localdb)\\mssqllocaldb;Database=ControleDeBarDb;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(produtoBuilder =>
            {
                produtoBuilder.ToTable("TBProdutos");

                produtoBuilder.Property(p => p.Id)
                    .IsRequired()                
                    .ValueGeneratedOnAdd();

                produtoBuilder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

                produtoBuilder.Property(p => p.Valor)
                    .IsRequired()
                    .HasColumnType("decimal");
            });

            modelBuilder.Entity<Garcom>(GarcomBuilder =>
            {
                GarcomBuilder.ToTable("TBGarcom");

                GarcomBuilder.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                GarcomBuilder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(250)");
            });
            modelBuilder.Entity<Mesa>(produtoBuilder =>
            {
                produtoBuilder.ToTable("TBMesa");

                produtoBuilder.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                produtoBuilder.Property(p => p.Numero)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

                produtoBuilder.Property(p => p.Ocupada)
                    .IsRequired()
                    .HasColumnType("varchar(250)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
