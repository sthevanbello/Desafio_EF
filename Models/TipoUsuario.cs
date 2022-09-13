using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio_EF.Models
{
    /// <summary>
    /// Model TipoUsuario
    /// </summary>
    public class TipoUsuario
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
