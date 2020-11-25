using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Locacao
    {
        public int Codlocacao { get; set; }
        public int CodCarro { get; set; }
        public int? CodSaida { get; set; }
        public int? CodEntrada { get; set; }
        public decimal Valorlocacao { get; set; }
        public DateTime Datalocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

        public virtual Carro CodCarroNavigation { get; set; }
        public virtual Entrada CodEntradaNavigation { get; set; }
        public virtual Saida CodSaidaNavigation { get; set; }
    }
}
