using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_EF.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CRM { get; set; }
        
        [Required]
        [ForeignKey("Especialidade")]
        public int IdEspecialidade { get; set; }
        public Especialidade Especialidade { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}
