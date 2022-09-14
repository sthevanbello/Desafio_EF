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
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicosController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        /// <summary>
        /// Inserir um Médico no banco com a sua especialidade e com os dados de usuário, caso não tenha sido inserido no banco anteriormente
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertMedico(Medico medico)
        {
            try
            {
                medico.Usuario.IdTipoUsuario = 2; // Garante que o tipo de usuário médico será sempre 2
                var medicoInserido = _medicoRepository.Insert(medico);
                return Ok(medicoInserido);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir um Médico no banco",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de Médico cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllMedicos()
        {
            try
            {
                var Medicos = _medicoRepository.GetAllMedicos();
                return Ok(Medicos);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os Médicos",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir uma lista de médicos e suas consultas cadastradas no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("Consultas")]
        public IActionResult GetAllMedicosComConsulta()
        {
            try
            {
                var pacientes = _medicoRepository.GetMedicosComConsultas();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os médicos",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um Médico a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id do Medico</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdMedico(int id)
        {
            try
            {
                var medico = _medicoRepository.GetByIdMedico(id);
                if (medico is null)
                {
                    return NotFound(new { msg = "Médico não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(medico);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir o Médico",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do Médico
        /// </summary>
        /// <param name="id">Id do Médico</param>
        /// <param name="patchMedico">informações a serem alteradas</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchPaciente(int id, [FromBody] JsonPatchDocument patchMedico)
        {
            try
            {
                if (patchMedico is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var medico = _medicoRepository.GetById(id);
                if (medico is null)
                {
                    return NotFound(new { msg = "Médico não encontrado. Conferir o Id informado" });
                }

                _medicoRepository.Patch(patchMedico, medico);

                return Ok(new { msg = "Médico alterado", medico });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o Médico",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Alterar um Médico a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id da Medico</param>
        /// <param name="medico">Dados atualizados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutMedico(int id, Medico medico)
        {
            try
            {
                if (id != medico.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var medicoRetorno = _medicoRepository.GetById(id);

                if (medicoRetorno is null)
                {
                    return NotFound(new { msg = "Médico não encontrado. Conferir o Id informado" });
                }

                _medicoRepository.Put(medico);

                return Ok(new { msg = "Médico alterado", medico });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o Médico",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Excluir Médico do banco de dados
        /// </summary>
        /// <param name="id">Id da Médico a ser excluído</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteMedico(int id)
        {
            try
            {
                var medicoRetorno = _medicoRepository.GetById(id);

                if (medicoRetorno is null)
                {
                    return NotFound(new { msg = "Médico não encontrado. Conferir o Id informado" });
                }

                _medicoRepository.Delete(medicoRetorno);

                return Ok(new { msg = "Médico excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o Médico",
                    ex.InnerException.Message
                });
            }
        }
    }
}
