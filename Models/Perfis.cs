using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Perfis
    {
        public Perfis()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int CodPerfil { get; set; }
        public string TipoPerfil { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
