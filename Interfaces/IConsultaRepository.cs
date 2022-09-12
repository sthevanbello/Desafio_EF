using Desafio_EF.Models;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    public interface IConsultaRepository : IBaseRepository<Consulta>
    {
        public ICollection<Consulta> GetConsultasCompletas();
        public Consulta GetConsultaCompletaById(int id);
    }
}
