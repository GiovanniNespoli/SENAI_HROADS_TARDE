using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoDeUsuarioRepository
    {
        void Atualizar(int id, TipoUsuario NovoTipo);
        TipoUsuario BuscarId(int id);
        void Cadastrar(TipoUsuario NovoTipo);
        void Deletar(int id);
        List<TipoUsuario> Listar();
        List<TipoUsuario> ListarTudo();
    }
}
