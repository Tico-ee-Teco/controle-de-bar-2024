using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloMesa;
using System.Text;

namespace ControleDeBar.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", OlaMundo);

            app.MapGet("/mesas/listar", ListarMesas);
           
            app.MapGet("/mesas/detalhes/{id:int}", ExibirPaginaDetalhesMesa);

            app.MapGet("/mesas/inserir", ExibirFormularioInserirMesa);

            app.MapPost("/mesas/inserir", InserirMesas);

            app.MapGet("/mesas/excluir/{id:int}", ExbirFormularioExcluirMesa);

            app.MapGet("/mesas/excluir/{id:int}", ExcluirMesa);

            app.Run();
        }

        private static Task ExcluirMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesa(db);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Mesa mesa = repositorioMesa.SelecionarPorId(id);

            repositorioMesa.Excluir(mesa);

            context.Response.StatusCode = 200;

            string html = File.ReadAllText("Html/mensagens-mesa.html");

            html = html.Replace("#mensagem#", $"a mesa \"{mesa.Id}\" foi excluda com sucesso!");

            return context.Response.WriteAsync(html);
        }

        private static Task ExbirFormularioExcluirMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesa(db);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Mesa mesa = repositorioMesa.SelecionarPorId(id);

            string html = File.ReadAllText("Html/excluir-mesa-form.html");

            html = html.Replace("#id#", mesa.Id.ToString());  
            
            html = html.Replace("#numeromesa#", mesa.Numero);

            context.Response.ContentType = "text/html";

            return context.Response.WriteAsync(html);
        }

        private static Task ExibirFormularioInserirMesa(HttpContext context)
        {
            string form = File.ReadAllText("Html/inserir-mesa-form.html");              

            context.Response.ContentType = "text/html; charset=utf-8 ";

            return context.Response.WriteAsync(form);
        }

        private static Task ExibirPaginaDetalhesMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesa(db);

            int id = Convert.ToInt32(context.GetRouteValue("id")!.ToString()!);

            Mesa mesa = repositorioMesa.SelecionarPorId(id);

            StringBuilder detalhes = new StringBuilder();

            detalhes.AppendLine("Id: " + mesa.Id);
            detalhes.AppendLine("Numero: " + mesa.ToString());
            detalhes.AppendLine("Status: " + (mesa.Ocupada ? "Ocupada" : "Livre"));

            if (mesa.Contas.Count > 0)
            {
                detalhes.AppendLine("Contas relacionadas à mesa:");

                foreach (Conta c in mesa.Contas)
                {
                    detalhes.AppendLine("-> " + c.ToString());
                }
            }

            context.Response.ContentType = "text/plain; charset=utf-8 ";

            return context.Response.WriteAsync(detalhes.ToString());
        }

        private static Task InserirMesas(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesa(db);

            string numero = context.Request.Form["numero"].ToString();

            Mesa novaMesa = new Mesa(numero);

            repositorioMesa.Adicionar(novaMesa);

            context.Response.StatusCode = 201;
            context.Response.ContentType = "text/html";

            string html = File.ReadAllText("Html/mensagens-mesa.html");

            html = html.Replace("#mensagem#", $"a mesa \"{novaMesa.Id}\" foi cadastrada com sucesso!");    
            
            return context.Response.WriteAsync(html);

            //string numero = context.GetRouteValue("numeroMesa")!.ToString()!;

            //Mesa novaMesa = new Mesa(numero);

            //repositorioMesa.Adicionar(novaMesa);

            //context.Response.StatusCode = 201;
            //context.Response.ContentType = "text/plain; charset=utf-8 ";

            //return context.Response.WriteAsync($"A mesa id {novaMesa.Id} foi adicionada com sucesso!");
        }

        private static Task ListarMesas(HttpContext context)
        {
            ControleDeBarDbContext db =  new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesa(db);

            List<Mesa> mesas = repositorioMesa.SelecionarTodos();

            string conteudoArquivo = File.ReadAllText("Html/listar-mesas.html");

            foreach(Mesa m in mesas)
            {
                string itemLista = $"<li>{m.ToString()}</li>#mesa#";
                conteudoArquivo = conteudoArquivo.Replace("#mesa#", itemLista);
            }

            conteudoArquivo = conteudoArquivo.Replace("#mesa#", "");

            return context.Response.WriteAsync(conteudoArquivo);
        }

        private static Task OlaMundo(HttpContext context)
        {
            context.Response.ContentType = "text/plain; charset=utf-8 ";   

             return context.Response.WriteAsync("Olá Mundo!");
        }
    }
}
