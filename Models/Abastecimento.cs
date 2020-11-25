using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Abastecimento
    {
        public int CodAbastecimento { get; set; }
        public int? CodOrdemServico { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodCarro { get; set; }
        public DateTime? HoraEntrada { get; set; }

        public virtual Carro CodCarroNavigation { get; set; }
        public virtual OrderServico CodOrdemServicoNavigation { get; set; }
        public virtual Usuarios CodUsuarioNavigation { get; set; }
    }
}
