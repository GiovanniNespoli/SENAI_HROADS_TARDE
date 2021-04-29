using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoDeHabilidadeRepository
    {
        List<TipoDeHabilidade> Listar();
        List<TipoDeHabilidade> ListarTudo();
        TipoDeHabilidade BuscarId(int id);
        void Cadastrar(TipoDeHabilidade NovoTipo);
        void Atualizar(int id, TipoDeHabilidade NovoTipo);
        void Deletar(int id);
    }
}
