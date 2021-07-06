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
    public class TipoUsuarioRepository : ITipoDeUsuario
    {
        SPMedicalGroupContext _context = new SPMedicalGroupContext();
        public void create(TipoDeUsuario tipoDeUsuario)
        {
            _context.TipoDeUsuarios.Add(tipoDeUsuario);
        }

        public void delete(int id)
        {
            TipoDeUsuario tipoDeUsuariobuscado = _context.TipoDeUsuarios.Find(id);
            _context.TipoDeUsuarios.Remove(tipoDeUsuariobuscado);
            _context.SaveChanges();
        }

        public List<TipoDeUsuario> read()
        {
            return _context.TipoDeUsuarios.Include(x => x.Usuarios).ToList();
        }

        public TipoDeUsuario readId(int id)
        {
            return _context.TipoDeUsuarios.FirstOrDefault(x => x.IdTipoDeUsuario == id);
        }

        public void update(int id, TipoDeUsuario tipoDeUsuario)
        {
            TipoDeUsuario tipoDeUsuariobuscado = _context.TipoDeUsuarios.Find(id);
            if (tipoDeUsuario.TipoDeUsuario1 != null)
            {
                tipoDeUsuario.TipoDeUsuario1 = tipoDeUsuariobuscado.TipoDeUsuario1;

                _context.TipoDeUsuarios.Update(tipoDeUsuariobuscado);
                _context.SaveChanges();
            }
        }
    }
}
