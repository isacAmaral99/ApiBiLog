using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Manutencao
    {
        public int CodManutencao { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodCarro { get; set; }
        public DateTime? HoraEntrada { get; set; }
        public string Descricao { get; set; }
        public string TipoManutencao { get; set; }

        public virtual Carro CodCarroNavigation { get; set; }
        public virtual Usuarios CodUsuarioNavigation { get; set; }
    }
}
