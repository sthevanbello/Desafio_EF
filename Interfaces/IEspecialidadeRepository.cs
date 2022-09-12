using Desafio_EF.Models;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    public interface IEspecialidadeRepository : IBaseRepository<Especialidade>
    {
        public ICollection<Especialidade> GetAllEspecialidadeComMedicos();
    }
}
