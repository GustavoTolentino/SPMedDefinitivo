using SP_MedicalGroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Interfaces
{
    interface ITipoDeUsuario
    {
        void create(TipoDeUsuario tipoDeUsuario);
        List<TipoDeUsuario> read();
        TipoDeUsuario readId(int id);
        void update(int id, TipoDeUsuario tipoDeUsuario);
        void delete(int id);
    }
}
