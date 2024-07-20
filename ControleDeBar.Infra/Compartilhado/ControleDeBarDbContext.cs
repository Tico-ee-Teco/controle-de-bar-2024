using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Compartilhado
{
    public class ControleDeBarDbContext : DbContext
    {
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Garcom> Garcons{ get; set; }
        public DbSet<Produto> Produtos { get; set; }          
        public DbSet<Pedido> Pedidos { get; set; }        
        public DbSet<Conta> Contas { get; set;}

        public ControleDeBarDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = 
                "Server=(localdb)\\mssqllocaldb;Database=ControleDeBarDb;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mesa>(mesaBuilder =>
            {
                mesaBuilder.ToTable("TBMesa");

                mesaBuilder.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                mesaBuilder.Property(p => p.Numero)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                mesaBuilder.Property(p => p.Ocupada)
                    .IsRequired()
                    .HasColumnType("bit");
            });

            modelBuilder.Entity<Garcom>(garcomBuilder =>
            {
                garcomBuilder.ToTable("TBGarcom");

                garcomBuilder.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                garcomBuilder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(250)");
            });

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

                contaBuidler.Property(c => c.Abertura)
                    .HasColumnType("datetime2");

                contaBuidler.Property(c => c.Fechamento)
                   .IsRequired()
                   .HasColumnType("datetime2");

                contaBuidler.Property(c => c.ContaPaga)
                    .IsRequired()
                    .HasColumnType("bit");

                contaBuidler.HasOne(c => c.Mesa)
                    .WithMany()
                    .HasForeignKey("Mesa_Id")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                contaBuidler.HasOne(c => c.Garcom)
                    .WithMany()
                    .HasForeignKey("Garcom_Id")  
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                contaBuidler.HasMany(c => c.Pedidos)
                    .WithOne()
                    .HasForeignKey("Conta_Id")
                    .HasConstraintName("FK_TBPedido_TBConta");
            });            

            base.OnModelCreating(modelBuilder);
        }
    }
}
