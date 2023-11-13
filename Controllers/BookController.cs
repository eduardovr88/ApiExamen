// LibrosController.cs
using Microsoft.AspNetCore.Mvc;
using Examen.Operaciones;
using ApiExamen.Models;

namespace ApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly LibrosDAO _librosDAO;

        public LibrosController(LibrosDAO librosDAO)
        {
            _librosDAO = librosDAO;
        }

        [HttpGet]
        public IActionResult GetLibros()
        {
            var libros = _librosDAO.SeleccionarTodos();
            return Ok(libros);
        }

        [HttpGet("{id}")]
        public IActionResult GetLibro(int id)
        {
            var libro = _librosDAO.Seleccionar(id);
            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPost]
        public IActionResult PostLibro([FromBody] Book libro)
        {
            var resultado = _librosDAO.Agregar(libro.Id, libro.Title, libro.Chapters, libro.Pages, libro.Price, libro.AuthorId);

            if (resultado)
            {
                return CreatedAtAction(nameof(GetLibro), new { id = libro.Id }, libro);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult PutLibro(int id, [FromBody] Book libro)
        {
            var resultado = _librosDAO.Actualizar(id, libro.Title, libro.Chapters, libro.Pages, libro.Price, libro.AuthorId);

            if (resultado)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLibro(int id)
        {
            var resultado = _librosDAO.Eliminar(id);

            if (resultado)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
