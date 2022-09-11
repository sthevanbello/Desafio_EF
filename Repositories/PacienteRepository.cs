using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;

namespace Desafio_EF.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(DesafioContext desafioContext) : base(desafioContext)
        {
        }
    }
}
