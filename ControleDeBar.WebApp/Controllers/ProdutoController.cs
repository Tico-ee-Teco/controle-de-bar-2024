using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloProduto;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Listar()
        {
            var dbContext = new ControleDeBarDbContext();
            var repositorioProduto = new RepositorioProduto(dbContext);

            var produtos = repositorioProduto.SelecionarTodos();

            ViewBag.Produtos = produtos;

            return View();
        }
        
    }
}
