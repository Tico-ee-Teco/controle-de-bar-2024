using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Compartilhado;

namespace ControleDeBar.Infra.ModuloProduto
{
    public class RepositorioProduto : IRepositorioProduto
    {
        ControleDeBarDbContext dbContext;

        public RepositorioProduto(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Adicionar(Produto registro)
        {
            dbContext.Produtos.Add(registro);

            dbContext.SaveChanges();
        }

        public bool Editar(Produto registroOriginal, Produto registroAtualizado)
        {
            if (registroOriginal == null || registroAtualizado == null)
                return false;

            registroOriginal.AtualizarRegistro(registroAtualizado);

            dbContext.Produtos.Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(Produto registro)
        {
            if (registro == null)
                return false;

            dbContext.Produtos.Remove(registro);

            dbContext.SaveChanges();

            return true;
        }

        public Produto SelecionarPorId(int id)
        {
            return dbContext.Produtos.Find(id)!;
        }

        public List<Produto> SelecionarTodos()
        {
            return dbContext.Produtos.ToList();
        }

        public bool ExisteProdutoComPedido(Produto registro)
        {
            return dbContext.Pedidos.Any(p => p.Produto.Id == registro.Id);
        }
        public bool ExisteContaComProduto(Produto registro)
        {
            if (registro == null)
                return false;

            return dbContext.Contas.Any(c => c.Pedidos.Any(p => p.Produto.Id == registro.Id) && c.ContaPaga);
        }
    }
}


