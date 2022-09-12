using Desafio_EF.Models;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        public ICollection<Usuario> GetUsuariosPacientes();
        public ICollection<Usuario> GetUsuariosMedicos();
    }
}
