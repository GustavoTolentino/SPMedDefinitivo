using Microsoft.EntityFrameworkCore;
using SP_MedicalGroup_API.Contexts;
using SP_MedicalGroup_API.Domains;
using SP_MedicalGroup_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        SPMedicalGroupContext _context = new SPMedicalGroupContext();
        public void create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void delete(int id)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuarioBuscado);
            _context.SaveChanges();
        }

        public List<Usuario> read()
        {
            return _context.Usuarios.Include(x => x.IdTipoDeUsuarioNavigation).ToList();
        }

        public Usuario readId(int id)
        {
            throw new NotImplementedException();
        }

        public void update(int id, Usuario usuario)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);
            if (usuario.Email != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Medicos = usuario.Medicos;
                usuarioBuscado.Pacientes = usuario.Pacientes;

                _context.Usuarios.Update(usuarioBuscado);
                _context.SaveChanges();
            }
        }
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            Usuario usuarioLogin = _context.Usuarios.Include(e => e.IdTipoDeUsuarioNavigation).FirstOrDefault(e => e.Email == email && e.Senha == senha);

            if (usuarioLogin.Email != null)
            {
                return usuarioLogin;
            }

            return null;
        }
    }
}
