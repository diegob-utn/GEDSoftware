using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDSoftware.Models.Models
{
    public class Desarrollador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public List<Proyecto>? Proyectos { get; set; } = new List<Proyecto>();
        public List<Tarea>? Tareas { get; set; } = new List<Tarea>();
    }
}
