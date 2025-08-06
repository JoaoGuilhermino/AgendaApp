using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;

namespace AgendaApp.API.Repositories
{
    /// <summary>
    /// Repositorio de dados para a entidade Categoria.
    /// </summary>
    public class CategoriaRepository
    {
        /// <summary>
        /// Metodo para consultar todas as categorias no banco de dados
        /// </summary>
        public List<Categoria> ObterTodos()
        {
            using(var context = new DataContext())
            {
                return context.Set<Categoria>()
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        /// <summary>
        /// Metodo para verificar se existe uma categoria cadastrada no banco de dados com ID informado
        /// </summary>
        public bool CategoriaExiste(Guid id)
        {
            using(var context = new DataContext())
            {
                return context.Set<Categoria>()
                    .Any(c => c.Id == id); // verifica se existe pelo menos um registro com o ID informado
            }
        }
    }
}
