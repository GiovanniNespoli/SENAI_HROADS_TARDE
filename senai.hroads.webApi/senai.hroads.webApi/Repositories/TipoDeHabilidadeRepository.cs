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
    public class TipoDeHabilidadeRepository : ITipoDeHabilidadeRepository
    {
        Context_HRoads ctx = new Context_HRoads();

        public void Atualizar(int id, TipoDeHabilidade NovoTipo)
        {
            TipoDeHabilidade TipoBuscado = ctx.TipoDeHabilidades.Find(id);

            if (NovoTipo.NomeTipo != null)
            {
                TipoBuscado.NomeTipo = NovoTipo.NomeTipo;
            }

            ctx.TipoDeHabilidades.Update(TipoBuscado);
            ctx.SaveChanges();
        }

        public TipoDeHabilidade BuscarId(int id)
        {
            return ctx.TipoDeHabilidades.FirstOrDefault(e => e.IdTipoDeHabilidade == id);
        }

        public void Cadastrar(TipoDeHabilidade NovoTipo)
        {
            ctx.TipoDeHabilidades.Add(NovoTipo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoDeHabilidade TipoBuscado = ctx.TipoDeHabilidades.Find(id);
            ctx.TipoDeHabilidades.Remove(TipoBuscado);
            ctx.SaveChanges();
        }

        public List<TipoDeHabilidade> Listar()
        {
            return ctx.TipoDeHabilidades.ToList();
        }

        public List<TipoDeHabilidade> ListarTudo()
        {
            return ctx.TipoDeHabilidades.Include(e => e.Habilidades).ToList();
        }
    }
}
