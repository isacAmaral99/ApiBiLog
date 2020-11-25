using System;
using System.Collections.Generic;

namespace apiwebpim.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Abastecimento = new HashSet<Abastecimento>();
            Carro = new HashSet<Carro>();
            ContasAPagar = new HashSet<ContasAPagar>();
            ContasAReceber = new HashSet<ContasAReceber>();
            Entrada = new HashSet<Entrada>();
            Manutencao = new HashSet<Manutencao>();
            Multa = new HashSet<Multa>();
            OrderServico = new HashSet<OrderServico>();
            Saida = new HashSet<Saida>();
            Viagem = new HashSet<Viagem>();
        }

        public int CodUsuario { get; set; }
        public int CodPerfil { get; set; }
        public int CodCliente { get; set; }
        public int UserAtivo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cnh { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }

        public virtual Clientes CodClienteNavigation { get; set; }
        public virtual Perfis CodPerfilNavigation { get; set; }
        public virtual ICollection<Abastecimento> Abastecimento { get; set; }
        public virtual ICollection<Carro> Carro { get; set; }
        public virtual ICollection<ContasAPagar> ContasAPagar { get; set; }
        public virtual ICollection<ContasAReceber> ContasAReceber { get; set; }
        public virtual ICollection<Entrada> Entrada { get; set; }
        public virtual ICollection<Manutencao> Manutencao { get; set; }
        public virtual ICollection<Multa> Multa { get; set; }
        public virtual ICollection<OrderServico> OrderServico { get; set; }
        public virtual ICollection<Saida> Saida { get; set; }
        public virtual ICollection<Viagem> Viagem { get; set; }
    }
}
