namespace ControleDeBar.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.MapControllerRoute("rotas-padrao", "{controller}/{action}/{id?}");

            //app.MapGet("/", OlaMundo);

           

            app.Run();
        }
        private static Task OlaMundo(HttpContext context)
        {
            context.Response.ContentType = "text/plain; charset=utf-8 ";   

             return context.Response.WriteAsync("Olá Mundo!");
        }
    }
}
