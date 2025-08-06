using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Repositories
{
    /// <summary>
    /// Repositorio de dados para a entidade Tarefa.
    /// </summary>
    public class TarefaRepository
    {
        /// <summary>
        /// Metodo para inserir uma nova tarefa no banco de dados
        /// </summary>
        public void Inserir(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Add(tarefa);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Metodo para atualizar uma tarefa existente no banco de dados
        /// </summary>
        public void Atualizar(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Update(tarefa);
                context.SaveChanges();
            }
        }

        public void Excluir(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Remove(tarefa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Metodopara consultar tarefas dentro de um periodo de datas
        /// </summary>
        /// <returns></returns>
        public List<Tarefa> ObterPorDatas(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            using (var context = new DataContext())
            {
                return context
                    .Set<Tarefa>()
                    .Include(t => t.Categoria) // Inclui a categoria relacionada
                    .Where(t => t.DataHora >= dataHoraInicio
                    && t.DataHora <= dataHoraFim)
                    .OrderByDescending(t => t.DataHora)
                    .ToList();
            }
        }

        /// <summary>
        /// Metodo para consultar tarefas por Id
        /// </summary>
        public Tarefa? ObterPorId(Guid id)
        {
            using(var context = new DataContext())
            {
                return context
                    .Set<Tarefa>()
                    .Include(t => t.Categoria) // Inclui a categoria relacionada
                    .SingleOrDefault(t => t.Id == id);
            }
        }
    }
}
