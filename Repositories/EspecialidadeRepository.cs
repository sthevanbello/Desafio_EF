using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_EF.Repositories
{
    public class EspecialidadeRepository : BaseRepository<Especialidade>, IEspecialidadeRepository
    {
        private readonly DesafioContext _context;
        public EspecialidadeRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;  
        }

        public ICollection<Especialidade> GetAllEspecialidadeComMedicos()
        {
            var especialidade = _context.Especialidade
                .Include(m => m.Medicos)
                    .ThenInclude(u => u.Usuario)
                .ToList();
            return especialidade;
        }
    }
}
