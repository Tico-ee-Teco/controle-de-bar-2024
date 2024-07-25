namespace ControleDeBar.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region configurações da aplicação e dependências da aplicação
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            #endregion

            var app = builder.Build();

            app.MapControllerRoute("rotas-padrao", "{controller}/{action}/{id?}");
            
            app.Run();
        }
       
    }
}
