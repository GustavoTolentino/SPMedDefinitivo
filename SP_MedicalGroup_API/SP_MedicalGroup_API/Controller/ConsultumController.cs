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
    public class ConsultumController : ControllerBase
    {
        private IConsultum _ConsultumRepository { get; set; }

        public ConsultumController()
        {
            _ConsultumRepository = new ConsultumRepository();
        }
        /// <summary>
        /// Metodo que lista todas as Consultas Marcadas no Sistema
        /// </summary>
        /// <returns>Retorna uma lista contendo Todas as Consultas</returns>
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_ConsultumRepository.read());
        }
        /// <summary>
        /// Metodo que Lista as informacoes de uma Consulta, Baseado no ID passado como parametro para a Busca
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna as Informacoes de uma Consulta Especifica</returns>
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_ConsultumRepository.readId(id));
        }
        /// <summary>
        /// Metodo que Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaconsultum"></param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult post(Consultum novaconsultum)
        {
            _ConsultumRepository.create(novaconsultum);
            return StatusCode(201);
        }
        /// <summary>
        /// Metodo que Deleta os registros de uma Consulta
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status Code 202</returns>
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _ConsultumRepository.delete(id);
            return StatusCode(id);
        }
        /// <summary>
        /// Metodo que Atualiza as informacoes de uma Consulta
        /// <param name="id"></param>
        /// <param name="consultumAtualizada"></param>
        /// <returns>Status Code 204</returns>
        [HttpPut("{id}")]
        public IActionResult put(int id, Consultum consultumAtualizada)
        {
            _ConsultumRepository.update(id, consultumAtualizada);
            return StatusCode(204);
        }
    }
}
