using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using GEDSoftware.Models.Models;

namespace GEDSoftware.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController:ControllerBase
    {
        private readonly IConfiguration _config;

        public TareasController(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        // GET: api/Tareas
        [HttpGet]
        public IEnumerable<Tarea> Get()
        {
            using var connection = GetConnection();
            var sql = @"SELECT id, nombre, descripcion, fechacreacion, fechalimite, prioridad, estado, desarrollador_id, proyecto_id
                        FROM dbo.tareas";
            return connection.Query<Tarea>(sql);
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public ActionResult<Tarea> Get(int id)
        {
            using var connection = GetConnection();
            var sql = @"SELECT id, nombre, descripcion, fechacreacion, fechalimite, prioridad, estado, desarrollador_id, proyecto_id
                        FROM dbo.tareas WHERE id = @Id";
            var tarea = connection.QuerySingleOrDefault<Tarea>(sql, new { Id = id });
            if(tarea == null)
                return NotFound();
            return tarea;
        }

        // POST: api/Tareas
        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            using var connection = GetConnection();
            var sql = @"INSERT INTO dbo.tareas (nombre, descripcion, fechacreacion, fechalimite, prioridad, estado, desarrollador_id, proyecto_id) 
                        VALUES (@Nombre, @Descripcion, @FechaCreacion, @FechaLimite, @Prioridad, @Estado, @DesarrolladorId, @ProyectoId)";
            var affectedRows = connection.Execute(sql, tarea);
            if(affectedRows > 0)
                return Ok();
            return BadRequest();
        }

        // PUT: api/Tareas/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tarea tarea)
        {
            using var connection = GetConnection();
            var sql = @"UPDATE dbo.tareas 
                        SET nombre = @Nombre, descripcion = @Descripcion, desarrollador_id = @DesarrolladorId,
                            fechacreacion = @FechaCreacion, fechalimite = @FechaLimite, prioridad = @Prioridad, estado = @Estado, 
                            proyecto_id = @ProyectoId   
                        WHERE id = @Id";
            var affectedRows = connection.Execute(sql, new
            {
                tarea.nombre,
                tarea.descripcion,
                tarea.fechacreacion,
                tarea.fechalimite,
                tarea.prioridad,
                tarea.estado,
                tarea.desarrolladorId,
                tarea.proyectoId,
                Id = id
            });
            if(affectedRows > 0)
                return Ok();
            return NotFound();
        }

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var connection = GetConnection();
            var sql = @"DELETE FROM dbo.tareas WHERE id = @Id";
            var affectedRows = connection.Execute(sql, new { Id = id });
            if(affectedRows > 0)
                return Ok();
            return NotFound();
        }
    }
}