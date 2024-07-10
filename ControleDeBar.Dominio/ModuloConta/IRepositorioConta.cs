namespace ControleDeBar.Dominio.ModuloConta
{
    public interface IRepositorioConta
    {
        void Adicionar(Conta conta);
        bool Editar(int id, Conta contaAtualizada);
        bool Excluir(int id);

        Conta SelecionarPorId(int id);
        List<Conta> SelecionarTodos();
    }
}
