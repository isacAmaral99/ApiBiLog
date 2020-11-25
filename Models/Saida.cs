using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Saida
    {
        public Saida()
        {
            Locacao = new HashSet<Locacao>();
        }

        public int CodSaida { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodViagem { get; set; }
        public int? CodCarro { get; set; }
        public DateTime? HoraSaida { get; set; }

        public virtual Carro CodCarroNavigation { get; set; }
        public virtual Usuarios CodUsuarioNavigation { get; set; }
        public virtual Viagem CodViagemNavigation { get; set; }
        public virtual ICollection<Locacao> Locacao { get; set; }
    }
}
