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
    public class TipoDeHabilidadeController : ControllerBase
    {
        private ITipoDeHabilidadeRepository TipoHab { get; set; }

        public TipoDeHabilidadeController()
        {
            TipoHab = new TipoDeHabilidadeRepository();
        }
       
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TipoHab.Listar());
        }
        [HttpGet("TipoHabilidade")]
        public IActionResult ListarTudo()
        {
            return Ok(TipoHab.ListarTudo());
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(TipoHab.BuscarId(id));
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoDeHabilidade NovoTipo)
        {
            TipoHab.Cadastrar(NovoTipo);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            TipoHab.Deletar(id);
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoDeHabilidade NovoTipo)
        {
            TipoHab.Atualizar(id, NovoTipo);
            return StatusCode(204);
        }
    }
}
