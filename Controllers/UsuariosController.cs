using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Inserir um usuário no banco. Tipo 1 - Paciente, Tipo 2 - Médico
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertUsuario(Usuario usuario)
        {
            try
            {
                var usuarioInserido = _usuarioRepository.Insert(usuario);
                return Ok(usuarioInserido);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir um usuário no banco",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de usuários cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllUsuarios()
        {
            try
            {
                var usuarios = _usuarioRepository.GetAll();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os usuários",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de usuários que são médicos cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("Medicos")]
        public IActionResult GetAllUsuariosMedicos()
        {
            try
            {
                var usuarios = _usuarioRepository.GetUsuariosMedicos();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os usuários médicos",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de usuários que são médicos cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("Pacientes")]
        public IActionResult GetAllUsuariosPacientes()
        {
            try
            {
                var usuarios = _usuarioRepository.GetUsuariosPacientes();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os usuários médicos",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um usuário a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdUsuario(int id)
        {
            try
            {
                var usuario = _usuarioRepository.GetById(id);
                if (usuario is null)
                {
                    return NotFound(new { msg = "Usuário não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir o usuário",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do usuário
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="patchUsuario">informações a serem alteradas</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchUsuario(int id, [FromBody] JsonPatchDocument patchUsuario)
        {
            try
            {
                if (patchUsuario is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var usuario = _usuarioRepository.GetById(id);
                if (usuario is null)
                {
                    return NotFound(new { msg = "Usuário não encontrado. Conferir o Id informado" });
                }

                _usuarioRepository.Patch(patchUsuario, usuario);

                return Ok(new { msg = "Usuário alterado", usuario });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o usuário",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Alterar um usuário a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="usuario">Dados atualizados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var usuarioRetorno = _usuarioRepository.GetById(id);

                if (usuarioRetorno is null)
                {
                    return NotFound(new { msg = "Usuário não encontrado. Conferir o Id informado" });
                }

                _usuarioRepository.Put(usuario);

                return Ok(new { msg = "Usuário alterado", usuario });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o usuário",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Excluir usuário do banco de dados
        /// </summary>
        /// <param name="id">Id do usuário a ser excluído</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                var usuarioRetorno = _usuarioRepository.GetById(id);

                if (usuarioRetorno is null)
                {
                    return NotFound(new { msg = "Usuário não encontrado. Conferir o Id informado" });
                }

                _usuarioRepository.Delete(usuarioRetorno);

                return Ok(new { msg = "Usuário excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o usuário. Verifique se há utilização como Foreign Key de algum médico ou paciente",
                    ex.InnerException.Message
                });
            }
        }
    }
}
