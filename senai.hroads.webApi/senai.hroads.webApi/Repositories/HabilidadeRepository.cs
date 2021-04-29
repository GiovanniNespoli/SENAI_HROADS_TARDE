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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        Context_HRoads ctx = new Context_HRoads();

        public void Atualizar(int id, Habilidade NovaHab)
        {
            Habilidade HabBuscada = ctx.Habilidades.Find(id);

            if (NovaHab.Habilidade1 != null)
            {
                HabBuscada.Habilidade1 = NovaHab.Habilidade1;
            }

            ctx.Habilidades.Update(HabBuscada);
            ctx.SaveChanges();
        }

        public Habilidade BuscarId(int id)
        {
            return ctx.Habilidades.FirstOrDefault(e => e.IdHabilidade == id);
        }

        public void Cadastrar(Habilidade NovaHab)
        {
            ctx.Habilidades.Add(NovaHab);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Habilidade HabBuscada = ctx.Habilidades.Find(id);
            ctx.Habilidades.Remove(HabBuscada);
            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
           return ctx.Habilidades.ToList();
        }

        public List<Habilidade> ListarTudo()
        {
           return ctx.Habilidades.Include(e => e.Classes).ToList();
        }
    }
}
