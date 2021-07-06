using SP_MedicalGroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Interfaces
{
    interface IClinica
    {
        void create(Clinica clinica);
        List<Clinica> read();
        Clinica readId(int id);
        void update(int id, Clinica clinica);
        void delete(int id);
    }
}
