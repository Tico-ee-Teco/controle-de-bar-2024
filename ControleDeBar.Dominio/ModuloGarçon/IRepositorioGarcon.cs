using ControleDeBar.Dominio.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Dominio.ModuloGarçon
{
    public interface IRepositorioGarcon
    {
        void Adicionar(Garcom garcom);
        bool Editar(int id, Garcom garcom);
        bool Excluir(int id);

        Produto SelecionarPorId(int id);
        List<Garcom> SelecionarTodos();
    }
}
