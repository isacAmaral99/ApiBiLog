using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int CodCliente { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }
        public string Empresa { get; set; }
        public string Email { get; set; }
        public int CodEndereco { get; set; }

        public virtual Endereco CodEnderecoNavigation { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
