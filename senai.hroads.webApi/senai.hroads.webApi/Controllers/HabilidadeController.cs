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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository Hab { get; set; }

        public HabilidadeController()
        {
            Hab = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(Hab.Listar());
        }
        [HttpGet("Hab")]
        public IActionResult ListarTudo()
        {
            return Ok(Hab.ListarTudo());
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(Hab.BuscarId(id));
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade NovaHab)
        {
            Hab.Cadastrar(NovaHab);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Hab.Deletar(id);
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Habilidade NovaHab)
        {
            Hab.Atualizar(id, NovaHab);
            return StatusCode(204);
        }
    }
}
