using ControleDeBar.Dominio.ModuloGarçon;

using ControleDeBar.Infra.Compartilhado;

namespace ControleDeBar.Infra.ModuloGarcon
{
    public class RepositorioGarcon : IRepositorioGarcon
    {
        ControleDeBarDbContext dbContext;

        public RepositorioGarcon(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Adicionar(Garcom garcom)
        {
            dbContext.Garcom.Add(garcom);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Garcom garconatualizado)
        {
            Garcom garcom = dbContext.Garcom.Find(id)!;

            if (garcom == null)
            {
                return false;
            }

            garcom.AtualizarRegistro(garconatualizado);

            dbContext.Garcom.Update(garcom);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Garcom garcom = dbContext.Garcom.Find(id)!;

            if (garcom == null)
            {
                return false;
            }

            dbContext.Garcom.Remove(garcom);
            dbContext.SaveChanges();

            return true;
        }

        public Garcom SelecionarPorId(int id)
        {
            return dbContext.Garcom.Find(id)!;
        }

        public List<Garcom> SelecionarTodos()
        {
            return dbContext.Garcom.ToList();
        }
    }
}
