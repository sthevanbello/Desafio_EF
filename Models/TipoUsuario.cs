using Desafio_EF.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio_EF.Models
{
    public class TipoUsuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ETipoUsuario Tipo { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
