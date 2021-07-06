using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_MedicalGroup_API.Interfaces
{
    interface IRepository<T> where T : class
    {
        void salvar(T entity);
        void excluir(int id);
        void alterar(int id, T entity);
        List<T> buscar();
    }
}
