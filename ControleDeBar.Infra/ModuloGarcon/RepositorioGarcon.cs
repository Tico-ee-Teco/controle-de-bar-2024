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

        public void Adicionar(Garcom registro)
        {
            dbContext.Garcons.Add(registro);

            dbContext.SaveChanges();
        }

        public bool Editar(Garcom registroOriginal, Garcom registroAtualizado)
        {
            if (registroOriginal == null || registroAtualizado == null)
                return false;

            registroOriginal.AtualizarRegistro(registroAtualizado);

            dbContext.Garcons.Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(Garcom registro)
        {
            if (registro == null)
                return false;

            dbContext.Garcons.Remove(registro);

            dbContext.SaveChanges();

            return true;
        }

        public Garcom SelecionarPorId(int id)
        {
            return dbContext.Garcons.Find(id)!;
        }

        public List<Garcom> SelecionarTodos()
        {
            return dbContext.Garcons.ToList();
        }

        public bool ExisteContaComGarcon(Garcom registro)
        {
            if (registro == null)
                return false;

            return dbContext.Contas.Any(c => c.Garcom.Id == registro.Id && c.ContaPaga);
        }
    }
}
