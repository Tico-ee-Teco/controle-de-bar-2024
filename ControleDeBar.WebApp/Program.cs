namespace ControleDeBar.WebApp;

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

    private static Task ListarMesas(HttpContext context)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new IRepositorioMesa(db);

        IEnumerable<string> mesasStrings = repositorioMesa
            .SelecionarTodos()
            .Select(mesa => "-> " + mesa.ToString());

        string resposta = string.Join('\n', mesasStrings);  
        context.Response.ContentType = "text/plain; charset=utf-8";
        return context.Response.WriteAsync(resposta);
    }

    private static Task OlaMundo(HttpContext context)
    {
        context.Response.ContentType = "text/plain; charset=utf-8";
        return context.Response.WriteAsync("Olá, mundo!");
    }
}