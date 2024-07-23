
namespace ControleDeBar.Dominio.Compartilhar
{
    public interface IRepositorio<TEntidade> where TEntidade : EntidadeBase
    {
        void Adicionar(TEntidade registro);
        bool Editar(TEntidade registroOriginal, TEntidade registroAtualizado);
        bool Excluir(TEntidade registro);
        TEntidade SelecionarPorId(int id);
        List<TEntidade> SelecionarTodos();
        
    }
}
