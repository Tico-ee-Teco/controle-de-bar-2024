using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloMesa;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class MesaController: Controller
{
    
    public ViewResult Listar()
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);

        List<Mesa> mesas = repositorioMesa.SelecionarTodos();

        var listarMesasVm = mesas
            .Select(m =>
            {
                return new ListarMesaViewModels
                {
                    Id = m.Id,
                    Numero = m.Numero,
                    Ocupado = m.Ocupada ? "Ocupado" : "Livre"
                };

            });

        return View(listarMesasVm);
    }
    
    public ViewResult Inserir()
    {  
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(InserirMesaViewModel inserirMesaVm)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesa(db);

        var novaMesa = new Mesa(inserirMesaVm.Numero);

        repositorioMesa.Adicionar(novaMesa);

        HttpContext.Response.StatusCode = 201; 
        
        var mensagem = new MensagemViewModel()
        {
            Mensagem = $"O registro com o ID {novaMesa.Id} foi cadastrado com sucesso!",
            LinkRedirecionamento = "/mesa/listar"
        };

        return View("mensagens", mensagem);
    }

    
    public ViewResult Editar(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesa(db);        

        var mesa = repositorioMesa.SelecionarPorId(id);

        var editarMesaVm = new EditarMesaViewModel
        {
            Id = mesa.Id,
            Numero = mesa.Numero,
            Ocupada = mesa.Ocupada
        };
        
        return View(editarMesaVm);
    }

    [HttpPost]
    public ViewResult Editar(EditarMesaViewModel editarMesaVm)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesa(db);        

        var mesaOriginal = repositorioMesa.SelecionarPorId(editarMesaVm.Id);

        mesaOriginal.Numero = editarMesaVm.Numero;
        mesaOriginal.Ocupada = editarMesaVm.Ocupada;

        repositorioMesa.Editar(mesaOriginal);

        HttpContext.Response.StatusCode = 200;

        var mensagem = new MensagemViewModel()
        {
            Mensagem = $"O registro com o ID {mesaOriginal.Id} foi cadastrado com sucesso!",
            LinkRedirecionamento = "/mesa/listar"
        };

        return View("mensagens", mensagem) ;
    }

    
    public ViewResult Excluir(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesa(db);        

        var mesa = repositorioMesa.SelecionarPorId(Id);  
        
        var excluirMesaVm = new ExcluirMesaViewModel
        {
            Id = mesa.Id,
            Numero = mesa.Numero,
            Ocupada = mesa.Ocupada ? "Ocupada" : "Livre",
           // Contas = mesa.Contas.Select(c => new ListarContaMesaViewModel { titular = c.Titular })
        };

        return View(excluirMesaVm);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirMesa(ExcluirMesaViewModel excluirMesaVm)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesa(db);        

        var mesa = repositorioMesa.SelecionarPorId(excluirMesaVm.Id);

        repositorioMesa.Excluir(mesa);

        HttpContext.Response.StatusCode = 200;

        var mensagem = new MensagemViewModel()
        {
            Mensagem = $"O registro com o ID {mesa.Id} foi excluído com sucesso!",
            LinkRedirecionamento = "/mesa/listar"
        };

        return View("mensagens", mensagem);
    }
    
    public ViewResult Detalhes(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesa(db);       

        var mesa = repositorioMesa.SelecionarPorId(id); 
        
        var detalhesMesaVm = new DetalhesMesaViewModel
        {
            Id = mesa.Id,
            Numero = mesa.Numero,
            Ocupada = mesa.Ocupada ? "Ocupada" : "Livre",
            //Contas = mesa.Contas.Select(c => new ListarContaMesaViewModel { titular = c.Titular })
        };

        return View();
    }
}
