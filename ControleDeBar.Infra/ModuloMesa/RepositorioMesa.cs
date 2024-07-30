
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;


namespace ControleDeBar.Infra.ModuloMesa
{
    public class RepositorioMesa : RepositorioBaseEmOrm<Mesa>, IRepositorioMesa
    {
        ControleDeBarDbContext dbContext;

        public RepositorioMesa(ControleDeBarDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Mesa> ObterRegistros()
        {
            return dbContext.Mesas;
        }

        public override Mesa SelecionarPorId(int id)
        {
            return dbContext.Mesas
                //.Include(m => m.Contas)
                .FirstOrDefault(m => m.Id == id)!;
        }

        public bool ExisteContaComMesa(Mesa registro)
        {
            throw new NotImplementedException();
        }
    }
}
