﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio_EF.Models
{
    /// <summary>
    /// Model Medico
    /// </summary>
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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Consulta> Consultas { get; set; }
    }
}
