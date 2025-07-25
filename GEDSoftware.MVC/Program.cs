using GEDSoftware.Consumer;
using GEDSoftware.Models.Models;
using GEDSoftware.MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace GEDSoftware.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Crud<Desarrollador>.EndPoint = "https://localhost:7169/api/Desarrolladores";
            Crud<Proyecto>.EndPoint = "https://localhost:7169/api/Proyectos";
            Crud<Tarea>.EndPoint = "https://localhost:7169/api/Tareas";

            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
