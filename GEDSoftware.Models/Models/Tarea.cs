using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDSoftware.Models.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechacreacion { get; set; }
        public DateTime fechalimite { get; set; }
        public string prioridad { get; set; }
        public string estado { get; set; }
        public int desarrolladorId { get; set; }
        public int proyectoId { get; set; } // Foreign key to Proyectos

        public Proyecto? proyecto { get; set; } // Navigation property to Proyectos
        public Desarrollador? desarrollador { get; set; }
    }
}
