using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Context_HRoads ctx = new Context_HRoads();

        public void AtualizarEmail(int id, Usuario NovoUsaurio)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            if (NovoUsaurio.Email != null)
            {
                UsuarioBuscado.Email = NovoUsaurio.Email;
            }

            ctx.Usuarios.Update(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public void AtualizarSenha(int id, Usuario NovoUsuario)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            if (NovoUsuario.Senha != null)
            {
                UsuarioBuscado.Senha = NovoUsuario.Senha;
            }

            ctx.Usuarios.Update(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);
            ctx.Usuarios.Remove(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public List<Usuario> ListarTudo()
        {
            return ctx.Usuarios.Include(e => e.IdTipoUsuario).ToList();
        }

        public Usuario Login(string email, string senha)
        {
             return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
