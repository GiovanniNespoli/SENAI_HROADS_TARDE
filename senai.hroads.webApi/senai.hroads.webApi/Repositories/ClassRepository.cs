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
    public class ClassRepository : IClassRepository
    {
        Context_HRoads ctx = new Context_HRoads();

        public void Atualizar(int id, Class NovaClass)
        {
            Class ClassBuscada = ctx.Classes.Find(id);

            if (NovaClass.Classe != null)
            {
                ClassBuscada.Classe = NovaClass.Classe;
            }

            ctx.Classes.Update(ClassBuscada);
            ctx.SaveChanges();
        }

        public Class BuscarId(int id)
        {
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == id);
        }

        public void Cadastrar(Class NovaClass)
        {
            ctx.Classes.Add(NovaClass);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Class ClassBuscada = ctx.Classes.Find(id);
            ctx.Classes.Remove(ClassBuscada);
            ctx.SaveChanges();
        }

        public List<Class> Listar()
        {
            return ctx.Classes.ToList();
        }

        public List<Class> ListarTudo()
        {
            return ctx.Classes.Include(e => e.Personagems).ToList();
        }
    }
}
