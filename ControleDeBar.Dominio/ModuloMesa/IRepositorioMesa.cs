using ControleDeBar.Dominio.Compartilhar;

namespace ControleDeBar.Dominio.ModuloMesa
{
    public interface IRepositorioMesa : IRepositorio<Mesa>
    {
        bool ExisteContaComMesa(Mesa registro);
    }
}
