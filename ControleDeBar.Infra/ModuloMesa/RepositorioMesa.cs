using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Compartilhado;

namespace ControleDeBar.Infra.ModuloMesa
{
    public class RepositorioMesa : IRepositorioMesa
    {
        ControleDeBarDbContext dbContext;

        public RepositorioMesa(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Adicionar(Mesa registro)
        {
            dbContext.Mesas.Add(registro);

            dbContext.SaveChanges();
        }

        public bool Editar(Mesa registroOriginal, Mesa registroAtualizado)
        {
            if (registroOriginal == null || registroAtualizado == null)
                return false;

            registroOriginal.AtualizarRegistro(registroAtualizado);

            dbContext.Mesas.Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(Mesa registro)
        {
            if (registro == null)
                return false;            

            dbContext.Mesas.Remove(registro);

            dbContext.SaveChanges();

            return true;
        }

        public Mesa SelecionarPorId(int id)
        {
            return dbContext.Mesas.Find(id)!;
        }

        public List<Mesa> SelecionarTodos()
        {
            return dbContext.Mesas.ToList();
        }

        public bool ExisteContaComMesa(Mesa registro)
        {
            if (registro == null)
                return false;            

            return dbContext.Contas.Any(c => c.Mesa.Id == registro.Id && c.ContaPaga);
        }
    }
}
