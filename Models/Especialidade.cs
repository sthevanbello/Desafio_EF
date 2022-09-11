﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio_EF.Models
{
    public class Especialidade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Categoria { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Medico> Medicos { get; set; }
    }
}
