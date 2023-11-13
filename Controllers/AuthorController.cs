using Microsoft.AspNetCore.Mvc;
using ApiExamen.Operaciones;
using ApiExamen.Models;
using ApiExamen.Context;
using ApiExamen.Controllers;


namespace ApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AutoresDAO _autoresDAO;

        public AuthorController(AutoresDAO autoresDAO)
        {
            _autoresDAO = autoresDAO;
        }

        [HttpGet]
        public IActionResult GetAutores()
        {
            var autores = _autoresDAO.SeleccionarTodos();
            return Ok(autores);
        }

        [HttpGet("{id}")]
        public IActionResult GetAutor(int id)
        {
            var autor = _autoresDAO.Seleccionar(id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpPost]
        public IActionResult PostAutor([FromBody] Author autor)
        {
            var resultado = _autoresDAO.Agregar(autor.Id, autor.Name);

            if (resultado)
            {
                return CreatedAtAction(nameof(GetAutor), new { id = autor.Id }, autor);
            }

            return BadRequest();
        }
    }
}
