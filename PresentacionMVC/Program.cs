
using LogicaDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;

namespace PresentacionMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //Aca van los casos de uso 
            //builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            //builder.Services.AddScoped<IListadoUsuarios, ListadoUsuarios>();
            //builder.Services.AddScoped<IListadoRoles, ListadoRoles>();

            //Aca van los repos
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            builder.Services.AddScoped<IRepositorioRoles, RepositorioRoles>();

            //Aca contexto de la base 
            builder.Services.AddDbContext<OlimpiadasContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuarios}/{action=Index}/{id?}"); //Primero que hace al iniciar app

            app.Run();
        }
    }
}

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
