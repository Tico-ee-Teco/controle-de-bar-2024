using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
