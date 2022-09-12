using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_EF.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        private readonly DesafioContext _context;
        public PacienteRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }

        public ICollection<Paciente> PacienteComConsultas()
        {
            var paciente = _context.Paciente
                            .Include(p => p.Usuario)
                            .Include(p => p.Consultas)
                                .ThenInclude(c => c.Medico)
                                .ThenInclude(e => e.Especialidade)
                            .Include(p => p.Consultas)
                                .ThenInclude(c => c.Medico)
                                .ThenInclude(m => m.Usuario)
                            .ToList();

            return paciente;

        }
    }
}
