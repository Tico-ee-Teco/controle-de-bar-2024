
namespace ControleDeBar.Dominio.ModuloMesa
{
    public interface IRepositorioMesa 
    {
        void Adicionar(Mesa mesa);
        bool Editar(int id, Mesa mesa);
        bool Excluir(int id);

        Mesa SelecionarPorId(int id);
        List<Mesa> SelecionarTodos();
    }
}
