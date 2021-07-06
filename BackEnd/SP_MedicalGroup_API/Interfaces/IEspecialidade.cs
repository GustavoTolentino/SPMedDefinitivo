using SP_MedicalGroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Interfaces
{
    interface IEspecialidade
    {
        void create(Especialidade especialidade);
        List<Especialidade> read();
        Especialidade readId(int id);
        void update(int id, Especialidade especialidade);
        void delete(int id);
    }
}
