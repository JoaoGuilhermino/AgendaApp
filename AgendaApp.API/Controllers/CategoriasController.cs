using AgendaApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            // Instancia o repositorio de categorias
            var categoriaRepository = new CategoriaRepository();

            // Consulta todas as categorias
            var categorias = categoriaRepository.ObterTodos();

            return Ok(categorias);
        }
    }
}
