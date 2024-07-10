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

        public void Adicionar(Mesa mesa)
        {
            dbContext.Mesas.Add(mesa);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Mesa mesaAtualizada)
        {
            Mesa mesa = dbContext.Mesas.Find(id)!;

            if (mesa == null)
            {
                return false;
            }

            mesa.AtualizarRegistro(mesaAtualizada);

            dbContext.Mesas.Update(mesa);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Mesa mesa = dbContext.Mesas.Find(id)!;

            if (mesa == null)
            {
                return false;
            }

            dbContext.Mesas.Remove(mesa);
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
    }
}
