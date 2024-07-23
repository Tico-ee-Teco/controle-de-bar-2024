using ControleDeBar.Dominio.Compartilhar;

namespace ControleDeBar.Dominio.ModuloGarçon
{
    public interface IRepositorioGarcon : IRepositorio<Garcom>
    {
      bool ExisteContaComGarcon(Garcom registro);
    }
}
