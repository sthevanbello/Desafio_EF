﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio_EF.Models
{
    /// <summary>
    /// Model Paciente
    /// </summary>
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o número da carteirinha")]
        [MinLength(6, ErrorMessage = "O número deverá ter no mínimo 6 caracteres")]
        public string Carteirinha { get; set; }
        [Required(ErrorMessage ="Informe a data de nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage ="Informe se o usuário está ativo (true) ou inativo (false)")]
        public bool Ativo { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Consulta> Consultas { get; set; }
    }
}
