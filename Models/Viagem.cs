using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Viagem
    {
        public Viagem()
        {
            ContasAPagar = new HashSet<ContasAPagar>();
            ContasAReceber = new HashSet<ContasAReceber>();
            Entrada = new HashSet<Entrada>();
            Multa = new HashSet<Multa>();
            Saida = new HashSet<Saida>();
        }

        public int CodViagem { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodCarro { get; set; }
        public int? CodEndereco { get; set; }
        public DateTime? HoraSaida { get; set; }
        public DateTime? HoraEntrada { get; set; }
        public string Descricao { get; set; }
        public int? CarroKmInicial { get; set; }
        public int? CarroKmFinal { get; set; }
        public int? CarroKmTotalViagem { get; set; }

        public virtual Carro CodCarroNavigation { get; set; }
        public virtual Endereco CodEnderecoNavigation { get; set; }
        public virtual Usuarios CodUsuarioNavigation { get; set; }
        public virtual ICollection<ContasAPagar> ContasAPagar { get; set; }
        public virtual ICollection<ContasAReceber> ContasAReceber { get; set; }
        public virtual ICollection<Entrada> Entrada { get; set; }
        public virtual ICollection<Multa> Multa { get; set; }
        public virtual ICollection<Saida> Saida { get; set; }
    }
}
