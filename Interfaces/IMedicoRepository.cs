using Desafio_EF.Models;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    public interface IMedicoRepository : IBaseRepository<Medico>
    {
        public ICollection<Medico> GetMedicosComConsultas();
    }
}
