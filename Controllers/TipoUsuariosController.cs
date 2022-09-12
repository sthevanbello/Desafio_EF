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
    public class TipoUsuariosController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuariosController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        /// <summary>
        /// Inserir um TipoUsuario no banco.
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertTipoUsuario(TipoUsuario tipoUsuario)
        {
            try
            {
                var tipoUsuarioInserido = _tipoUsuarioRepository.Inserir(tipoUsuario);
                return Ok(tipoUsuarioInserido);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir um Tipo de usuário no banco",
                    ex.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de Tipos de usuários cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllTipoUsuario()
        {
            try
            {
                var tipoUsuarios = _tipoUsuarioRepository.ListarTodos();
                return Ok(tipoUsuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os tipos de usuários",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um tipo de usuário a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id do tipo de usuário</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdTipoUsuario(int id)
        {
            try
            {
                var tipoUsuario = _tipoUsuarioRepository.BuscarPorId(id);
                if (tipoUsuario is null)
                {
                    return NotFound(new { msg = "Tipo de usuário não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(tipoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = "Falha ao exibir o tipo de usuário",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do tipo de usuário
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="patchTipoUsuario">informações a serem alteradas</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchTipoUsuario(int id, [FromBody] JsonPatchDocument patchTipoUsuario)
        {
            try
            {
                if (patchTipoUsuario is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var usuario = _tipoUsuarioRepository.BuscarPorId(id);
                if (usuario is null)
                {
                    return NotFound(new { msg = "Usuário não encontrado. Conferir o Id informado" });
                }

                _tipoUsuarioRepository.AlterarParcialmente(patchTipoUsuario, usuario);

                return Ok(new { msg = "Tipo de usuário alterado", usuario });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o tipo de usuário",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Alterar um tipo de usuário a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id do tipo de usuário</param>
        /// <param name="tipoUsuario">Dados atualizados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutTipoUsuario(int id, TipoUsuario tipoUsuario)
        {
            try
            {
                if (id != tipoUsuario.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var tipoUsuarioRetorno = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioRetorno is null)
                {
                    return NotFound(new { msg = "Tipo de usuário não encontrado. Conferir o Id informado" });
                }

                _tipoUsuarioRepository.Alterar(tipoUsuario);

                return Ok(new { msg = "Tipo de usuário alterado", tipoUsuario });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o tipo de usuário",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Excluir um tipo de usuário do banco de dados
        /// </summary>
        /// <param name="id">Id do tipo de usuário a ser excluído</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteTipoUsuario(int id)
        {
            try
            {
                var tipoUsuarioRetorno = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioRetorno is null)
                {
                    return NotFound(new { msg = "Tipo de usuário não encontrado. Conferir o Id informado" });
                }

                _tipoUsuarioRepository.Excluir(tipoUsuarioRetorno);

                return Ok(new { msg = "Tipo de usuário excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o tipo de usuário",
                    ex.InnerException.Message
                });
            }
        }
    }
}
