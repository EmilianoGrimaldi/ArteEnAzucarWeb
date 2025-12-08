using ArteEnAzucarWeb.Models;
using Microsoft.AspNetCore.Mvc;
namespace ArteEnAzucarWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        // Simulamos una base de datos con una lista estática para este ejemplo
        private static List<Curso> _cursos = new List<Curso>
        {
            new Curso { Id = 1, Titulo = "Pasteleria", Descripcion = "Lorem", Precio = 1200 },
            new Curso { Id = 2, Titulo = "Bombones", Descripcion = "Lorem", Precio = 2500 }
        };



        // ---------------------------------------------------------
        // 1. GET: Leer datos (READ)
        // ---------------------------------------------------------

        // GET: api/cursos
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(_cursos); // Retorna estatus 200 y la lista JSON
        }

        // GET: api/cursos/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var curso = _cursos.FirstOrDefault(c => c.Id == id);

            if (curso == null)
            {
                return NotFound(); // Retorna 404 si no existe
            }

            return Ok(curso);
        }

        // ---------------------------------------------------------
        // 2. POST: Crear datos (CREATE)
        // ---------------------------------------------------------

        // POST: api/cursos
        [HttpPost]
        public IActionResult Crear([FromBody] Curso nuevocurso)
        {
            // [FromBody] significa: "Toma los datos del JSON que enviaste"

            // Lógica simple para asignar ID
            nuevocurso.Id = _cursos.Max(p => p.Id) + 1;
            _cursos.Add(nuevocurso);

            // Es buena práctica retornar 201 Created y la URL del nuevo recurso
            return CreatedAtAction(nameof(GetById), new { id = nuevocurso.Id }, nuevocurso);
        }

        // ---------------------------------------------------------
        // 3. PUT: Actualizar datos (UPDATE)
        // ---------------------------------------------------------

        // PUT: api/cursos/5
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] Curso cursoEditado)
        {
            // Validamos que el ID de la URL coincida con el del objeto (seguridad básica)
            if (id != cursoEditado.Id)
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            var cursoExistente = _cursos.FirstOrDefault(p => p.Id == id);
            if (cursoExistente == null)
            {
                return NotFound();
            }

            // Actualizamos los campos
            cursoExistente.Titulo = cursoEditado.Titulo;
            cursoExistente.Precio = cursoEditado.Precio;

            return NoContent(); // Retorna 204: "Todo bien, pero no tengo nada que mostrarte"
        }

        // ---------------------------------------------------------
        // 4. DELETE: Borrar datos (DELETE)
        // ---------------------------------------------------------

        // DELETE: api/cursos/5
        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            var curso = _cursos.FirstOrDefault(p => p.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            _cursos.Remove(curso);

            return NoContent(); // Retorna 204
        }
    }
}
