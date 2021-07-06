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
    public class ClinicaController : ControllerBase
    {
        private IClinica _clinica { get; set; }
        public ClinicaController()
        {
            _clinica = new ClinicaRepository();
        }
        /// <summary>
        /// Metodo que lista todas as Clinicas cadastradas no Sistema
        /// </summary>
        /// <returns>Retorna uma lista contendo Todas as Clinicas</returns>
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_clinica.read());
        }
        /// <summary>
        /// Metodo que Lista as informacoes de uma Clinica Baseado no ID passado como parametro para a Busca
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna as Informacoes de uma Clinica Especifica</returns>
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_clinica.readId(id));
        }
        /// <summary>
        /// Metodo que Cadastra uma nova Clinica
        /// </summary>
        /// <param name="novaClinica"></param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult post(Clinica novaClinica)
        {
            _clinica.create(novaClinica);
            return StatusCode(201);
        }
        /// <summary>
        /// Metodo que Deleta o Cadastro de uma Clinica
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status Code 202</returns>
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _clinica.delete(id);
            return StatusCode(202);
        }
        /// <summary>
        /// Metodo que Atualiza as informacoes de uma Clinica
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinicaAtualizada"></param>
        /// <returns>Status Code 203</returns>
        [HttpPut("{id}")]
        public IActionResult put(int id, Clinica clinicaAtualizada)
        {
            _clinica.update(id, clinicaAtualizada);
            return StatusCode(203);
        }
    }
}
