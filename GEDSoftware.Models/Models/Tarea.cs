using System;
using System.Collections.Generic;

namespace GEDSoftware.Models.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public int DesarrolladorId { get; set; }
        public int ProyectoId { get; set; }

        public Proyecto? Proyecto { get; set; }
        public Desarrollador? Desarrollador { get; set; }
    }
}