using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloMesa;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControleDeBar.WebApp.Controllers;

public class MesaController: Controller
{
    [HttpGet, ActionName("listar")]
    public ViewResult ListarMesas()
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);

        List<Mesa> mesas = repositorioMesa.SelecionarTodos();

        ViewBag.Mesas = mesas;

        return View("listar-mesas");
    }

    [HttpGet, ActionName("inserir")]
    public ViewResult ExibirFormularioInserirMesa()
    {  
        return View("inserir-mesa-form");
    }

    [HttpPost, ActionName("inserir")]
    public ViewResult InserirMesas(Mesa novaMesa)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);      

        repositorioMesa.Adicionar(novaMesa);

        HttpContext.Response.StatusCode = 201; 
        
        ViewBag.Mensagem = $"O registro com o ID {novaMesa.Id} foi cadastrado com sucesso!";

        return View("mensagens-mesa");
       
    }

    [HttpGet, ActionName("editar")]
    public ViewResult ExibirFormularioEditarMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);        

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        ViewBag.Mesa = mesa;
        
        return View("editar-mesa-form");
    }

    [HttpPost, ActionName("editar")]
    public ViewResult EditarMesa(int id, Mesa mesaAtualizada)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);        

        Mesa mesaOriginal = repositorioMesa.SelecionarPorId(id);

        mesaAtualizada.Ocupada = HttpContext.Request.Form["ocupada"] == "on";

        repositorioMesa.Editar(mesaOriginal, mesaAtualizada);

        HttpContext.Response.StatusCode = 200;

        ViewBag.Mensagem = $"O registro com o ID {mesaOriginal.Id} foi editado com sucesso";
        
        return View("mensagens-mesa") ;
    }

    [HttpGet, ActionName("excluir")]
    public ViewResult ExbirFormularioExcluirMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);        

        Mesa mesa = repositorioMesa.SelecionarPorId(id);  
        
        ViewBag.Mesa = mesa;

        return View("excluir-mesa-form");
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);        

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        repositorioMesa.Excluir(mesa);

        HttpContext.Response.StatusCode = 200;      

        ViewBag.Mensagem = $"A mesa \"{mesa.Id}\" foi excluda com sucesso!";

        return View("mesangens-mesa");
    }
    [HttpGet, ActionName("detalhes")]
    public ViewResult ExibirPaginaDetalhesMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);       

        Mesa mesa = repositorioMesa.SelecionarPorId(id); 
        
        ViewBag.Mesa = mesa;

        return View("detalhes-mesa");
    }
}
