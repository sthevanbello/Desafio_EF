using Desafio_EF.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio_EF.Models
{
    public class TipoUsuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ETipoUsuario Tipo { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
