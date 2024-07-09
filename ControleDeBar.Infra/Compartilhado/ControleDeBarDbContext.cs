
using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Compartilhado
{
    public class ControleDeBarDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Conta> Contas { get; set;}

        

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

            //modelBuilder.Entity<Pedido>(pedidoBuilder =>
            //{
            //    pedidoBuilder.ToTable("TBPedido");

            //    pedidoBuilder.Property(p => p.Id)
            //        .IsRequired()
            //        .ValueGeneratedOnAdd();

            //    //pedidoBuilder.Property(p => p.NumeroPedido)
            //    //    .IsRequired()
            //    //    .HasColumnType("int");

            //    pedidoBuilder.Property(p => p.NumeroMesa)
            //        .IsRequired()
            //        .HasColumnType("int");               

            //    pedidoBuilder.Property(p => p.Qtde)
            //        .IsRequired()
            //        .HasColumnType("int");

            //    pedidoBuilder.Property(p => p.Preco)
            //       .IsRequired()
            //       .HasColumnType("decimal");

            //    pedidoBuilder.HasOne(p => p.Produto)
            //        .WithMany(x => x.Pedidos)
            //        .HasForeignKey("Produto_Id")
            //        .HasConstraintName("FK_TBPedido_TBProdutos")
            //        .OnDelete(DeleteBehavior.Restrict);                    
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
