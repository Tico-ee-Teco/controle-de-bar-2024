using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloMesa;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class MesaController: Controller
{
    
    public ViewResult Listar()
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);

        List<Mesa> mesas = repositorioMesa.SelecionarTodos();

        ViewBag.Mesas = mesas;

        return View();
    }

    
    public ViewResult Inserir()
    {  
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(Mesa novaMesa)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);      

        repositorioMesa.Adicionar(novaMesa);

        HttpContext.Response.StatusCode = 201; 
        
        ViewBag.Mensagem = $"O registro com o ID {novaMesa.Id} foi cadastrado com sucesso!";

        return View("mensagens");
       
    }

    
    public ViewResult Editar(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);        

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        ViewBag.Mesa = mesa;
        
        return View();
    }

    [HttpPost]
    public ViewResult Editar(int id, Mesa mesaAtualizada)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);        

        Mesa mesaOriginal = repositorioMesa.SelecionarPorId(id);

        mesaAtualizada.Ocupada = HttpContext.Request.Form["ocupada"] == "on";

        repositorioMesa.Editar(mesaOriginal, mesaAtualizada);

        HttpContext.Response.StatusCode = 200;

        ViewBag.Mensagem = $"O registro com o ID {mesaOriginal.Id} foi editado com sucesso";
        
        return View("mensagens") ;
    }

    
    public ViewResult Excluir(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);        

        Mesa mesa = repositorioMesa.SelecionarPorId(id);  
        
        ViewBag.Mesa = mesa;

        return View();
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

        return View("mesangens");
    }
    
    public ViewResult Detalhes(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);       

        Mesa mesa = repositorioMesa.SelecionarPorId(id); 
        
        ViewBag.Mesa = mesa;

        return View();
    }
}
