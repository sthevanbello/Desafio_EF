using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;

namespace Desafio_EF.Repositories
{
    public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
    {
        public MedicoRepository(DesafioContext desafioContext) : base(desafioContext)
        {
        }
    }
}
