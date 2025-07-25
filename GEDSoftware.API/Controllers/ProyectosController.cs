using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using GEDSoftware.Models.Models;

namespace GEDSoftware.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController:ControllerBase
    {
        private readonly IConfiguration _config;

        public ProyectosController(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        // GET: api/Proyectos
        [HttpGet]
        public IEnumerable<Proyecto> Get()
        {
            using var connection = GetConnection();
            var sql = @"SELECT Id, Nombre, Descripcion, FechaCreacion, FechaLimite, Prioridad, Estado, DesarrolladorId
                        FROM dbo.proyectos";
            return connection.Query<Proyecto>(sql);
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public ActionResult<Proyecto> Get(int id)
        {
            using var connection = GetConnection();
            var sql = @"SELECT Id, Nombre, Descripcion, FechaCreacion, FechaLimite, Prioridad, Estado, DesarrolladorId
                        FROM dbo.proyectos WHERE Id = @Id";
            var proyecto = connection.QuerySingleOrDefault<Proyecto>(sql, new { Id = id });
            if(proyecto == null)
                return NotFound();
            return proyecto;
        }

        // POST: api/Proyectos
        [HttpPost]
        public IActionResult Post([FromBody] Proyecto proyecto)
        {
            using var connection = GetConnection();
            var sql = @"INSERT INTO dbo.proyectos (Nombre, Descripcion, FechaCreacion, FechaLimite, Prioridad, Estado, DesarrolladorId) 
                        VALUES (@Nombre, @Descripcion, @FechaCreacion, @FechaLimite, @Prioridad, @Estado, @DesarrolladorId)";
            var affectedRows = connection.Execute(sql, proyecto);
            if(affectedRows > 0)
                return Ok();
            return BadRequest();
        }

        // PUT: api/Proyectos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Proyecto proyecto)
        {
            using var connection = GetConnection();
            var sql = @"UPDATE dbo.proyectos 
                        SET Nombre = @Nombre, Descripcion = @Descripcion, 
                            FechaCreacion = @FechaCreacion, FechaLimite = @FechaLimite, Prioridad = @Prioridad, Estado = @Estado, 
                            DesarrolladorId = @DesarrolladorId 
                        WHERE Id = @Id";
            var affectedRows = connection.Execute(sql, new
            {
                proyecto.Nombre,
                proyecto.Descripcion,
                proyecto.FechaCreacion,
                proyecto.FechaLimite,
                proyecto.Prioridad,
                proyecto.Estado,
                proyecto.DesarrolladorId,
                Id = id
            });
            if(affectedRows > 0)
                return Ok();
            return NotFound();
        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var connection = GetConnection();
            var sql = @"DELETE FROM dbo.proyectos WHERE Id = @Id";
            var affectedRows = connection.Execute(sql, new { Id = id });
            if(affectedRows > 0)
                return Ok();
            return NotFound();
        }
    }
}