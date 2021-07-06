using SP_MedicalGroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Interfaces
{
    public interface IConsultum
    {
        void create(Consultum consultum);
        List<Consultum> read();
        Consultum readId(int id);
        void update(int id, Consultum consultum);
        void delete(int id);
    }
}
