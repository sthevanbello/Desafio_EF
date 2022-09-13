﻿using Desafio_EF.Models;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    /// <summary>
    /// Interface de PacienteRepository implementando a interface base com os métodos básicos.
    /// <para>Há ainda um método Get personalizado</para>
    /// </summary>
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        public ICollection<Paciente> GetAllPacientes();
        public Medico GetByIdPaciente(int id);
        public ICollection<Paciente> GetPacientesComSonsultas();
    }
}
