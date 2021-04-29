using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();
        List<Usuario> ListarTudo();
        Usuario BuscarId(int id);
        void Cadastrar(Usuario NovoUsuario);
        void AtualizarEmail(int id, Usuario NovoUsaurio);
        void AtualizarSenha(int id, Usuario NovoUsuario);
        void Deletar(int id);
        Usuario Login(string senha, string email);
    }
}
