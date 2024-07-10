using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Dominio.ModuloMesa
{
    internal interface IRepositorioMesa 
    {
        void Adicionar(Mesa mesa);
        bool Editar(int id, Mesa mesa);
        bool Excluir(int id);

        Mesa SelecionarPorId(int id);
        List<Mesa> SelecionarTodas();

        void AssociarConta(int idMesa, Conta conta);
        void DesassociarConta(int idMesa);
    }
}
