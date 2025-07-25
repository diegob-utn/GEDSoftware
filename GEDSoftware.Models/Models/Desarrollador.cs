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
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public List<Proyecto>? Proyectos { get; set; }
        public List<Tarea>? Tareas { get; set; }
    }
}
