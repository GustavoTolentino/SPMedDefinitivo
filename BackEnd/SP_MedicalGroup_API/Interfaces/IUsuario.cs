using SP_MedicalGroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Interfaces
{
    interface IUsuario
    {
        void create(Usuario usuario);
        List<Usuario> read();
        Usuario readId(int id);
        void update(int id, Usuario usuario);
        void delete(int id);
        public Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
