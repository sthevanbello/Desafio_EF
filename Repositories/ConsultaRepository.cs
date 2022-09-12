using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_EF.Repositories
{
    public class ConsultaRepository : BaseRepository<Consulta>, IConsultaRepository
    {
        private readonly DesafioContext _context;
        public ConsultaRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }

        public ICollection<Consulta> GetConsultasCompletas()
        {
            var consultasCompletas = _context.Consulta

                .Include(m => m.Medico)
                    .ThenInclude(u => u.Usuario)
                    .ThenInclude(t => t.TipoUsuario)
                .Include(m => m.Medico)
                    .ThenInclude(e => e.Especialidade)
                .Include(p => p.Paciente)
                    .ThenInclude(u => u.Usuario)
                    .ThenInclude(t => t.TipoUsuario)
                .ToList();
            return consultasCompletas;
        }

        public Consulta GetConsultaCompletaById(int id)
        {
            var consultaCompleta = _context.Consulta
                .Include(m => m.Medico)
                    .ThenInclude(u => u.Usuario)
                    .ThenInclude(t => t.TipoUsuario)
                .Include(m => m.Medico)
                    .ThenInclude(e => e.Especialidade)
                .Include(p => p.Paciente)
                    .ThenInclude(u => u.Usuario)
                    .ThenInclude(t => t.TipoUsuario)
                .FirstOrDefault(c => c.Id == id);

            return consultaCompleta;
        }
    }
}
