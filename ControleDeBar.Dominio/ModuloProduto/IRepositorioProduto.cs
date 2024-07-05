namespace ControleDeBar.Dominio.ModuloProduto
{
    public interface IRepositorioProduto
    {
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Excluir(Produto produto);

        Produto SelecionarPorId(int id);
        List<Produto> SelecionarTodos();
    }
}
