using SP_MedicalGroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Interfaces
{
    interface IMedico
    {
        // Isso fica de licao
        void create(Medico medico);
        List<Medico> read();
        Medico readId(int id);
        void update(int id, Medico medico);
        void delete(int id);
    }
}
