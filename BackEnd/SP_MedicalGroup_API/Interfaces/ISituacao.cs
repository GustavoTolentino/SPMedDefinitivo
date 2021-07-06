using SP_MedicalGroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Interfaces
{
    interface ISituacao
    {
        void create(Situacao situacao);
        List<Situacao> read();
        Situacao readId(int id);
        void update(int id, Situacao situacao);
        void delete(int id);
    }
}
