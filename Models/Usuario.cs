using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_EF.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        [ForeignKey("TipoUsuario")]
        public int IdTipoUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
