using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_EF.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly DesafioContext _context;
        public UsuarioRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }

        public ICollection<Usuario> GetUsuariosMedicos()
        {
            var medicos = _context.Usuario
                            .Include(m => m.Medicos)
                            .ThenInclude(e => e.Especialidade)
                            .Where(m => m.IdTipoUsuario == 2)
                            .ToList();


            return medicos;
        }

        public ICollection<Usuario> GetUsuariosPacientes()
        {
            var pacientes = _context.Usuario
                            .Include(m => m.TipoUsuario)
                            .Include(p => p.Pacientes)
                            .Where(p => p.IdTipoUsuario == 1)
                            .ToList();


            return pacientes;
        }
    }
}
