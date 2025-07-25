using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using GEDSoftware.Models.Models;

namespace GEDSoftware.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesarrolladoresController:ControllerBase
    {
        private readonly IConfiguration _config;

        public DesarrolladoresController(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        // GET: api/Desarrolladores
        [HttpGet]
        public IEnumerable<Desarrollador> Get()
        {
            using var connection = GetConnection();
            var sql = @"SELECT id, nombre, correo, telefono 
                        FROM dbo.desarrolladores";
            return connection.Query<Desarrollador>(sql);
        }

        // GET: api/Desarrolladores/5
        [HttpGet("{id}")]
        public ActionResult<Desarrollador> Get(int id)
        {
            using var connection = GetConnection();
            var sql = @"SELECT id, nombre, correo, telefono 
                        FROM dbo.desarrolladores WHERE id = @Id";
            var desarrollador = connection.QuerySingleOrDefault<Desarrollador>(sql, new { Id = id });
            if(desarrollador == null)
                return NotFound();
            return desarrollador;
        }

        // POST: api/Desarrolladores
        [HttpPost]
        public IActionResult Post([FromBody] Desarrollador desarrollador)
        {
            using var connection = GetConnection();
            var sql = @"INSERT INTO dbo.desarrolladores (nombre, correo, telefono) 
                        VALUES (@Nombre, @Correo, @Telefono)";
            var affectedRows = connection.Execute(sql, desarrollador);
            if(affectedRows > 0)
                return Ok();
            return BadRequest();
        }

        // PUT: api/Desarrolladores/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Desarrollador desarrollador)
        {
            using var connection = GetConnection();
            var sql = @"UPDATE dbo.desarrolladores 
                        SET nombre = @Nombre, correo = @Correo, telefono = @Telefono
                        WHERE id = @Id";
            var affectedRows = connection.Execute(sql, new
            {
                desarrollador.Nombre,
                desarrollador.Correo,
                desarrollador.Telefono,
                Id = id
            });
            if(affectedRows > 0)
                return Ok();
            return NotFound();
        }

        // DELETE: api/Desarrolladores/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var connection = GetConnection();
            var sql = @"DELETE FROM dbo.desarrolladores WHERE id = @Id";
            var affectedRows = connection.Execute(sql, new { Id = id });
            if(affectedRows > 0)
                return Ok();
            return NotFound();
        }
    }
}