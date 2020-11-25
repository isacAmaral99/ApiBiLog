using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class OrderServico
    {
        public OrderServico()
        {
            Abastecimento = new HashSet<Abastecimento>();
            ContasAPagar = new HashSet<ContasAPagar>();
            ContasAReceber = new HashSet<ContasAReceber>();
            Multa = new HashSet<Multa>();
        }

        public int CodOrdemServico { get; set; }
        public int? CodCliente { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodCarro { get; set; }
        public string Descricao { get; set; }

        public virtual Carro CodCarroNavigation { get; set; }
        public virtual Usuarios CodUsuarioNavigation { get; set; }
        public virtual ICollection<Abastecimento> Abastecimento { get; set; }
        public virtual ICollection<ContasAPagar> ContasAPagar { get; set; }
        public virtual ICollection<ContasAReceber> ContasAReceber { get; set; }
        public virtual ICollection<Multa> Multa { get; set; }
    }
}
