using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
       private IUsuarioRepository User { get; set; }

        public LoginController()
        {
            User = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            Usuario LoginBuscado = User.Login(login.Email, login.Senha);

            if (LoginBuscado == null)
            {
                return NotFound("Email ou User não encontrados");
            }

            var Clamis = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, LoginBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, LoginBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, LoginBuscado.IdTipoUsuario.ToString())
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("user-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken
            (
                issuer: "HRoads.webApi",
                audience: "HRoads.webApi",
                claims: Clamis,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            return Ok(
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(Token)
                }); 

        }
      
    }
}
