using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_EF.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Carteirinha { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}
