using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClassRepository
    {
        List<Class> Listar();
        List<Class> ListarTudo();
        Class BuscarId(int id);
        void Cadastrar(Class NovaClass);
        void Deletar(int id);
        void Atualizar(int id, Class NovaClass);
    }
}
