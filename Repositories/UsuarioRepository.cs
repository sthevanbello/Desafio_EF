using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;

namespace Desafio_EF.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DesafioContext desafioContext) : base(desafioContext)
        {
        }
    }
}
