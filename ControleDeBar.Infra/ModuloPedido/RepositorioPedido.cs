using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Infra.Compartilhado;

namespace ControleDeBar.Infra.ModuloPedido
{
    public class RepositorioPedido : IRepositorioPedido
    {
        ControleDeBarDbContext dbContext;
        public RepositorioPedido(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Adicionar(Pedido pedido)
        {
            dbContext.Pedidos.Add(pedido);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Pedido pedidoAtualizado)
        {
            Pedido pedido = dbContext.Pedidos.Find(id)!;

            if (pedido == null)
            {
                return false;
            }

            pedido.AtualizarRegistro(pedidoAtualizado);

            dbContext.Pedidos.Update(pedido);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Pedido pedido = dbContext.Pedidos.Find(id)!;

            if (pedido == null)
            {
                return false;
            }

            dbContext.Pedidos.Remove(pedido);
            dbContext.SaveChanges();

            return true;
        }

        public Pedido SelecionarPorId(int id)
        {
            return dbContext.Pedidos.Find(id)!;
        }

        public List<Pedido> SelecionarTodos()
        {
            return dbContext.Pedidos.ToList();
        }
    }
}
