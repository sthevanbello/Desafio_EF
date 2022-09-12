using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Desafio_EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacientesController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        /// <summary>
        /// Inserir um paciente no banco.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertPaciente(Paciente paciente)
        {
            try
            {
                var pacienteInserido = _pacienteRepository.Inserir(paciente);
                return Ok(pacienteInserido);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir um paciente no banco",
                    ex.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de usuários cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPacientes()
        {
            try
            {
                var pacientes = _pacienteRepository.ListarTodos();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os pacientes",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Exibir uma lista de usuários cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("Consultas")]
        public IActionResult GetAllPacientesComConsulta()
        {
            try
            {
                var pacientes = _pacienteRepository.PacienteComConsultas();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os pacientes",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Exibir um paciente a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdPaciente(int id)
        {
            try
            {
                var paciente = _pacienteRepository.BuscarPorId(id);
                if (paciente is null)
                {
                    return NotFound(new { msg = "Paciente não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(paciente);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir o paciente",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do paciente
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <param name="patchPaciente">informações a serem alteradas</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchPaciente(int id, [FromBody] JsonPatchDocument patchPaciente)
        {
            try
            {
                if (patchPaciente is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var paciente = _pacienteRepository.BuscarPorId(id);
                if (paciente is null)
                {
                    return NotFound(new { msg = "Paciente não encontrado. Conferir o Id informado" });
                }

                _pacienteRepository.AlterarParcialmente(patchPaciente, paciente);

                return Ok(new { msg = "Paciente alterado", paciente });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o usuário",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Alterar um paciente a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id da paciente</param>
        /// <param name="paciente">Dados atualizados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutPaciente(int id, Paciente paciente)
        {
            try
            {
                if (id != paciente.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var pacienteRetorno = _pacienteRepository.BuscarPorId(id);

                if (pacienteRetorno is null)
                {
                    return NotFound(new { msg = "Paciente não encontrado. Conferir o Id informado" });
                }

                _pacienteRepository.Alterar(paciente);

                return Ok(new { msg = "Paciente alterado", paciente });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o paciente",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Excluir paciente do banco de dados
        /// </summary>
        /// <param name="id">Id da paciente a ser excluído</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeletePaciente(int id)
        {
            try
            {
                var pacienteRetorno = _pacienteRepository.BuscarPorId(id);

                if (pacienteRetorno is null)
                {
                    return NotFound(new { msg = "Paciente não encontrado. Conferir o Id informado" });
                }

                _pacienteRepository.Excluir(pacienteRetorno);

                return Ok(new { msg = "Paciente excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o paciente",
                    ex.Message
                });
            }
        }
    }
}
