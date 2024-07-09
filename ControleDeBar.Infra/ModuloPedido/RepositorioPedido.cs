using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Infra.Compartilhado;

namespace ControleDeBar.Infra.ModuloPedido
{
    public class RepositorioPedido : IRepositorioPedido
    {
        public void Adicionar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public bool Editar(int id, Pedido pedidoAtualizado)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Pedido SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
