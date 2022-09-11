using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio_EF.Models
{
    /// <summary>
    /// Classe de relacionamento entre a classe Medico e a classe Paciente
    /// </summary>
    public class Consulta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [Required]
        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Medico Medico { get; set; }
        [Required]
        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Paciente Paciente { get; set; }
    }
}
