namespace ControleDeBar.Dominio.ModuloGarçon
{
    public interface IRepositorioGarcon
    {
        void Adicionar(Garcom garcom);
        bool Editar(int id, Garcom garcom);
        bool Excluir(int id);

        Garcom SelecionarPorId(int id);
        List<Garcom> SelecionarTodos();
    }
}
