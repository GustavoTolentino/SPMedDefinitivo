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
    public class ConsultumRepository : IConsultum
    {
        // Usuario, TipoDeUsuario, Clinica e Consulta
        SPMedicalGroupContext _context = new SPMedicalGroupContext();
        public void create(Consultum consultum)
        {
            _context.Consulta.Add(consultum);
            _context.SaveChanges();
        }
        public void delete(int id)
        {
            Consultum consultabuscada = _context.Consulta.Find(id);
            _context.Consulta.Remove(consultabuscada);
            _context.SaveChanges();
        }
        public void update(int id, Consultum consultum)
        {
            Consultum consultaBuscada = _context.Consulta.Find(id);
                consultaBuscada.DataConsulta = consultum.DataConsulta;
                consultaBuscada.Descricao = consultum.Descricao;
                consultaBuscada.Exames = consultum.Exames;

                _context.Consulta.Update(consultaBuscada);
                _context.SaveChanges();
        }

        List<Consultum> IConsultum.read()
        {
            return _context.Consulta.Include(x => x.IdMedicoNavigation).Include(y => y.IdPacienteNavigation).Include(z => z.IdSituacaoNavigation).ToList();
        }

        Consultum IConsultum.readId(int id)
        {
            return _context.Consulta.FirstOrDefault(x => x.IdConsulta == id);
        }
    }
}
