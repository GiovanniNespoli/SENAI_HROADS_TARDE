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
    public class TipoUsuarioRepository : ITipoDeUsuarioRepository
    {
        Context_HRoads ctx = new Context_HRoads();
        public void Atualizar(int id, TipoUsuario NovoTipo)
        {
            TipoUsuario TipoBuscado = ctx.TipoUsuarios.Find(id);

            if (NovoTipo.TipoUsuario1 != null)
            {
                TipoBuscado.TipoUsuario1 = NovoTipo.TipoUsuario1;
            }

            ctx.TipoUsuarios.Update(TipoBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario NovoTipo)
        {
            ctx.TipoUsuarios.Add(NovoTipo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario TipoBuscado = ctx.TipoUsuarios.Find(id);
            ctx.Remove(TipoBuscado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public List<TipoUsuario> ListarTudo()
        {
            return ctx.TipoUsuarios.Include(e => e.Usuarios).ToList();
        }
    }
}
