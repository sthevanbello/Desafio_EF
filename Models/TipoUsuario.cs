using System.ComponentModel.DataAnnotations;

namespace Desafio_EF.Models
{
    public class TipoUsuario
    {
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}
