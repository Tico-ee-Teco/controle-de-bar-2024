using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloGarcon;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    public class GarcomController : Controller
    {
        public ViewResult Listar()
        {
            var dbContext = new ControleDeBarDbContext();
            var repositorioGarcom = new RepositorioGarcon(dbContext);

            var garcons = repositorioGarcom.SelecionarTodos();

            ViewBag.Garcons = garcons;

            return View();
        }

        public ViewResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Inserir(Garcom garcom)
        {
            var db = new ControleDeBarDbContext();
            var repositorioGarcom = new RepositorioGarcon(db);

            repositorioGarcom.Adicionar(garcom);

            HttpContext.Response.StatusCode = 201;

            ViewBag.Mensagem = $"O Registro com o ID [{garcom.Id}] foi cadastrado com sucesso!";

            ViewBag.Link = "/garcom/listar";

            return View("mensagens");
        }

        public ViewResult Editar(int id)
        {
            var db = new ControleDeBarDbContext();
            var repositorioGarcom = new RepositorioGarcon(db);

            var garcom = repositorioGarcom.SelecionarPorId(id);

            ViewBag.Garcom = garcom;

            return View();
        }

        [HttpPost]

        public ViewResult Editar(int id, Garcom garcomAtualizado)
        {
            var db = new ControleDeBarDbContext();
            var repositorioGarcom = new RepositorioGarcon(db);

            var garcom = repositorioGarcom.SelecionarPorId(id);

            garcom.AtualizarRegistro(garcomAtualizado);

            repositorioGarcom.Editar(garcom, garcomAtualizado);

            HttpContext.Response.StatusCode = 200;

            ViewBag.Mensagem = $"O registro com o ID {garcom.Id} foi editado com sucesso";

            ViewBag.Link = "/garcom/listar";

            return View("mensagens");
        }

        public ViewResult Excluir(int id)
        {
            var db = new ControleDeBarDbContext();
            var repositorioGarcom = new RepositorioGarcon(db);

            var garcom = repositorioGarcom.SelecionarPorId(id);

            ViewBag.Garcom = garcom;

            return View();
        }

        [HttpPost, ActionName("excluir")]
        public ViewResult ExcluirConfirmado(int id)
        {
            var db = new ControleDeBarDbContext();
            var repositorioGarcom = new RepositorioGarcon(db);

            var garcom = repositorioGarcom.SelecionarPorId(id);

            repositorioGarcom.Excluir(garcom);

            HttpContext.Response.StatusCode = 200;

            ViewBag.Mensagem = $"O registro com o ID {garcom.Id} foi excluído com sucesso";

            ViewBag.Link = "/garcom/listar";

            return View("mensagens");
        }

        public ViewResult Detalhes(int id)
        {
            var db = new ControleDeBarDbContext();
            var repositorioGarcom = new RepositorioGarcon(db);

            var garcom = repositorioGarcom.SelecionarPorId(id);

            ViewBag.Garcom = garcom;

            return View();
        }

    }
}
