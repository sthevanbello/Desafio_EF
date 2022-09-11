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
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadesController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        /// <summary>
        /// Inserir uma especialidade no banco de dados.
        /// </summary>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertEspecialidade(Especialidade especialidade)
        {
            try
            {
                var especialidadeInserida = _especialidadeRepository.Inserir(especialidade);
                return Ok(especialidadeInserida);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir uma especialidade no banco",
                    ex.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de especialidades cadastradas no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllEspecialidade()
        {
            try
            {
                var especialidades = _especialidadeRepository.ListarTodos();
                return Ok(especialidades);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar as especialidades",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Exibir uma especialidade a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdEspecialidade(int id)
        {
            try
            {
                var especialidade = _especialidadeRepository.BuscarPorId(id);
                if (especialidade is null)
                {
                    return NotFound(new { msg = "Especialidade não foi encontrada. Verifique se o Id está correto" });
                }
                return Ok(especialidade);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir a especialidade",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações da especialidade
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <param name="patchEspecialidade">informações a serem alteradas</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchEspecialidade(int id, [FromBody] JsonPatchDocument patchEspecialidade)
        {
            try
            {
                if (patchEspecialidade is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var especialidade = _especialidadeRepository.BuscarPorId(id);
                if (especialidade is null)
                {
                    return NotFound(new { msg = "Especialidade não encontrada. Conferir o Id informado" });
                }

                _especialidadeRepository.AlterarParcialmente(patchEspecialidade, especialidade);

                return Ok(new { msg = "Especialidade alterado", especialidade });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar a especialidade",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Alterar um especialidade a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <param name="especialidade">Dados atualizados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutEspecialidade(int id, Especialidade especialidade)
        {
            try
            {
                if (id != especialidade.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var especialidadeRetorno = _especialidadeRepository.BuscarPorId(id);

                if (especialidadeRetorno is null)
                {
                    return NotFound(new { msg = "Especialidade não encontrado. Conferir o Id informado" });
                }

                _especialidadeRepository.Alterar(especialidade);

                return Ok(new { msg = "Especialidade alterado", especialidade });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o especialidade",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Excluir especialidade do banco de dados
        /// </summary>
        /// <param name="id">Id da especialidade a ser excluído</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteEspecialidade(int id)
        {
            try
            {
                var especialidadeRetorno = _especialidadeRepository.BuscarPorId(id);

                if (especialidadeRetorno is null)
                {
                    return NotFound(new { msg = "Especialidade não encontrado. Conferir o Id informado" });
                }

                _especialidadeRepository.Excluir(especialidadeRetorno);

                return Ok(new { msg = "Especialidade excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o especialidade",
                    ex.Message
                });
            }
        }
    }
}
