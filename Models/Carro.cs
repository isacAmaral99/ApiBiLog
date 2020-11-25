using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Carro
    {
        public Carro()
        {
            Abastecimento = new HashSet<Abastecimento>();
            ContasAPagar = new HashSet<ContasAPagar>();
            ContasAReceber = new HashSet<ContasAReceber>();
            Entrada = new HashSet<Entrada>();
            Locacao = new HashSet<Locacao>();
            Manutencao = new HashSet<Manutencao>();
            Multa = new HashSet<Multa>();
            OrderServico = new HashSet<OrderServico>();
            Saida = new HashSet<Saida>();
            Viagem = new HashSet<Viagem>();
        }

        public int CodCarro { get; set; }
        public int? CodUsuario { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public string Chassi { get; set; }
        public int? Quilometragem { get; set; }
        public string Descricao { get; set; }

        public virtual Usuarios CodUsuarioNavigation { get; set; }
        public virtual ICollection<Abastecimento> Abastecimento { get; set; }
        public virtual ICollection<ContasAPagar> ContasAPagar { get; set; }
        public virtual ICollection<ContasAReceber> ContasAReceber { get; set; }
        public virtual ICollection<Entrada> Entrada { get; set; }
        public virtual ICollection<Locacao> Locacao { get; set; }
        public virtual ICollection<Manutencao> Manutencao { get; set; }
        public virtual ICollection<Multa> Multa { get; set; }
        public virtual ICollection<OrderServico> OrderServico { get; set; }
        public virtual ICollection<Saida> Saida { get; set; }
        public virtual ICollection<Viagem> Viagem { get; set; }
    }
}
