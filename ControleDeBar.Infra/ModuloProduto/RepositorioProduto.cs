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

        public void Adicionar(Produto produto)
        {
            dbContext.Produtos.Add(produto);
            dbContext.SaveChanges();
        }

        public bool Editar(int id,Produto produtoAtualizado)
        {
            Produto produto = dbContext.Produtos.Find(id)!;

            if(produto == null)
            {
                return false;
            }

            produto.AtualizarRegistro(produtoAtualizado);

            dbContext.Produtos.Update(produto);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Produto produto = dbContext.Produtos.Find(id)!;

            if(produto == null)
            {
                return false;
            }

            dbContext.Produtos.Remove(produto);
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
    }
}
