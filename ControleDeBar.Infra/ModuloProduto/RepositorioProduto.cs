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

        public void Editar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Produto produto)
        {
            throw new NotImplementedException();
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
