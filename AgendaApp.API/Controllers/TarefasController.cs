using AgendaApp.API.Dtos;
using AgendaApp.API.Entities;
using AgendaApp.API.Enums;
using AgendaApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] TarefaRequestDto request)
        {
            //criando uma instancia da classe repositorio de tarefas
            var categoriaRepository = new CategoriaRepository();

          
            //Verificar se a categoria não existe (condição de segurança)
            if (!categoriaRepository.CategoriaExiste(request.CategoriaId.Value))
                return NotFound(new { mensagem = "Categoria não encontrada. Verifique o ID informado." });

            //capturando dados da tarefa
            var tarefa = new Tarefa
            {
                Nome = request.Nome ?? string.Empty,
                DataHora = DateTime.Parse($"{request.Data} {request.Hora}"),
                Prioridade = (Prioridade)request.Prioridade.Value,
                CategoriaId = request.CategoriaId.Value

            };

            //Criando a isntancia da classe repositorio de tarefas
            var tarefaRepository = new TarefaRepository();

            //Salvar a atarefa no banco de dados
            tarefaRepository.Inserir(tarefa);

            //Retornando a resposta (HTTP 201 CREATED)
            return StatusCode(201, new {tarefa.Id, request});
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
