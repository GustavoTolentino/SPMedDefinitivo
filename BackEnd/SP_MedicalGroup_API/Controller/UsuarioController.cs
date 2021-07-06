using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_MedicalGroup_API.Domains;
using SP_MedicalGroup_API.Interfaces;
using SP_MedicalGroup_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuario { get; set; }
        public UsuarioController()
        {
            _usuario = new UsuarioRepository();
        }
        /// <summary>
        /// Metodo que lista todos os Usuarios presentes no Sistema
        /// </summary>
        /// <returns>Uma lista de todos os usuarios encontrados</returns>
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_usuario.read());
        }
        /// <summary>
        /// Metodo que lista todas as informacoes de um usuario especifico, baseado no ID passado como parametro para a Busca
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna todas as informacoes de um usuario especifico</returns>
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_usuario.readId(id));
        }
        /// <summary>
        /// Metodo que cadastra um novo usuario no Sistema
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult post(Usuario novoUsuario)
        {
            _usuario.create(novoUsuario);
            return StatusCode(201);
        }
        /// <summary>
        /// Metodo que deleta um usuario da plataforma
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status Code 202</returns>
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _usuario.delete(id);
            return StatusCode(202);
        }
        /// <summary>
        /// Metodo que atualiza as informacoes de um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAtualizado"></param>
        /// <returns>Status Code204</returns>
        [HttpPut("{id}")]
        public IActionResult put(int id, Usuario usuarioAtualizado)
        {
            _usuario.update(id, usuarioAtualizado);
            return StatusCode(204);
        }
    }
}
