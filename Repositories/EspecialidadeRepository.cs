using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;

namespace Desafio_EF.Repositories
{
    public class EspecialidadeRepository : BaseRepository<Especialidade>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(DesafioContext desafioContext) : base(desafioContext)
        {
        }
    }
}
