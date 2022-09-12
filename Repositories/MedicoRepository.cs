using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_EF.Repositories
{
    public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
    {
        private readonly DesafioContext _context;

        public MedicoRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }

        public ICollection<Medico> MedicosComConsultas()
        {
            var medicos = _context.Medico
                .Include(e => e.Especialidade)
                .Include(p => p.Usuario)
                .Include(p => p.Consultas)
                    .ThenInclude(c => c.Paciente)
                .Include(p => p.Consultas)
                    .ThenInclude(c => c.Paciente)
                    .ThenInclude(m => m.Usuario)
                .ToList();

            return medicos;
        }
    }
}
