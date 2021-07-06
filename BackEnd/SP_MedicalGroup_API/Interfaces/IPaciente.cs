using SP_MedicalGroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Interfaces
{
    interface IPaciente
    {
        void create(Paciente paciente);
        List<Paciente> read();
        Paciente readId(int id);
        void update(int id, Paciente paciente);
        void delete(int id);
    }
}
