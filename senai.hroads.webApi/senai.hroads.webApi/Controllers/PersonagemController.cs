using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private IPersonagemRepository Per { get; set; }

        public PersonagemController()
        {
            Per = new PersonagemRepository();
        }
        
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IActionResult Listar()
        {
            return Ok(Per.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult ListarTudo(int id)
        {
            return Ok(Per.BuscarId(id));
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Per.Deletar(id);
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Personagem NovoPer)
        {
            Per.Atualizar(id, NovoPer);
            return StatusCode(204);
        }
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem NovoPer)
        {
            Per.Cadastrar(NovoPer);
            return StatusCode(201);
        }
    }
}
