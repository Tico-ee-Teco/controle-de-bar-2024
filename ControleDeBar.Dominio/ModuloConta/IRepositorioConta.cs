namespace ControleDeBar.Dominio.ModuloConta
{
    public interface IRepositorioConta
    {
        void Adicionar(Conta conta);
        bool AtualizarPedidos(Conta contaAtualizada, List<Pedido> pedidosRemovidos);
        bool AtualizarStatus(Conta contaFechada);

        Conta SelecionarPorId(int id);
        List<Conta> SelecionarTodos();

        List<Conta> SelecionarContas();
        List<Conta> SelecionarContasEmAberto();
        List<Conta> SelecionarContasFechadas();
        List<Conta> SelecionarContasFaturamento();
    }
}
