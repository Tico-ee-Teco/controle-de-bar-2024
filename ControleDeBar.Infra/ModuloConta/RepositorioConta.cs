using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infra.Compartilhado;

namespace ControleDeBar.Infra.ModuloConta
{
    public class RepositorioConta : IRepositorioConta
    {
        ControleDeBarDbContext dbContext;

        public RepositorioConta(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Adicionar(Conta conta)
        {
            
            dbContext.Contas.Add(conta);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Conta contaAtualizada)
        {
            Conta conta = dbContext.Contas.Find(id)!;

            if (conta == null)
            {
                return false;
            }

            conta.AtualizarRegistro(contaAtualizada);

            dbContext.Contas.Update(conta);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Conta conta = dbContext.Contas.Find(id)!;

            if (conta == null)
            {
                return false;
            }

            dbContext.Contas.Remove(conta);
            dbContext.SaveChanges();

            return true;
        }

        public Conta SelecionarPorId(int id)
        {
            return dbContext.Contas.Find(id)!;
        }

        public List<Conta> SelecionarTodos()
        {
            return dbContext.Contas.ToList();
        }
    }
}
