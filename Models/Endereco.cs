using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clientes = new HashSet<Clientes>();
            Viagem = new HashSet<Viagem>();
        }

        public int CodEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
        public virtual ICollection<Viagem> Viagem { get; set; }
    }
}
