using System;
using System.Collections.Generic;

#nullable disable

namespace SP_MedicalGroup_API.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdSituacao { get; set; }
        public string TipoSituacao { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
