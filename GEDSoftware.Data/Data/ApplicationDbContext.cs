using GEDSoftware.Models.Models;
using Microsoft.AspNetCore.Identity; // Ensure this namespace matches your project structure
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GEDSoftware.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Desarrollador> Desarrolladores { get; set; }

    }
}
