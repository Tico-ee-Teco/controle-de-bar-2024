using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloGarcon;
using ControleDeBar.Infra.ModuloProduto;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        public ViewResult Listar()
        {
            var dbContext = new ControleDeBarDbContext();
            var repositorioProduto = new RepositorioProduto(dbContext);

            var produtos = repositorioProduto.SelecionarTodos();

            ViewBag.Produtos = produtos;

            return View();
        }

        public ViewResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Inserir(Produto novoProduto)
        {
            var dbContext = new ControleDeBarDbContext();
            var repositorioProduto = new RepositorioProduto(dbContext);

            repositorioProduto.Adicionar(novoProduto);

            ViewBag.Mensagem = $"O registro com o id {novoProduto.Id} fpo cadastrado com sucesso!";
            ViewBag.Link = "/produto/listar";

            HttpContext.Response.StatusCode = 201;

            return View("mensagens");
        }

        public ViewResult Editar(int id)
        {
            var db = new ControleDeBarDbContext();
            var repositorioProduto = new RepositorioProduto(db);

            var produto = repositorioProduto.SelecionarPorId(id);

            ViewBag.Produto = produto;

            return View();
        }

        [HttpPost]
        public ViewResult Editar(int id, Produto produtoAtualizado)
        {
            var db = new ControleDeBarDbContext();
            var repositorioProduto = new RepositorioProduto(db);

            var produto = repositorioProduto.SelecionarPorId(id);

            produto.AtualizarRegistro(produtoAtualizado);

            repositorioProduto.Editar(produto, produtoAtualizado);

            HttpContext.Response.StatusCode = 200;

            ViewBag.Mensagem = $"O registro com o id {produtoAtualizado.Id} foi editado com sucesso!";
            ViewBag.Link = "/produto/listar";

            return View("mensagens");
        }

        public ViewResult Excluir(int id)
        {
            var db = new ControleDeBarDbContext();
            var repositorioProduto = new RepositorioProduto(db);

            var produto = repositorioProduto.SelecionarPorId(id);

            ViewBag.Produto = produto;

            return View();
        }

        [HttpPost, ActionName("excluir")]
        public ViewResult ExcluirConfirmado(int id)
        {
           
            var db = new ControleDeBarDbContext();
            var repositorioProduto = new RepositorioProduto(db);

            var produto = repositorioProduto.SelecionarPorId(id);

            repositorioProduto.Excluir(produto);

            HttpContext.Response.StatusCode = 200;

            ViewBag.Mensagem = $"O registro com o id {produto.Id} foi excluído com sucesso!";
            ViewBag.Link = "/produto/listar";

            return View("mensagens");

        }
    }
}
