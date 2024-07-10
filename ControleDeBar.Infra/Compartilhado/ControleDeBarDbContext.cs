using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Compartilhado
{
    public class ControleDeBarDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }          
        public DbSet<Pedido> Pedidos { get; set; }        
        public DbSet<Conta> Contas { get; set;}
        
        public DbSet<Garcom> Garcom{ get; set; }

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
                produtoBuilder.ToTable("TBProduto");

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

            modelBuilder.Entity<Pedido>(pedidoBuilder => 
            {
                pedidoBuilder.ToTable("TBPedido");

                pedidoBuilder.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                pedidoBuilder.Property(p => p.Qtde)
                    .IsRequired()
                    .HasColumnType("int");

                pedidoBuilder.HasOne(p => p.Produto)
                    .WithMany()
                    .HasForeignKey("Produto_Id")
                    .HasConstraintName("FK_TBPedido_TBProduto")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Conta>(contaBuidler =>
            {
                contaBuidler.ToTable("TBConta");

                contaBuidler.Property(c => c.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                contaBuidler.Property(c => c.ContaPaga)
                    .IsRequired()
                    .HasColumnType("bit");

                contaBuidler.HasOne(c => c.Mesa)
                    .WithMany()
                    .HasForeignKey("Mesa_Id")
                    .HasConstraintName("FK_TBConta_TBMesa")
                    .OnDelete(DeleteBehavior.Restrict);

                contaBuidler.HasOne(c => c.Garcom)
                    .WithMany()
                    .HasForeignKey("Garcom_Id")
                    .HasConstraintName("FK_TBConta_TBGarcom")
                    .OnDelete(DeleteBehavior.Restrict);

                contaBuidler.HasMany(c => c.Pedidos)
                    .WithOne()
                    .HasForeignKey("Conta_Id")
                    .HasConstraintName("FK_TBPedido_TBConta")
                    .OnDelete(DeleteBehavior.Restrict);
            });           

            base.OnModelCreating(modelBuilder);
        }
    }
}
