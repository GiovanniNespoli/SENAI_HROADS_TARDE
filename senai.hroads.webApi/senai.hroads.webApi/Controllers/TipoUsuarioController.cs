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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoDeUsuarioRepository TipoUsuario { get; set; }

        public TipoUsuarioController()
        {
            TipoUsuario = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TipoUsuario.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(TipoUsuario.BuscarId(id));
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario NovoTipo)
        {
            TipoUsuario.Cadastrar(NovoTipo);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            TipoUsuario.Deletar(id);
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoUsuario NovoTipo)
        {
            TipoUsuario.Atualizar(id, NovoTipo);
            return StatusCode(204);
        }
        [HttpGet("User")]
        public IActionResult ListarTudo()
        {
            return Ok(TipoUsuario.ListarTudo());
        }
    }
}
