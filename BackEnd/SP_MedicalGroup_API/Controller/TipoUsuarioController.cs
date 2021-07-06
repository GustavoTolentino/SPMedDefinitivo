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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoDeUsuario _Tipo { get; set; }
        public TipoUsuarioController()
        {
            _Tipo = new TipoUsuarioRepository();
        }
        /// <summary>
        /// Metodo pra listar todos os Tipos de Usuarios
        /// </summary>
        /// <returns>Uma lista completa de todos os tipos de usuarios</returns>
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_Tipo.read());
        }
        /// <summary>
        /// Metodo pra listar apenas um tipo de usuario, baseado no seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma lista com as informacoes respectivas do Tipo De Usuario encontrado com o ID que foi passado como parametro de busca</returns>
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_Tipo.readId(id));
        }
        /// <summary>
        /// Metodo para cadastrar um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario"></param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult post(TipoDeUsuario novoTipoUsuario)
        {
            _Tipo.create(novoTipoUsuario);
            return StatusCode(201);
        }
        /// <summary>
        /// Metodo que deleta um tipo de usuario baseado no ID passado como parametro de busca
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status Code 202</returns>
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _Tipo.delete(id);
            return StatusCode(202);
        }
        /// <summary>
        /// Metodo que Atualiza as informações de um Tipo De Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoAtualizado"></param>
        /// <returns>Status Code 203</returns>
        [HttpPut("{id}")]
        public IActionResult put(int id, TipoDeUsuario tipoAtualizado)
        {
            _Tipo.update(id, tipoAtualizado);
            return StatusCode(203);
        }
    }
}
