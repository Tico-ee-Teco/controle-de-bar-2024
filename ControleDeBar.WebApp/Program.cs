using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloMesa;

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

            app.Run();
        }

        private static async Task ListarMesas(HttpContext context)
        {
            ControleDeBarDbContext db =  new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesa(db);
        }

        private static Task OlaMundo(HttpContext context)
        {
            context.Response.ContentType = "text/plain; charset=utf-8 ";   

             return context.Response.WriteAsync("Olá Mundo!");
        }
    }
}
