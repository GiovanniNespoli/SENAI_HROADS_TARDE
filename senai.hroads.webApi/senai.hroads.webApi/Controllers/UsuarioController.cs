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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository User { get; set; }

        public UsuarioController()
        {
            User = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(User.Listar());
        }
        [HttpGet("User")]
        public IActionResult ListarTudo()
        {
            return Ok(User.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult ListaId(int id)
        {
            return Ok(User.BuscarId(id));
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario NovoUsuario)
        {
            User.Cadastrar(NovoUsuario);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User.Deletar(id);
            return StatusCode(204);
        }
        [HttpPut("Email/{id}")]
        public IActionResult AtualizarEmail(int id, Usuario NovoUsuario)
        {
            User.AtualizarEmail(id, NovoUsuario);
            return StatusCode(204);
        }
        [HttpPut("Senha/{id}")]
        public IActionResult AtualizarSenha(int id, Usuario NovoUsuario)
        {
            User.AtualizarSenha(id, NovoUsuario);
            return StatusCode(204);
        }
    }
}
