using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagem> Listar();
        Personagem BuscarId(int id);
        void Cadastrar(Personagem NovoPer);
        void Deletar(int id);
        void Atualizar(int id, Personagem NovoPer);
    }
}
