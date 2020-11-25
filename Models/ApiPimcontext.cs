using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apiwebpim.Models
{
    public partial class ApiPimcontext : DbContext
    {
        public ApiPimcontext()
        {
        }

        public ApiPimcontext(DbContextOptions<ApiPimcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abastecimento> Abastecimento { get; set; }
        public virtual DbSet<Carro> Carro { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<ContasAPagar> ContasAPagar { get; set; }
        public virtual DbSet<ContasAReceber> ContasAReceber { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Entrada> Entrada { get; set; }
        public virtual DbSet<Locacao> Locacao { get; set; }
        public virtual DbSet<Manutencao> Manutencao { get; set; }
        public virtual DbSet<Multa> Multa { get; set; }
        public virtual DbSet<OrderServico> OrderServico { get; set; }
        public virtual DbSet<Perfis> Perfis { get; set; }
        public virtual DbSet<Saida> Saida { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Viagem> Viagem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-OUVKJRN\\SQLEXPRESS;Initial Catalog=BiTeclogyPimIv;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abastecimento>(entity =>
            {
                entity.HasKey(e => e.CodAbastecimento)
                    .HasName("PK__Abasteci__68EC515E07BCB98C");

                entity.Property(e => e.HoraEntrada).HasColumnType("datetime");

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.Abastecimento)
                    .HasForeignKey(d => d.CodCarro)
                    .HasConstraintName("Fk_AbastecimentoCarro");

                entity.HasOne(d => d.CodOrdemServicoNavigation)
                    .WithMany(p => p.Abastecimento)
                    .HasForeignKey(d => d.CodOrdemServico)
                    .HasConstraintName("Fk_AbastecimentoOrdem");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Abastecimento)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_AbastecimentoUsuario");
            });

            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasKey(e => e.CodCarro)
                    .HasName("PK__Carro__D1048B98A80B6463");

                entity.Property(e => e.Ano)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Chassi)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Carro)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_CarroUsuario");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PK__Clientes__DF8324D7F00AC40C");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodEnderecoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ClienteEndereco");
            });

            modelBuilder.Entity<ContasAPagar>(entity =>
            {
                entity.HasKey(e => e.CodContasPag)
                    .HasName("PK__Contas_A__86207A5E2E8E0714");

                entity.ToTable("Contas_A_Pagar");

                entity.Property(e => e.HoraEntrada).HasColumnType("datetime");

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.ContasAPagar)
                    .HasForeignKey(d => d.CodCarro)
                    .HasConstraintName("Fk_ContPagCarro");

                entity.HasOne(d => d.CodOrdemServicoNavigation)
                    .WithMany(p => p.ContasAPagar)
                    .HasForeignKey(d => d.CodOrdemServico)
                    .HasConstraintName("Fk_ContPagOrdem");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.ContasAPagar)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_ContPagUsuario");

                entity.HasOne(d => d.CodViagemNavigation)
                    .WithMany(p => p.ContasAPagar)
                    .HasForeignKey(d => d.CodViagem)
                    .HasConstraintName("Fk_ContPagViagem");
            });

            modelBuilder.Entity<ContasAReceber>(entity =>
            {
                entity.HasKey(e => e.CodContasRec)
                    .HasName("PK__Contas_A__84B41E57B1BCED55");

                entity.ToTable("Contas_A_Receber");

                entity.Property(e => e.HoraEntrada).HasColumnType("datetime");

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.ContasAReceber)
                    .HasForeignKey(d => d.CodCarro)
                    .HasConstraintName("Fk_ContRecCarro");

                entity.HasOne(d => d.CodOrdemServicoNavigation)
                    .WithMany(p => p.ContasAReceber)
                    .HasForeignKey(d => d.CodOrdemServico)
                    .HasConstraintName("Fk_ContRecOrdem");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.ContasAReceber)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_ContRecUsuario");

                entity.HasOne(d => d.CodViagemNavigation)
                    .WithMany(p => p.ContasAReceber)
                    .HasForeignKey(d => d.CodViagem)
                    .HasConstraintName("Fk_ContRecViagem");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.CodEndereco)
                    .HasName("PK__endereco__5488A470D128F7CE");

                entity.ToTable("endereco");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrada>(entity =>
            {
                entity.HasKey(e => e.CodEntrada)
                    .HasName("PK__Entrada__E2CBED04CF6AC12F");

                entity.Property(e => e.HoraEntrada).HasColumnType("datetime");

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.CodCarro)
                    .HasConstraintName("Fk_EntradaCarro");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_EntradaUsuario");

                entity.HasOne(d => d.CodViagemNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.CodViagem)
                    .HasConstraintName("Fk_EntradaViagem");
            });

            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.HasKey(e => e.Codlocacao)
                    .HasName("PK__Locacao__BFA8FDF4E580CEFB");

                entity.Property(e => e.DataDevolucao).HasColumnType("datetime");

                entity.Property(e => e.Datalocacao).HasColumnType("datetime");

                entity.Property(e => e.Valorlocacao).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.Locacao)
                    .HasForeignKey(d => d.CodCarro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_LocacCarro");

                entity.HasOne(d => d.CodEntradaNavigation)
                    .WithMany(p => p.Locacao)
                    .HasForeignKey(d => d.CodEntrada)
                    .HasConstraintName("Fk_LocacCodEntrada");

                entity.HasOne(d => d.CodSaidaNavigation)
                    .WithMany(p => p.Locacao)
                    .HasForeignKey(d => d.CodSaida)
                    .HasConstraintName("Fk_LocacCodSaida");
            });

            modelBuilder.Entity<Manutencao>(entity =>
            {
                entity.HasKey(e => e.CodManutencao)
                    .HasName("PK__Manutenc__B323FBA77A05A79C");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HoraEntrada).HasColumnType("datetime");

                entity.Property(e => e.TipoManutencao)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.Manutencao)
                    .HasForeignKey(d => d.CodCarro)
                    .HasConstraintName("Fk_ManutencaoCarro");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Manutencao)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_ManutencaoUsuario");
            });

            modelBuilder.Entity<Multa>(entity =>
            {
                entity.HasKey(e => e.CodMulta)
                    .HasName("PK__Multa__33C707639B6D2D77");

                entity.Property(e => e.HoraEntrada).HasColumnType("datetime");

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.Multa)
                    .HasForeignKey(d => d.CodCarro)
                    .HasConstraintName("Fk_MultaCarro");

                entity.HasOne(d => d.CodOrdemServicoNavigation)
                    .WithMany(p => p.Multa)
                    .HasForeignKey(d => d.CodOrdemServico)
                    .HasConstraintName("Fk_MultaOrdem");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Multa)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_MultaUsuario");

                entity.HasOne(d => d.CodViagemNavigation)
                    .WithMany(p => p.Multa)
                    .HasForeignKey(d => d.CodViagem)
                    .HasConstraintName("Fk_MultaViagem");
            });

            modelBuilder.Entity<OrderServico>(entity =>
            {
                entity.HasKey(e => e.CodOrdemServico)
                    .HasName("PK__OrderSer__FD9F5763BD2FAD5B");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.OrderServico)
                    .HasForeignKey(d => d.CodCarro)
                    .HasConstraintName("Fk_CarroOrdem");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.OrderServico)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_UsuerOrdemServico");
            });

            modelBuilder.Entity<Perfis>(entity =>
            {
                entity.HasKey(e => e.CodPerfil)
                    .HasName("PK__Perfis__069D2A173099148D");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPerfil)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Saida>(entity =>
            {
                entity.HasKey(e => e.CodSaida)
                    .HasName("PK__Saida__5414A9E111E835B0");

                entity.Property(e => e.HoraSaida).HasColumnType("datetime");

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.Saida)
                    .HasForeignKey(d => d.CodCarro)
                    .HasConstraintName("Fk_SaidaCarro");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Saida)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_SaidaUsuario");

                entity.HasOne(d => d.CodViagemNavigation)
                    .WithMany(p => p.Saida)
                    .HasForeignKey(d => d.CodViagem)
                    .HasConstraintName("Fk_SaidaViagem");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("PK__Usuarios__FC30C2C4E9134FEB");

                entity.Property(e => e.Cnh)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_UsuariosClientes");

                entity.HasOne(d => d.CodPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_PerfilUsuario");
            });

            modelBuilder.Entity<Viagem>(entity =>
            {
                entity.HasKey(e => e.CodViagem)
                    .HasName("PK__Viagem__E18F332694213DA6");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HoraEntrada).HasColumnType("datetime");

                entity.Property(e => e.HoraSaida).HasColumnType("datetime");

                entity.HasOne(d => d.CodCarroNavigation)
                    .WithMany(p => p.Viagem)
                    .HasForeignKey(d => d.CodCarro)
                    .HasConstraintName("Fk_ViagemCarro");

                entity.HasOne(d => d.CodEnderecoNavigation)
                    .WithMany(p => p.Viagem)
                    .HasForeignKey(d => d.CodEndereco)
                    .HasConstraintName("Fk_ViagemEndereco");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Viagem)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Fk_ViagemUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
