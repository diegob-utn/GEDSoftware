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
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public int DesarrolladorId { get; set; }
        public List<Desarrollador>? Desarrolladores { get; set; }
        public List<Tarea>? Tareas { get; set; }
    }
}
