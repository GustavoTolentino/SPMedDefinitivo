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
    public class ClinicaRepository : IClinica
    {
        // Usuario, TipoDeUsuario, Clinica e Consulta
        SPMedicalGroupContext _context = new SPMedicalGroupContext();
        public void create(Clinica clinica)
        {
            _context.Clinicas.Add(clinica);
        }

        public void delete(int id)
        {
            Clinica clinicabuscada = _context.Clinicas.Find(id);
            _context.Clinicas.Remove(clinicabuscada);
            _context.SaveChanges();
        }

        public List<Clinica> read()
        {
            return _context.Clinicas.Include(x => x.Medicos).ToList();
        }

        public Clinica readId(int id)
        {
            return _context.Clinicas.FirstOrDefault(x => x.IdClinica == id);
        }

        public void update(int id, Clinica clinica)
        {
            Clinica clinicaBuscada = _context.Clinicas.Find(id);
            if (clinica.Cnpj != null)
            {
                clinicaBuscada.Cnpj = clinica.Cnpj;
                clinicaBuscada.Endereco = clinica.Endereco;
                clinicaBuscada.HorarioDeAbertura = clinica.HorarioDeAbertura;
                clinicaBuscada.HorarioDeEncerrar = clinica.HorarioDeEncerrar;
                clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;

                _context.Clinicas.Update(clinicaBuscada);
                _context.SaveChanges();
            }
        }
    }
}
