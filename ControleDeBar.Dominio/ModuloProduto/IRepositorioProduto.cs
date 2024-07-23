using ControleDeBar.Dominio.Compartilhar;
using ControleDeBar.Dominio.ModuloMesa;

namespace ControleDeBar.Dominio.ModuloProduto
{
    public interface IRepositorioProduto : IRepositorio<Produto>
    {
        bool ExisteContaComProduto(Produto registro);
    }
}
