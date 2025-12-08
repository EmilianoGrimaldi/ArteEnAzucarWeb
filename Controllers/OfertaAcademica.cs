using ArteEnAzucarWeb.Models;
using Microsoft.AspNetCore.Mvc;
namespace ArteEnAzucarWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        // Simulamos una base de datos con una lista estática para este ejemplo
        private static List<OfertaAcademica> _OfertaAcademicas = new List<OfertaAcademica>
        {
            new OfertaAcademica { Id = 1, Titulo = "Pasteleria", Descripcion = "Lorem", Precio = 1200 },
            new OfertaAcademica { Id = 2, Titulo = "Bombones", Descripcion = "Lorem", Precio = 2500 }
        };



        // ---------------------------------------------------------
        // 1. GET: Leer datos (READ)
        // ---------------------------------------------------------

        // GET: api/OfertaAcademicas
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(_OfertaAcademicas); // Retorna estatus 200 y la lista JSON
        }

        // GET: api/OfertaAcademicas/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var OfertaAcademica = _OfertaAcademicas.FirstOrDefault(c => c.Id == id);

            if (OfertaAcademica == null)
            {
                return NotFound(); // Retorna 404 si no existe
            }

            return Ok(OfertaAcademica);
        }

        // ---------------------------------------------------------
        // 2. POST: Crear datos (CREATE)
        // ---------------------------------------------------------

        // POST: api/OfertaAcademicas
        [HttpPost]
        public IActionResult Crear([FromBody] OfertaAcademica nuevoOfertaAcademica)
        {
            // [FromBody] significa: "Toma los datos del JSON que enviaste"

            // Lógica simple para asignar ID
            nuevoOfertaAcademica.Id = _OfertaAcademicas.Max(p => p.Id) + 1;
            _OfertaAcademicas.Add(nuevoOfertaAcademica);

            // Es buena práctica retornar 201 Created y la URL del nuevo reOfertaAcademica
            return CreatedAtAction(nameof(GetById), new { id = nuevoOfertaAcademica.Id }, nuevoOfertaAcademica);
        }

        // ---------------------------------------------------------
        // 3. PUT: Actualizar datos (UPDATE)
        // ---------------------------------------------------------

        // PUT: api/OfertaAcademicas/5
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] OfertaAcademica OfertaAcademicaEditado)
        {
            // Validamos que el ID de la URL coincida con el del objeto (seguridad básica)
            if (id != OfertaAcademicaEditado.Id)
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            var OfertaAcademicaExistente = _OfertaAcademicas.FirstOrDefault(p => p.Id == id);
            if (OfertaAcademicaExistente == null)
            {
                return NotFound();
            }

            // Actualizamos los campos
            OfertaAcademicaExistente.Titulo = OfertaAcademicaEditado.Titulo;
            OfertaAcademicaExistente.Precio = OfertaAcademicaEditado.Precio;

            return NoContent(); // Retorna 204: "Todo bien, pero no tengo nada que mostrarte"
        }

        // ---------------------------------------------------------
        // 4. DELETE: Borrar datos (DELETE)
        // ---------------------------------------------------------

        // DELETE: api/OfertaAcademicas/5
        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            var OfertaAcademica = _OfertaAcademicas.FirstOrDefault(p => p.Id == id);
            if (OfertaAcademica == null)
            {
                return NotFound();
            }

            _OfertaAcademicas.Remove(OfertaAcademica);

            return NoContent(); // Retorna 204
        }
    }
}
