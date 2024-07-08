namespace ControleDeBar.Dominio.ModuloPedido
{
    public interface IRepositorioPedido
    {
        void Adicionar(Pedido pedido);
        bool Editar(int id, Pedido pedidoAtualizado);
        bool Excluir(int id);

        Pedido SelecionarPorId(int id);
        List<Pedido> SelecionarTodos();
    }
}

