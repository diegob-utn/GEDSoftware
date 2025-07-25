using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDSoftware.Models.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechacreacion { get; set; }
        public DateTime fechalimite { get; set; }
        public string prioridad { get; set; }
        public string estado { get; set; }
        public int desarrolladorId { get; set; }
        public List<Desarrollador>? desarrolladores { get; set; } // Navigation property to Desarrollador
        public List<Tarea>? tareas { get; set; } // Navigation property to Tareas
    }
}
