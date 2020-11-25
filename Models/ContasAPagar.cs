using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class ContasAPagar
    {
        public int CodContasPag { get; set; }
        public int? CodOrdemServico { get; set; }
        public int? CodViagem { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodCarro { get; set; }
        public DateTime? HoraEntrada { get; set; }

        public virtual Carro CodCarroNavigation { get; set; }
        public virtual OrderServico CodOrdemServicoNavigation { get; set; }
        public virtual Usuarios CodUsuarioNavigation { get; set; }
        public virtual Viagem CodViagemNavigation { get; set; }
    }
}
