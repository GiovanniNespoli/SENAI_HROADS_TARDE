using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();
        List<Habilidade> ListarTudo();
        Habilidade BuscarId(int id);
        void Cadastrar(Habilidade NovaHab);
        void Deletar(int id);
        void Atualizar(int id, Habilidade NovaHab);
    }
}
