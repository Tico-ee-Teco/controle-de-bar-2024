using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

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

        public bool AtualizarPedidos(Conta contaAtualizada, List<Pedido> pedidosRemovidos)
        {
            if(contaAtualizada == null)
                return false;

            dbContext.Contas.Update(contaAtualizada);

            if (pedidosRemovidos != null && pedidosRemovidos.Any())
            {
                dbContext.Pedidos.RemoveRange(pedidosRemovidos);
            }

            dbContext.SaveChanges();

            return true;
        }

        public bool AtualizarStatus(Conta contaFechada)
        {
            return false;
        }

        public List<Conta> SelecionarContas()
        {
            return dbContext.Contas
               .Include(c => c.Mesa)
               .Include(c => c.Garcom)
               .ToList();
        }

        public List<Conta> SelecionarContasEmAberto()
        {
            return dbContext.Contas
                .Where(c => c.ContaPaga)
                .Include(c => c.Mesa)
                .Include(c => c.Garcom)
                .ToList();
        }

        public List<Conta> SelecionarContasFaturamento()
        {
            return dbContext.Contas
                .Where(c => !c.ContaPaga)
                .Include(c => c.Mesa)
                .Include(c => c.Garcom)
                .Include(c => c.Pedidos)
                .ThenInclude(p => p.Produto)
                .AsNoTracking()
                .ToList();
        }

        public List<Conta> SelecionarContasFechadas()
        {
            return dbContext.Contas
               .Where(c => !c.ContaPaga)
               .Include(c => c.Mesa)
               .Include(c => c.Garcom)
               .ToList();
        }

        public Conta SelecionarPorId(int id)
        {
           return dbContext.Contas
                .Include(c => c.Mesa)
                .Include(c => c.Garcom)
                .Include(c => c.Pedidos)
                .ThenInclude(p => p.Produto) 
                .FirstOrDefault(c => c.Id == id)!;
        }

        public List<Conta> SelecionarTodos()
        {
            return dbContext.Contas.ToList();
        }
    }
}
