using Desafio_EF.Models;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        public ICollection<Paciente> PacienteComConsultas();
    }
}
