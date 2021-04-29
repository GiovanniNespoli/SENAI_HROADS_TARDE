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
    public class ClassController : ControllerBase
    {
        private IClassRepository Classe { get; set; }

        public ClassController()
        {
            Classe = new ClassRepository();
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(Classe.Listar());
        }
        [HttpGet("Listar")]
        public IActionResult ListarTudo()
        {
            return Ok(Classe.ListarTudo());
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(Classe.BuscarId(id));
        }
        [Authorize(Roles= "1")]
        [HttpPost]
        public IActionResult Cadastrar(Class NovaClass)
        {
            Classe.Cadastrar(NovaClass);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Classe.Deletar(id);
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Class NovaClass)
        {
            Classe.Atualizar(id, NovaClass);
            return StatusCode(204);
        }
    }
}
