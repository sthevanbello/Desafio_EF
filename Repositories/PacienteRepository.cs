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

        public ICollection<Paciente> GetPacienteComConsultas()
        {
            var paciente = _context.Paciente
                            .Include(p => p.Usuario)
                                .ThenInclude(t => t.TipoUsuario)
                            .Include(p => p.Consultas)
                                .ThenInclude(c => c.Medico)
                                .ThenInclude(e => e.Especialidade)
                            .Include(p => p.Consultas)
                                .ThenInclude(c => c.Medico)
                                .ThenInclude(m => m.Usuario)
                                .ThenInclude(t => t.TipoUsuario)
                            .ToList();

            return paciente;

        }
    }
}
