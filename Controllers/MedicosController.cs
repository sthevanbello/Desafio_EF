﻿using Desafio_EF.Interfaces;
using Desafio_EF.Models;
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
                var medicoInserido = _medicoRepository.Inserir(medico);
                return Ok(medicoInserido);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir um Médico no banco",
                    ex.Message
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
                var Medicos = _medicoRepository.ListarTodos();
                return Ok(Medicos);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os Médicos",
                    ex.Message
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
                var medico = _medicoRepository.BuscarPorId(id);
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
                    ex.Message
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

                var medico = _medicoRepository.BuscarPorId(id);
                if (medico is null)
                {
                    return NotFound(new { msg = "Médico não encontrado. Conferir o Id informado" });
                }

                _medicoRepository.AlterarParcialmente(patchMedico, medico);

                return Ok(new { msg = "Médico alterado", medico });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o Médico",
                    ex.Message
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
                var medicoRetorno = _medicoRepository.BuscarPorId(id);

                if (medicoRetorno is null)
                {
                    return NotFound(new { msg = "Médico não encontrado. Conferir o Id informado" });
                }

                _medicoRepository.Alterar(medico);

                return Ok(new { msg = "Médico alterado", medico });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o Médico",
                    ex.Message
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
                var medicoRetorno = _medicoRepository.BuscarPorId(id);

                if (medicoRetorno is null)
                {
                    return NotFound(new { msg = "Médico não encontrado. Conferir o Id informado" });
                }

                _medicoRepository.Excluir(medicoRetorno);

                return Ok(new { msg = "Médico excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o Médico",
                    ex.Message
                });
            }
        }
    }
}