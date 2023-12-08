using IofficePlus.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IofficePlus.Dados.Contexts;

public partial class IofficedbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public IofficedbContext(DbContextOptions<IofficedbContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    #region DbSets

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<TabAcao> TabAcaos { get; set; }

    public virtual DbSet<TabAcaoDocumento> TabAcaoDocumentos { get; set; }

    public virtual DbSet<TabAgentePublico> TabAgentePublicos { get; set; }

    public virtual DbSet<TabAssinatura> TabAssinaturas { get; set; }

    public virtual DbSet<TabAtendimento> TabAtendimentos { get; set; }

    public virtual DbSet<TabCliente> TabClientes { get; set; }

    public virtual DbSet<TabClienteDocumento> TabClienteDocumentos { get; set; }

    public virtual DbSet<TabConcessaoItensRemuneratorio> TabConcessaoItensRemuneratorios { get; set; }

    public virtual DbSet<TabContaBancarium> TabContaBancaria { get; set; }

    public virtual DbSet<TabControladora> TabControladoras { get; set; }

    public virtual DbSet<TabControleNotificacao> TabControleNotificacaos { get; set; }

    public virtual DbSet<TabControleNotificacaoAssinatura> TabControleNotificacaoAssinaturas { get; set; }

    public virtual DbSet<TabControleNotificacaoDocumento> TabControleNotificacaoDocumentos { get; set; }

    public virtual DbSet<TabControleNotificacaoEvento> TabControleNotificacaoEventos { get; set; }

    public virtual DbSet<TabControleProcesso> TabControleProcessos { get; set; }

    public virtual DbSet<TabControleProcessoAcao> TabControleProcessoAcaos { get; set; }

    public virtual DbSet<TabControleProcessoAcaoDocumento> TabControleProcessoAcaoDocumentos { get; set; }

    public virtual DbSet<TabControleProcessoTramitacao> TabControleProcessoTramitacaos { get; set; }

    public virtual DbSet<TabControleViagem> TabControleViagems { get; set; }

    public virtual DbSet<TabControleViagemDocumento> TabControleViagemDocumentos { get; set; }

    public virtual DbSet<TabDesligamentoAgentePublico> TabDesligamentoAgentePublicos { get; set; }

    public virtual DbSet<TabEntidadeAdministrativa> TabEntidadeAdministrativas { get; set; }

    public virtual DbSet<TabEscritorio> TabEscritorios { get; set; }

    public virtual DbSet<TabEstado> TabEstados { get; set; }

    public virtual DbSet<TabFormaIngressoServicoPublico> TabFormaIngressoServicoPublicos { get; set; }

    public virtual DbSet<TabItemRemuneratorio> TabItemRemuneratorios { get; set; }

    public virtual DbSet<TabMantenedora> TabMantenedoras { get; set; }

    public virtual DbSet<TabMembroSetor> TabMembroSetors { get; set; }

    public virtual DbSet<TabMonitoramento> TabMonitoramentos { get; set; }

    public virtual DbSet<TabMunicipio> TabMunicipios { get; set; }

    public virtual DbSet<TabNotificacao> TabNotificacaos { get; set; }

    public virtual DbSet<TabOcorrencium> TabOcorrencia { get; set; }

    public virtual DbSet<TabOcupacao> TabOcupacaos { get; set; }

    public virtual DbSet<TabOrdenadorDespesa> TabOrdenadorDespesas { get; set; }

    public virtual DbSet<TabOrgao> TabOrgaos { get; set; }

    public virtual DbSet<TabPessoa> TabPessoas { get; set; }

    public virtual DbSet<TabProtocolo> TabProtocolos { get; set; }

    public virtual DbSet<TabProtocoloControle> TabProtocoloControles { get; set; }

    public virtual DbSet<TabProtocoloDocumento> TabProtocoloDocumentos { get; set; }

    public virtual DbSet<TabPublicacaoDocumento> TabPublicacaoDocumentos { get; set; }

    public virtual DbSet<TabRecebimentoSim> TabRecebimentoSims { get; set; }

    public virtual DbSet<TabRegimeJuridicoRelacaoFuncional> TabRegimeJuridicoRelacaoFuncionals { get; set; }

    public virtual DbSet<TabRegimePrevidenciario> TabRegimePrevidenciarios { get; set; }

    public virtual DbSet<TabReingressoAgentePublico> TabReingressoAgentePublicos { get; set; }

    public virtual DbSet<TabResponsavelControladora> TabResponsavelControladoras { get; set; }

    public virtual DbSet<TabResponsavelEscritorio> TabResponsavelEscritorios { get; set; }

    public virtual DbSet<TabSetor> TabSetors { get; set; }

    public virtual DbSet<TabTarefa> TabTarefas { get; set; }

    public virtual DbSet<TabTipoAmparoLegalExpedienteNomeacao> TabTipoAmparoLegalExpedienteNomeacaos { get; set; }

    public virtual DbSet<TabTipoCargo> TabTipoCargos { get; set; }

    public virtual DbSet<TabTipoExpedienteNomeacao> TabTipoExpedienteNomeacaos { get; set; }

    public virtual DbSet<TabTipoRelacaoServicoPublico> TabTipoRelacaoServicoPublicos { get; set; }

    public virtual DbSet<TabTribunal> TabTribunals { get; set; }

    public virtual DbSet<TabUnidadeGestora> TabUnidadeGestoras { get; set; }

    public virtual DbSet<TabUnidadeOrcamentarium> TabUnidadeOrcamentaria { get; set; }

    public virtual DbSet<TabUsuario> TabUsuarios { get; set; }

    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("IOFFICEDBConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region DataBase First Migration

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<TabAcao>(entity =>
        {
            entity.HasKey(e => e.IdAcao).HasName("PK_dbo.TAB_ACAO");

            entity.ToTable("TAB_ACAO");

            entity.HasIndex(e => e.IdAgentePublico, "IX_ID_AGENTE_PUBLICO");

            entity.HasIndex(e => e.IdResponsavelEscritorioAcao, "IX_ID_RESPONSAVEL_ESCRITORIO_ACAO");

            entity.HasIndex(e => e.IdTarefa, "IX_ID_TAREFA");

            entity.HasIndex(e => e.IdUnidadeGestora, "IX_ID_UNIDADE_GESTORA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdAcao).HasColumnName("ID_ACAO");
            entity.Property(e => e.DsAcao)
                .HasMaxLength(1000)
                .HasColumnName("DS_ACAO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtFimAcao)
                .HasColumnType("datetime")
                .HasColumnName("DT_FIM_ACAO");
            entity.Property(e => e.DtInicioAcao)
                .HasColumnType("datetime")
                .HasColumnName("DT_INICIO_ACAO");
            entity.Property(e => e.DtPrevisaoFim)
                .HasColumnType("datetime")
                .HasColumnName("DT_PREVISAO_FIM");
            entity.Property(e => e.IdAgentePublico).HasColumnName("ID_AGENTE_PUBLICO");
            entity.Property(e => e.IdResponsavelEscritorioAcao).HasColumnName("ID_RESPONSAVEL_ESCRITORIO_ACAO");
            entity.Property(e => e.IdTarefa).HasColumnName("ID_TAREFA");
            entity.Property(e => e.IdUnidadeGestora).HasColumnName("ID_UNIDADE_GESTORA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.TpSituacaoAcao).HasColumnName("TP_SITUACAO_ACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdAgentePublicoNavigation).WithMany(p => p.TabAcaos)
                .HasForeignKey(d => d.IdAgentePublico)
                .HasConstraintName("FK_dbo.TAB_ACAO_dbo.TAB_AGENTE_PUBLICO_ID_AGENTE_PUBLICO");

            entity.HasOne(d => d.IdResponsavelEscritorioAcaoNavigation).WithMany(p => p.TabAcaos)
                .HasForeignKey(d => d.IdResponsavelEscritorioAcao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ACAO_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO_ACAO");

            entity.HasOne(d => d.IdTarefaNavigation).WithMany(p => p.TabAcaos)
                .HasForeignKey(d => d.IdTarefa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ACAO_dbo.TAB_TAREFA_ID_TAREFA");

            entity.HasOne(d => d.IdUnidadeGestoraNavigation).WithMany(p => p.TabAcaos)
                .HasForeignKey(d => d.IdUnidadeGestora)
                .HasConstraintName("FK_dbo.TAB_ACAO_dbo.TAB_UNIDADE_GESTORA_ID_UNIDADE_GESTORA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabAcaos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_ACAO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabAcaoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdAcaoDocumento).HasName("PK_dbo.TAB_ACAO_DOCUMENTO");

            entity.ToTable("TAB_ACAO_DOCUMENTO");

            entity.HasIndex(e => e.IdAcao, "IX_ID_ACAO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdAcaoDocumento).HasColumnName("ID_ACAO_DOCUMENTO");
            entity.Property(e => e.CaminhoCompletoDocumento)
                .HasMaxLength(255)
                .HasColumnName("CAMINHO_COMPLETO_DOCUMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdAcao).HasColumnName("ID_ACAO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmDocumento)
                .HasMaxLength(100)
                .HasColumnName("NM_DOCUMENTO");
            entity.Property(e => e.TpDocumento).HasColumnName("TP_DOCUMENTO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdAcaoNavigation).WithMany(p => p.TabAcaoDocumentos)
                .HasForeignKey(d => d.IdAcao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ACAO_DOCUMENTO_dbo.TAB_ACAO_ID_ACAO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabAcaoDocumentos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_ACAO_DOCUMENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabAgentePublico>(entity =>
        {
            entity.HasKey(e => e.IdAgentePublico).HasName("PK_dbo.TAB_AGENTE_PUBLICO");

            entity.ToTable("TAB_AGENTE_PUBLICO");

            entity.HasIndex(e => e.CdTipoCargo, "IX_CD_TIPO_CARGO");

            entity.HasIndex(e => e.FormaIngressoServicoPublicoFormaIngresso, "IX_FormaIngressoServicoPublico_FormaIngresso");

            entity.HasIndex(e => e.IdControladora, "IX_ID_CONTROLADORA");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdOcupacao, "IX_ID_OCUPACAO");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdPessoa, "IX_ID_PESSOA");

            entity.HasIndex(e => e.IdUnidadeOrcamentaria, "IX_ID_UNIDADE_ORCAMENTARIA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.HasIndex(e => e.TpAmparoLegal, "IX_TP_AMPARO_LEGAL");

            entity.HasIndex(e => e.TpExpedienteNomeacao, "IX_TP_EXPEDIENTE_NOMEACAO");

            entity.HasIndex(e => e.TpRegimeJuridico, "IX_TP_REGIME_JURIDICO");

            entity.HasIndex(e => e.TpRegimePrevidenciario, "IX_TP_REGIME_PREVIDENCIARIO");

            entity.HasIndex(e => e.TipoRelacaoServicoPublicoTipoRelacao, "IX_TipoRelacaoServicoPublico_TipoRelacao");

            entity.Property(e => e.IdAgentePublico).HasColumnName("ID_AGENTE_PUBLICO");
            entity.Property(e => e.CargaHorariaSemanal).HasColumnName("CARGA_HORARIA_SEMANAL");
            entity.Property(e => e.CdTipoCargo)
                .HasMaxLength(128)
                .HasColumnName("CD_TIPO_CARGO");
            entity.Property(e => e.DtAmaparoLegal)
                .HasColumnType("datetime")
                .HasColumnName("DT_AMAPARO_LEGAL");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtExpedienteNomeacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_EXPEDIENTE_NOMEACAO");
            entity.Property(e => e.DtPosse)
                .HasColumnType("datetime")
                .HasColumnName("DT_POSSE");
            entity.Property(e => e.DtPubAmparoLegal)
                .HasColumnType("datetime")
                .HasColumnName("DT_PUB_AMPARO_LEGAL");
            entity.Property(e => e.DtRefDocumentacao).HasColumnName("DT_REF_DOCUMENTACAO");
            entity.Property(e => e.FormaIngressoServicoPublicoFormaIngresso)
                .HasMaxLength(128)
                .HasColumnName("FormaIngressoServicoPublico_FormaIngresso");
            entity.Property(e => e.IdControladora).HasColumnName("ID_CONTROLADORA");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdOcupacao).HasColumnName("ID_OCUPACAO");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");
            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NrAmparoLegal)
                .HasMaxLength(10)
                .HasColumnName("NR_AMPARO_LEGAL");
            entity.Property(e => e.NrCpf)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF");
            entity.Property(e => e.NrDependentes).HasColumnName("NR_DEPENDENTES");
            entity.Property(e => e.NrExercicio).HasColumnName("NR_EXERCICIO");
            entity.Property(e => e.NrExpedienteNomeacao)
                .HasMaxLength(10)
                .HasColumnName("NR_EXPEDIENTE_NOMEACAO");
            entity.Property(e => e.NrMatriculaMunicipal)
                .HasMaxLength(15)
                .HasColumnName("NR_MATRICULA_MUNICIPAL");
            entity.Property(e => e.StFuncional).HasColumnName("ST_FUNCIONAL");
            entity.Property(e => e.TipoRelacaoServicoPublicoTipoRelacao)
                .HasMaxLength(128)
                .HasColumnName("TipoRelacaoServicoPublico_TipoRelacao");
            entity.Property(e => e.TpAmparoLegal)
                .HasMaxLength(128)
                .HasColumnName("TP_AMPARO_LEGAL");
            entity.Property(e => e.TpExpedienteNomeacao)
                .HasMaxLength(128)
                .HasColumnName("TP_EXPEDIENTE_NOMEACAO");
            entity.Property(e => e.TpPrograma).HasColumnName("TP_PROGRAMA");
            entity.Property(e => e.TpRegimeJuridico)
                .HasMaxLength(128)
                .HasColumnName("TP_REGIME_JURIDICO");
            entity.Property(e => e.TpRegimePrevidenciario)
                .HasMaxLength(128)
                .HasColumnName("TP_REGIME_PREVIDENCIARIO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.CdTipoCargoNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.CdTipoCargo)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_TIPO_CARGO_CD_TIPO_CARGO");

            entity.HasOne(d => d.FormaIngressoServicoPublicoFormaIngressoNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.FormaIngressoServicoPublicoFormaIngresso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_FORMA_INGRESSO_SERVICO_PUBLICO_FormaIngressoServicoPublico_FormaIngresso");

            entity.HasOne(d => d.IdControladoraNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.IdControladora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_CONTROLADORA_ID_CONTROLADORA");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdOcupacaoNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.IdOcupacao)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_OCUPACAO_ID_OCUPACAO");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.IdOrgao)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.IdPessoa)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_PESSOA_ID_PESSOA");

            entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_UNIDADE_ORCAMENTARIA_ID_UNIDADE_ORCAMENTARIA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");

            entity.HasOne(d => d.TipoRelacaoServicoPublicoTipoRelacaoNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.TipoRelacaoServicoPublicoTipoRelacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_TIPO_RELACAO_SERVICO_PUBLICO_TipoRelacaoServicoPublico_TipoRelacao");

            entity.HasOne(d => d.TpAmparoLegalNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.TpAmparoLegal)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_TIPO_AMPARO_LEGAL_EXPEDIENTE_NOMEACAO_TP_AMPARO_LEGAL");

            entity.HasOne(d => d.TpExpedienteNomeacaoNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.TpExpedienteNomeacao)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_TIPO_EXPEDIENTE_NOMEACAO_TP_EXPEDIENTE_NOMEACAO");

            entity.HasOne(d => d.TpRegimeJuridicoNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.TpRegimeJuridico)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_REGIME_JURIDICO_RELACAO_FUNCIONAL_TP_REGIME_JURIDICO");

            entity.HasOne(d => d.TpRegimePrevidenciarioNavigation).WithMany(p => p.TabAgentePublicos)
                .HasForeignKey(d => d.TpRegimePrevidenciario)
                .HasConstraintName("FK_dbo.TAB_AGENTE_PUBLICO_dbo.TAB_REGIME_PREVIDENCIARIO_TP_REGIME_PREVIDENCIARIO");
        });

        modelBuilder.Entity<TabAssinatura>(entity =>
        {
            entity.HasKey(e => e.IdAssinatura).HasName("PK_dbo.TAB_ASSINATURA");

            entity.ToTable("TAB_ASSINATURA");

            entity.HasIndex(e => e.CdTipoCargo, "IX_CD_TIPO_CARGO");

            entity.HasIndex(e => e.FormaIngresso, "IX_FORMA_INGRESSO");

            entity.HasIndex(e => e.IdAgentePublico, "IX_ID_AGENTE_PUBLICO");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdUnidadeGestora, "IX_ID_UNIDADE_GESTORA");

            entity.HasIndex(e => e.IdUnidadeOrcamentaria, "IX_ID_UNIDADE_ORCAMENTARIA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.HasIndex(e => e.TipoAmparo, "IX_TIPO_AMPARO");

            entity.HasIndex(e => e.TipoExpediente, "IX_TIPO_EXPEDIENTE");

            entity.HasIndex(e => e.TipoRelacao, "IX_TIPO_RELACAO");

            entity.Property(e => e.IdAssinatura).HasColumnName("ID_ASSINATURA");
            entity.Property(e => e.CdTipoCargo)
                .HasMaxLength(128)
                .HasColumnName("CD_TIPO_CARGO");
            entity.Property(e => e.DtAmparo)
                .HasColumnType("datetime")
                .HasColumnName("DT_AMPARO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtExpediente)
                .HasColumnType("datetime")
                .HasColumnName("DT_EXPEDIENTE");
            entity.Property(e => e.DtFimVigencia)
                .HasColumnType("datetime")
                .HasColumnName("DT_FIM_VIGENCIA");
            entity.Property(e => e.DtFimVigenciaCertificado)
                .HasColumnType("datetime")
                .HasColumnName("DT_FIM_VIGENCIA_CERTIFICADO");
            entity.Property(e => e.DtInicioVigencia)
                .HasColumnType("datetime")
                .HasColumnName("DT_INICIO_VIGENCIA");
            entity.Property(e => e.DtInicioVigenciaCertificado)
                .HasColumnType("datetime")
                .HasColumnName("DT_INICIO_VIGENCIA_CERTIFICADO");
            entity.Property(e => e.DtPublicacaoAmparo)
                .HasColumnType("datetime")
                .HasColumnName("DT_PUBLICACAO_AMPARO");
            entity.Property(e => e.DtRefDocumentacao).HasColumnName("DT_REF_DOCUMENTACAO");
            entity.Property(e => e.FormaIngresso)
                .HasMaxLength(128)
                .HasColumnName("FORMA_INGRESSO");
            entity.Property(e => e.IdAgentePublico).HasColumnName("ID_AGENTE_PUBLICO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdUnidadeGestora).HasColumnName("ID_UNIDADE_GESTORA");
            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NrAmparo)
                .HasMaxLength(10)
                .HasColumnName("NR_AMPARO");
            entity.Property(e => e.NrCertificado)
                .HasMaxLength(100)
                .HasColumnName("NR_CERTIFICADO");
            entity.Property(e => e.NrCpf)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF");
            entity.Property(e => e.NrExercicio).HasColumnName("NR_EXERCICIO");
            entity.Property(e => e.NrExpediente)
                .HasMaxLength(10)
                .HasColumnName("NR_EXPEDIENTE");
            entity.Property(e => e.ObsAssinatura)
                .HasMaxLength(1000)
                .HasColumnName("OBS_ASSINATURA");
            entity.Property(e => e.OrndenadorDespesas).HasColumnName("ORNDENADOR_DESPESAS");
            entity.Property(e => e.TipoAmparo)
                .HasMaxLength(128)
                .HasColumnName("TIPO_AMPARO");
            entity.Property(e => e.TipoExpediente)
                .HasMaxLength(128)
                .HasColumnName("TIPO_EXPEDIENTE");
            entity.Property(e => e.TipoRelacao)
                .HasMaxLength(128)
                .HasColumnName("TIPO_RELACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.CdTipoCargoNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.CdTipoCargo)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_TIPO_CARGO_CD_TIPO_CARGO");

            entity.HasOne(d => d.FormaIngressoNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.FormaIngresso)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_FORMA_INGRESSO_SERVICO_PUBLICO_FORMA_INGRESSO");

            entity.HasOne(d => d.IdAgentePublicoNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.IdAgentePublico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_AGENTE_PUBLICO_ID_AGENTE_PUBLICO");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.IdOrgao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdUnidadeGestoraNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_UNIDADE_GESTORA_ID_UNIDADE_GESTORA");

            entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_UNIDADE_ORCAMENTARIA_ID_UNIDADE_ORCAMENTARIA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");

            entity.HasOne(d => d.TipoAmparoNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.TipoAmparo)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_TIPO_AMPARO_LEGAL_EXPEDIENTE_NOMEACAO_TIPO_AMPARO");

            entity.HasOne(d => d.TipoExpedienteNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.TipoExpediente)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_TIPO_EXPEDIENTE_NOMEACAO_TIPO_EXPEDIENTE");

            entity.HasOne(d => d.TipoRelacaoNavigation).WithMany(p => p.TabAssinaturas)
                .HasForeignKey(d => d.TipoRelacao)
                .HasConstraintName("FK_dbo.TAB_ASSINATURA_dbo.TAB_TIPO_RELACAO_SERVICO_PUBLICO_TIPO_RELACAO");
        });

        modelBuilder.Entity<TabAtendimento>(entity =>
        {
            entity.HasKey(e => e.IdAtendimento).HasName("PK_dbo.TAB_ATENDIMENTO");

            entity.ToTable("TAB_ATENDIMENTO");

            entity.HasIndex(e => e.IdAssinatura, "IX_ID_ASSINATURA");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdResponsavelEscritorio, "IX_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasIndex(e => e.IdUnidadeGestora, "IX_ID_UNIDADE_GESTORA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdAtendimento).HasColumnName("ID_ATENDIMENTO");
            entity.Property(e => e.DataAtendimento)
                .HasColumnType("datetime")
                .HasColumnName("DATA_ATENDIMENTO");
            entity.Property(e => e.DsCanalAtendimento)
                .HasMaxLength(100)
                .HasColumnName("DS_CANAL_ATENDIMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("EMAIL");
            entity.Property(e => e.HorarioAtendimento).HasColumnName("HORARIO_ATENDIMENTO");
            entity.Property(e => e.IdAssinatura).HasColumnName("ID_ASSINATURA");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdResponsavelEscritorio).HasColumnName("ID_RESPONSAVEL_ESCRITORIO");
            entity.Property(e => e.IdUnidadeGestora).HasColumnName("ID_UNIDADE_GESTORA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmFuncaoPessoaIndicada)
                .HasMaxLength(100)
                .HasColumnName("NM_FUNCAO_PESSOA_INDICADA");
            entity.Property(e => e.NmPessoaIndicada)
                .HasMaxLength(100)
                .HasColumnName("NM_PESSOA_INDICADA");
            entity.Property(e => e.NrCnpj)
                .HasMaxLength(14)
                .HasColumnName("NR_CNPJ");
            entity.Property(e => e.NrCpf)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF");
            entity.Property(e => e.NrTelefoneContato)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_CONTATO");
            entity.Property(e => e.Observacao)
                .HasMaxLength(4000)
                .HasColumnName("OBSERVACAO");
            entity.Property(e => e.TpAtendimentoEntidadeAdministrativa).HasColumnName("TP_ATENDIMENTO_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.TpAtendimentoEntidadeAdministrativaCliente).HasColumnName("TP_ATENDIMENTO_ENTIDADE_ADMINISTRATIVA_CLIENTE");
            entity.Property(e => e.TpCanalAtendimento).HasColumnName("TP_CANAL_ATENDIMENTO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdAssinaturaNavigation).WithMany(p => p.TabAtendimentos)
                .HasForeignKey(d => d.IdAssinatura)
                .HasConstraintName("FK_dbo.TAB_ATENDIMENTO_dbo.TAB_ASSINATURA_ID_ASSINATURA");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabAtendimentos)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .HasConstraintName("FK_dbo.TAB_ATENDIMENTO_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabAtendimentos)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ATENDIMENTO_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabAtendimentos)
                .HasForeignKey(d => d.IdOrgao)
                .HasConstraintName("FK_dbo.TAB_ATENDIMENTO_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdResponsavelEscritorioNavigation).WithMany(p => p.TabAtendimentos)
                .HasForeignKey(d => d.IdResponsavelEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ATENDIMENTO_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasOne(d => d.IdUnidadeGestoraNavigation).WithMany(p => p.TabAtendimentos)
                .HasForeignKey(d => d.IdUnidadeGestora)
                .HasConstraintName("FK_dbo.TAB_ATENDIMENTO_dbo.TAB_UNIDADE_GESTORA_ID_UNIDADE_GESTORA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabAtendimentos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_ATENDIMENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_dbo.TAB_CLIENTE");

            entity.ToTable("TAB_CLIENTE");

            entity.HasIndex(e => e.IdControladora, "IX_ID_CONTROLADORA");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdPessoa, "IX_ID_PESSOA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.HasIndex(e => e.IdUsuarioSistema, "IX_ID_USUARIO_SISTEMA");

            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdControladora).HasColumnName("ID_CONTROLADORA");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.IdUsuarioSistema).HasColumnName("ID_USUARIO_SISTEMA");
            entity.Property(e => e.TpCliente).HasColumnName("TP_CLIENTE");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControladoraNavigation).WithMany(p => p.TabClientes)
                .HasForeignKey(d => d.IdControladora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CLIENTE_dbo.TAB_CONTROLADORA_ID_CONTROLADORA");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabClientes)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CLIENTE_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.TabClientes)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CLIENTE_dbo.TAB_PESSOA_ID_PESSOA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabClienteIdUsuarioAtualizacaoNavigations)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CLIENTE_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");

            entity.HasOne(d => d.IdUsuarioSistemaNavigation).WithMany(p => p.TabClienteIdUsuarioSistemaNavigations)
                .HasForeignKey(d => d.IdUsuarioSistema)
                .HasConstraintName("FK_dbo.TAB_CLIENTE_dbo.TAB_USUARIO_ID_USUARIO_SISTEMA");
        });

        modelBuilder.Entity<TabClienteDocumento>(entity =>
        {
            entity.HasKey(e => e.IdClienteDocumento).HasName("PK_dbo.TAB_CLIENTE_DOCUMENTO");

            entity.ToTable("TAB_CLIENTE_DOCUMENTO");

            entity.HasIndex(e => e.IdCliente, "IX_ID_CLIENTE");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdClienteDocumento).HasColumnName("ID_CLIENTE_DOCUMENTO");
            entity.Property(e => e.CaminhoCompletoDocumento)
                .HasMaxLength(255)
                .HasColumnName("CAMINHO_COMPLETO_DOCUMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmDocumento)
                .HasMaxLength(100)
                .HasColumnName("NM_DOCUMENTO");
            entity.Property(e => e.TpDocumento).HasColumnName("TP_DOCUMENTO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TabClienteDocumentos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CLIENTE_DOCUMENTO_dbo.TAB_CLIENTE_ID_CLIENTE");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabClienteDocumentos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CLIENTE_DOCUMENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabConcessaoItensRemuneratorio>(entity =>
        {
            entity.HasKey(e => e.IdConcessaoItens).HasName("PK_dbo.TAB_CONCESSAO_ITENS_REMUNERATORIOS");

            entity.ToTable("TAB_CONCESSAO_ITENS_REMUNERATORIOS");

            entity.HasIndex(e => e.FmIngressoServicoPublico, "IX_FM_INGRESSO_SERVICO_PUBLICO");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdUnidadeOrcamentaria, "IX_ID_UNIDADE_ORCAMENTARIA");

            entity.HasIndex(e => e.TpRelacaoServicoPublico, "IX_TP_RELACAO_SERVICO_PUBLICO");

            entity.Property(e => e.IdConcessaoItens).HasColumnName("ID_CONCESSAO_ITENS");
            entity.Property(e => e.CdItem).HasColumnName("CD_ITEM");
            entity.Property(e => e.DtExpedienteConcessao)
                .HasColumnType("datetime")
                .HasColumnName("DT_EXPEDIENTE_CONCESSAO");
            entity.Property(e => e.DtPublicacaoExpediente)
                .HasColumnType("datetime")
                .HasColumnName("DT_PUBLICACAO_EXPEDIENTE");
            entity.Property(e => e.DtReferenciaDocumentacao).HasColumnName("DT_REFERENCIA_DOCUMENTACAO");
            entity.Property(e => e.ExercicioOrcamento).HasColumnName("EXERCICIO_ORCAMENTO");
            entity.Property(e => e.FmIngressoServicoPublico)
                .HasMaxLength(128)
                .HasColumnName("FM_INGRESSO_SERVICO_PUBLICO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.NrCpfAgentePublico)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF_AGENTE_PUBLICO");
            entity.Property(e => e.NrExpedienteConcessao)
                .HasMaxLength(10)
                .HasColumnName("NR_EXPEDIENTE_CONCESSAO");
            entity.Property(e => e.NrExpedienteNomeacaoPosse)
                .HasMaxLength(10)
                .HasColumnName("NR_EXPEDIENTE_NOMEACAO_POSSE");
            entity.Property(e => e.TpExpedienteConcessao)
                .HasMaxLength(1)
                .HasColumnName("TP_EXPEDIENTE_CONCESSAO");
            entity.Property(e => e.TpRelacaoServicoPublico)
                .HasMaxLength(128)
                .HasColumnName("TP_RELACAO_SERVICO_PUBLICO");

            entity.HasOne(d => d.FmIngressoServicoPublicoNavigation).WithMany(p => p.TabConcessaoItensRemuneratorios)
                .HasForeignKey(d => d.FmIngressoServicoPublico)
                .HasConstraintName("FK_dbo.TAB_CONCESSAO_ITENS_REMUNERATORIOS_dbo.TAB_FORMA_INGRESSO_SERVICO_PUBLICO_FM_INGRESSO_SERVICO_PUBLICO");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabConcessaoItensRemuneratorios)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONCESSAO_ITENS_REMUNERATORIOS_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabConcessaoItensRemuneratorios)
                .HasForeignKey(d => d.IdOrgao)
                .HasConstraintName("FK_dbo.TAB_CONCESSAO_ITENS_REMUNERATORIOS_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation).WithMany(p => p.TabConcessaoItensRemuneratorios)
                .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                .HasConstraintName("FK_dbo.TAB_CONCESSAO_ITENS_REMUNERATORIOS_dbo.TAB_UNIDADE_ORCAMENTARIA_ID_UNIDADE_ORCAMENTARIA");

            entity.HasOne(d => d.TpRelacaoServicoPublicoNavigation).WithMany(p => p.TabConcessaoItensRemuneratorios)
                .HasForeignKey(d => d.TpRelacaoServicoPublico)
                .HasConstraintName("FK_dbo.TAB_CONCESSAO_ITENS_REMUNERATORIOS_dbo.TAB_TIPO_RELACAO_SERVICO_PUBLICO_TP_RELACAO_SERVICO_PUBLICO");
        });

        modelBuilder.Entity<TabContaBancarium>(entity =>
        {
            entity.HasKey(e => e.IdConta).HasName("PK_dbo.TAB_CONTA_BANCARIA");

            entity.ToTable("TAB_CONTA_BANCARIA");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdUnidadeOrcamentaria, "IX_ID_UNIDADE_ORCAMENTARIA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdConta).HasColumnName("ID_CONTA");
            entity.Property(e => e.DtAbertura)
                .HasColumnType("datetime")
                .HasColumnName("DT_ABERTURA");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtRefDocumentacao).HasColumnName("DT_REF_DOCUMENTACAO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NrAgencia)
                .HasMaxLength(6)
                .HasColumnName("NR_AGENCIA");
            entity.Property(e => e.NrBanco)
                .HasMaxLength(4)
                .HasColumnName("NR_BANCO");
            entity.Property(e => e.NrConta)
                .HasMaxLength(10)
                .HasColumnName("NR_CONTA");
            entity.Property(e => e.NrExercicio).HasColumnName("NR_EXERCICIO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabContaBancaria)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTA_BANCARIA_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabContaBancaria)
                .HasForeignKey(d => d.IdOrgao)
                .HasConstraintName("FK_dbo.TAB_CONTA_BANCARIA_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation).WithMany(p => p.TabContaBancaria)
                .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                .HasConstraintName("FK_dbo.TAB_CONTA_BANCARIA_dbo.TAB_UNIDADE_ORCAMENTARIA_ID_UNIDADE_ORCAMENTARIA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabContaBancaria)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTA_BANCARIA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControladora>(entity =>
        {
            entity.HasKey(e => e.IdControladora).HasName("PK_dbo.TAB_CONTROLADORA");

            entity.ToTable("TAB_CONTROLADORA");

            entity.HasIndex(e => e.IdMantenedora, "IX_ID_MANTENEDORA");

            entity.HasIndex(e => e.IdMunicipio, "IX_ID_MUNICIPIO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControladora).HasColumnName("ID_CONTROLADORA");
            entity.Property(e => e.Complemento)
                .HasMaxLength(300)
                .HasColumnName("COMPLEMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdMantenedora).HasColumnName("ID_MANTENEDORA");
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmBairro)
                .HasMaxLength(80)
                .HasColumnName("NM_BAIRRO");
            entity.Property(e => e.NmFantasia)
                .HasMaxLength(100)
                .HasColumnName("NM_FANTASIA");
            entity.Property(e => e.NmLogradouro)
                .HasMaxLength(125)
                .HasColumnName("NM_LOGRADOURO");
            entity.Property(e => e.NmRazaoSocial)
                .HasMaxLength(255)
                .HasColumnName("NM_RAZAO_SOCIAL");
            entity.Property(e => e.NrCep)
                .HasMaxLength(16)
                .HasColumnName("NR_CEP");
            entity.Property(e => e.NrCnpj)
                .HasMaxLength(14)
                .HasColumnName("NR_CNPJ");
            entity.Property(e => e.NrCpf)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF");
            entity.Property(e => e.NrLogradouro).HasColumnName("NR_LOGRADOURO");
            entity.Property(e => e.NrTelefoneContato)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_CONTATO");
            entity.Property(e => e.NrTelefoneOutro)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_OUTRO");
            entity.Property(e => e.TpLogradouro).HasColumnName("TP_LOGRADOURO");
            entity.Property(e => e.TpPessoa).HasColumnName("TP_PESSOA");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpZona).HasColumnName("TP_ZONA");

            entity.HasOne(d => d.IdMantenedoraNavigation).WithMany(p => p.TabControladoras)
                .HasForeignKey(d => d.IdMantenedora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLADORA_dbo.TAB_MANTENEDORA_ID_MANTENEDORA");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.TabControladoras)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLADORA_dbo.TAB_MUNICIPIO_ID_MUNICIPIO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControladoras)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLADORA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleNotificacao>(entity =>
        {
            entity.HasKey(e => e.IdControleNotificacao).HasName("PK_dbo.TAB_CONTROLE_NOTIFICACAO");

            entity.ToTable("TAB_CONTROLE_NOTIFICACAO");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdResponsavelEscritorio, "IX_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasIndex(e => e.IdUnidadeGestora, "IX_ID_UNIDADE_GESTORA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleNotificacao).HasColumnName("ID_CONTROLE_NOTIFICACAO");
            entity.Property(e => e.ControleId).HasColumnName("CONTROLE_ID");
            entity.Property(e => e.DsControleNotificacao)
                .HasMaxLength(4000)
                .HasColumnName("DS_CONTROLE_NOTIFICACAO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtColetaTransmissao)
                .HasColumnType("datetime")
                .HasColumnName("DT_COLETA_TRANSMISSAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtNotificacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_NOTIFICACAO");
            entity.Property(e => e.DtTransmissao)
                .HasColumnType("datetime")
                .HasColumnName("DT_TRANSMISSAO");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdResponsavelEscritorio).HasColumnName("ID_RESPONSAVEL_ESCRITORIO");
            entity.Property(e => e.IdUnidadeGestora).HasColumnName("ID_UNIDADE_GESTORA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.RealizarNotificacao).HasColumnName("REALIZAR_NOTIFICACAO");
            entity.Property(e => e.SituacaoControleNotificacao).HasColumnName("SITUACAO_CONTROLE_NOTIFICACAO");
            entity.Property(e => e.TituloNotificacao)
                .HasMaxLength(255)
                .HasColumnName("TITULO_NOTIFICACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabControleNotificacaos)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdResponsavelEscritorioNavigation).WithMany(p => p.TabControleNotificacaos)
                .HasForeignKey(d => d.IdResponsavelEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasOne(d => d.IdUnidadeGestoraNavigation).WithMany(p => p.TabControleNotificacaos)
                .HasForeignKey(d => d.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_dbo.TAB_UNIDADE_GESTORA_ID_UNIDADE_GESTORA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleNotificacaos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleNotificacaoAssinatura>(entity =>
        {
            entity.HasKey(e => e.IdControleNotificacaoAssinatura).HasName("PK_dbo.TAB_CONTROLE_NOTIFICACAO_ASSINATURA");

            entity.ToTable("TAB_CONTROLE_NOTIFICACAO_ASSINATURA");

            entity.HasIndex(e => e.IdAssinatura, "IX_ID_ASSINATURA");

            entity.HasIndex(e => e.IdControleNotificacao, "IX_ID_CONTROLE_NOTIFICACAO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleNotificacaoAssinatura).HasColumnName("ID_CONTROLE_NOTIFICACAO_ASSINATURA");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdAssinatura).HasColumnName("ID_ASSINATURA");
            entity.Property(e => e.IdControleNotificacao).HasColumnName("ID_CONTROLE_NOTIFICACAO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdAssinaturaNavigation).WithMany(p => p.TabControleNotificacaoAssinaturas)
                .HasForeignKey(d => d.IdAssinatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_ASSINATURA_dbo.TAB_ASSINATURA_ID_ASSINATURA");

            entity.HasOne(d => d.IdControleNotificacaoNavigation).WithMany(p => p.TabControleNotificacaoAssinaturas)
                .HasForeignKey(d => d.IdControleNotificacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_ASSINATURA_dbo.TAB_CONTROLE_NOTIFICACAO_ID_CONTROLE_NOTIFICACAO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleNotificacaoAssinaturas)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_ASSINATURA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleNotificacaoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdControleNotificacaoDocumento).HasName("PK_dbo.TAB_CONTROLE_NOTIFICACAO_DOCUMENTO");

            entity.ToTable("TAB_CONTROLE_NOTIFICACAO_DOCUMENTO");

            entity.HasIndex(e => e.IdControleNotificacao, "IX_ID_CONTROLE_NOTIFICACAO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleNotificacaoDocumento).HasColumnName("ID_CONTROLE_NOTIFICACAO_DOCUMENTO");
            entity.Property(e => e.CaminhoCompletoDocumento)
                .HasMaxLength(255)
                .HasColumnName("CAMINHO_COMPLETO_DOCUMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdControleNotificacao).HasColumnName("ID_CONTROLE_NOTIFICACAO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmDocumento)
                .HasMaxLength(255)
                .HasColumnName("NM_DOCUMENTO");
            entity.Property(e => e.TpDocumento).HasColumnName("TP_DOCUMENTO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControleNotificacaoNavigation).WithMany(p => p.TabControleNotificacaoDocumentos)
                .HasForeignKey(d => d.IdControleNotificacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_DOCUMENTO_dbo.TAB_CONTROLE_NOTIFICACAO_ID_CONTROLE_NOTIFICACAO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleNotificacaoDocumentos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_DOCUMENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleNotificacaoEvento>(entity =>
        {
            entity.HasKey(e => e.IdControleNotificacaoEvento).HasName("PK_dbo.TAB_CONTROLE_NOTIFICACAO_EVENTO");

            entity.ToTable("TAB_CONTROLE_NOTIFICACAO_EVENTO");

            entity.HasIndex(e => e.IdControleNotificacao, "IX_ID_CONTROLE_NOTIFICACAO");

            entity.HasIndex(e => e.IdControleNotificacaoAssinatura, "IX_ID_CONTROLE_NOTIFICACAO_ASSINATURA");

            entity.HasIndex(e => e.IdControleNotificacaoDocumento, "IX_ID_CONTROLE_NOTIFICACAO_DOCUMENTO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleNotificacaoEvento).HasColumnName("ID_CONTROLE_NOTIFICACAO_EVENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtEvento)
                .HasColumnType("datetime")
                .HasColumnName("DT_EVENTO");
            entity.Property(e => e.IdControleNotificacao).HasColumnName("ID_CONTROLE_NOTIFICACAO");
            entity.Property(e => e.IdControleNotificacaoAssinatura).HasColumnName("ID_CONTROLE_NOTIFICACAO_ASSINATURA");
            entity.Property(e => e.IdControleNotificacaoDocumento).HasColumnName("ID_CONTROLE_NOTIFICACAO_DOCUMENTO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.TpControleNotificacaoEvento).HasColumnName("TP_CONTROLE_NOTIFICACAO_EVENTO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControleNotificacaoNavigation).WithMany(p => p.TabControleNotificacaoEventos)
                .HasForeignKey(d => d.IdControleNotificacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_EVENTO_dbo.TAB_CONTROLE_NOTIFICACAO_ID_CONTROLE_NOTIFICACAO");

            entity.HasOne(d => d.IdControleNotificacaoAssinaturaNavigation).WithMany(p => p.TabControleNotificacaoEventos)
                .HasForeignKey(d => d.IdControleNotificacaoAssinatura)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_EVENTO_dbo.TAB_CONTROLE_NOTIFICACAO_ASSINATURA_ID_CONTROLE_NOTIFICACAO_ASSINATURA");

            entity.HasOne(d => d.IdControleNotificacaoDocumentoNavigation).WithMany(p => p.TabControleNotificacaoEventos)
                .HasForeignKey(d => d.IdControleNotificacaoDocumento)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_EVENTO_dbo.TAB_CONTROLE_NOTIFICACAO_DOCUMENTO_ID_CONTROLE_NOTIFICACAO_DOCUMENTO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleNotificacaoEventos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_NOTIFICACAO_EVENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleProcesso>(entity =>
        {
            entity.HasKey(e => e.IdControleProcesso).HasName("PK_dbo.TAB_CONTROLE_PROCESSO");

            entity.ToTable("TAB_CONTROLE_PROCESSO");

            entity.HasIndex(e => e.IdAssinatura, "IX_ID_ASSINATURA");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdResponsavelEscritorio, "IX_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasIndex(e => e.IdUnidadeGestora, "IX_ID_UNIDADE_GESTORA");

            entity.HasIndex(e => e.IdUnidadeOrcamentaria, "IX_ID_UNIDADE_ORCAMENTARIA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleProcesso).HasColumnName("ID_CONTROLE_PROCESSO");
            entity.Property(e => e.DataPrazo)
                .HasColumnType("datetime")
                .HasColumnName("DATA_PRAZO");
            entity.Property(e => e.DataPublicacaoDoe)
                .HasColumnType("datetime")
                .HasColumnName("DATA_PUBLICACAO_DOE");
            entity.Property(e => e.DsControleProcesso)
                .HasMaxLength(4000)
                .HasColumnName("DS_CONTROLE_PROCESSO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdAssinatura).HasColumnName("ID_ASSINATURA");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdResponsavelEscritorio).HasColumnName("ID_RESPONSAVEL_ESCRITORIO");
            entity.Property(e => e.IdUnidadeGestora).HasColumnName("ID_UNIDADE_GESTORA");
            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NrExercicio).HasColumnName("NR_EXERCICIO");
            entity.Property(e => e.NumeroProcesso).HasColumnName("NUMERO_PROCESSO");
            entity.Property(e => e.TpConta).HasColumnName("TP_CONTA");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdAssinaturaNavigation).WithMany(p => p.TabControleProcessos)
                .HasForeignKey(d => d.IdAssinatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_dbo.TAB_ASSINATURA_ID_ASSINATURA");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabControleProcessos)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdResponsavelEscritorioNavigation).WithMany(p => p.TabControleProcessos)
                .HasForeignKey(d => d.IdResponsavelEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasOne(d => d.IdUnidadeGestoraNavigation).WithMany(p => p.TabControleProcessos)
                .HasForeignKey(d => d.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_dbo.TAB_UNIDADE_GESTORA_ID_UNIDADE_GESTORA");

            entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation).WithMany(p => p.TabControleProcessos)
                .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_dbo.TAB_UNIDADE_ORCAMENTARIA_ID_UNIDADE_ORCAMENTARIA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleProcessos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleProcessoAcao>(entity =>
        {
            entity.HasKey(e => e.IdControleProcessoAcao).HasName("PK_dbo.TAB_CONTROLE_PROCESSO_ACAO");

            entity.ToTable("TAB_CONTROLE_PROCESSO_ACAO");

            entity.HasIndex(e => e.IdControleProcesso, "IX_ID_CONTROLE_PROCESSO");

            entity.HasIndex(e => e.IdResponsavelEscritorioAcao, "IX_ID_RESPONSAVEL_ESCRITORIO_ACAO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleProcessoAcao).HasColumnName("ID_CONTROLE_PROCESSO_ACAO");
            entity.Property(e => e.DsControleProcessoAcao)
                .HasMaxLength(1000)
                .HasColumnName("DS_CONTROLE_PROCESSO_ACAO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtFimAcao)
                .HasColumnType("datetime")
                .HasColumnName("DT_FIM_ACAO");
            entity.Property(e => e.DtInicioAcao)
                .HasColumnType("datetime")
                .HasColumnName("DT_INICIO_ACAO");
            entity.Property(e => e.DtPrevisaoFim)
                .HasColumnType("datetime")
                .HasColumnName("DT_PREVISAO_FIM");
            entity.Property(e => e.IdControleProcesso).HasColumnName("ID_CONTROLE_PROCESSO");
            entity.Property(e => e.IdResponsavelEscritorioAcao).HasColumnName("ID_RESPONSAVEL_ESCRITORIO_ACAO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.TpSituacaoAcao).HasColumnName("TP_SITUACAO_ACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControleProcessoNavigation).WithMany(p => p.TabControleProcessoAcaos)
                .HasForeignKey(d => d.IdControleProcesso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_ACAO_dbo.TAB_CONTROLE_PROCESSO_ID_CONTROLE_PROCESSO");

            entity.HasOne(d => d.IdResponsavelEscritorioAcaoNavigation).WithMany(p => p.TabControleProcessoAcaos)
                .HasForeignKey(d => d.IdResponsavelEscritorioAcao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_ACAO_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO_ACAO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleProcessoAcaos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_ACAO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleProcessoAcaoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdControleProcessoAcaoDocumento).HasName("PK_dbo.TAB_CONTROLE_PROCESSO_ACAO_DOCUMENTO");

            entity.ToTable("TAB_CONTROLE_PROCESSO_ACAO_DOCUMENTO");

            entity.HasIndex(e => e.IdControleProcessoAcao, "IX_ID_CONTROLE_PROCESSO_ACAO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleProcessoAcaoDocumento).HasColumnName("ID_CONTROLE_PROCESSO_ACAO_DOCUMENTO");
            entity.Property(e => e.CaminhoCompletoDocumento)
                .HasMaxLength(255)
                .HasColumnName("CAMINHO_COMPLETO_DOCUMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdControleProcessoAcao).HasColumnName("ID_CONTROLE_PROCESSO_ACAO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmDocumento)
                .HasMaxLength(100)
                .HasColumnName("NM_DOCUMENTO");
            entity.Property(e => e.TpDocumento).HasColumnName("TP_DOCUMENTO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControleProcessoAcaoNavigation).WithMany(p => p.TabControleProcessoAcaoDocumentos)
                .HasForeignKey(d => d.IdControleProcessoAcao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_ACAO_DOCUMENTO_dbo.TAB_CONTROLE_PROCESSO_ACAO_ID_CONTROLE_PROCESSO_ACAO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleProcessoAcaoDocumentos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_ACAO_DOCUMENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleProcessoTramitacao>(entity =>
        {
            entity.HasKey(e => e.IdControleProcessoTramitacao).HasName("PK_dbo.TAB_CONTROLE_PROCESSO_TRAMITACAO");

            entity.ToTable("TAB_CONTROLE_PROCESSO_TRAMITACAO");

            entity.HasIndex(e => e.IdControleProcesso, "IX_ID_CONTROLE_PROCESSO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleProcessoTramitacao).HasColumnName("ID_CONTROLE_PROCESSO_TRAMITACAO");
            entity.Property(e => e.DsFinalidade)
                .HasMaxLength(1000)
                .HasColumnName("DS_FINALIDADE");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtTramitacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_TRAMITACAO");
            entity.Property(e => e.IdControleProcesso).HasColumnName("ID_CONTROLE_PROCESSO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControleProcessoNavigation).WithMany(p => p.TabControleProcessoTramitacaos)
                .HasForeignKey(d => d.IdControleProcesso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_TRAMITACAO_dbo.TAB_CONTROLE_PROCESSO_ID_CONTROLE_PROCESSO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleProcessoTramitacaos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_PROCESSO_TRAMITACAO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleViagem>(entity =>
        {
            entity.HasKey(e => e.IdControleViagem).HasName("PK_dbo.TAB_CONTROLE_VIAGEM");

            entity.ToTable("TAB_CONTROLE_VIAGEM");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdResponsavelEscritorio, "IX_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleViagem).HasColumnName("ID_CONTROLE_VIAGEM");
            entity.Property(e => e.DataViagem)
                .HasColumnType("datetime")
                .HasColumnName("DATA_VIAGEM");
            entity.Property(e => e.DsViagem)
                .HasMaxLength(4000)
                .HasColumnName("DS_VIAGEM");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdResponsavelEscritorio).HasColumnName("ID_RESPONSAVEL_ESCRITORIO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.Objetivo)
                .HasMaxLength(255)
                .HasColumnName("OBJETIVO");
            entity.Property(e => e.SituacaoViagem).HasColumnName("SITUACAO_VIAGEM");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabControleViagems)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_VIAGEM_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabControleViagems)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_VIAGEM_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdResponsavelEscritorioNavigation).WithMany(p => p.TabControleViagems)
                .HasForeignKey(d => d.IdResponsavelEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_VIAGEM_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleViagems)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_VIAGEM_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabControleViagemDocumento>(entity =>
        {
            entity.HasKey(e => e.IdControleViagemDocumento).HasName("PK_dbo.TAB_CONTROLE_VIAGEM_DOCUMENTO");

            entity.ToTable("TAB_CONTROLE_VIAGEM_DOCUMENTO");

            entity.HasIndex(e => e.IdControleViagem, "IX_ID_CONTROLE_VIAGEM");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdControleViagemDocumento).HasColumnName("ID_CONTROLE_VIAGEM_DOCUMENTO");
            entity.Property(e => e.CaminhoCompletoDocumento)
                .HasMaxLength(255)
                .HasColumnName("CAMINHO_COMPLETO_DOCUMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdControleViagem).HasColumnName("ID_CONTROLE_VIAGEM");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmDocumento)
                .HasMaxLength(255)
                .HasColumnName("NM_DOCUMENTO");
            entity.Property(e => e.TpDocumento).HasColumnName("TP_DOCUMENTO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControleViagemNavigation).WithMany(p => p.TabControleViagemDocumentos)
                .HasForeignKey(d => d.IdControleViagem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_VIAGEM_DOCUMENTO_dbo.TAB_CONTROLE_VIAGEM_ID_CONTROLE_VIAGEM");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabControleViagemDocumentos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_CONTROLE_VIAGEM_DOCUMENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabDesligamentoAgentePublico>(entity =>
        {
            entity.HasKey(e => e.IdDesligamentoAgentePublico).HasName("PK_dbo.TAB_DESLIGAMENTO_AGENTE_PUBLICO");

            entity.ToTable("TAB_DESLIGAMENTO_AGENTE_PUBLICO");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdFormaIngressoServicoPublico, "IX_ID_FORMA_INGRESSO_SERVICO_PUBLICO");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdTipoRelacaoServicoPublico, "IX_ID_TIPO_RELACAO_SERVICO_PUBLICO");

            entity.HasIndex(e => e.IdUnidadeOrcamentaria, "IX_ID_UNIDADE_ORCAMENTARIA");

            entity.Property(e => e.IdDesligamentoAgentePublico).HasColumnName("ID_DESLIGAMENTO_AGENTE_PUBLICO");
            entity.Property(e => e.DtExpedienteDesligamento)
                .HasColumnType("datetime")
                .HasColumnName("DT_EXPEDIENTE_DESLIGAMENTO");
            entity.Property(e => e.DtPublicacaoExpedienteDesligamento)
                .HasColumnType("datetime")
                .HasColumnName("DT_PUBLICACAO_EXPEDIENTE_DESLIGAMENTO");
            entity.Property(e => e.DtReferenciaDocumentacao).HasColumnName("DT_REFERENCIA_DOCUMENTACAO");
            entity.Property(e => e.EnderecoCompleto)
                .HasMaxLength(255)
                .HasColumnName("ENDERECO_COMPLETO");
            entity.Property(e => e.ExercicioOrcamento).HasColumnName("EXERCICIO_ORCAMENTO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdFormaIngressoServicoPublico)
                .HasMaxLength(128)
                .HasColumnName("ID_FORMA_INGRESSO_SERVICO_PUBLICO");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdTipoRelacaoServicoPublico)
                .HasMaxLength(128)
                .HasColumnName("ID_TIPO_RELACAO_SERVICO_PUBLICO");
            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.NmPensionista)
                .HasMaxLength(40)
                .HasColumnName("NM_PENSIONISTA");
            entity.Property(e => e.NrCpfAgentePublic)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF_AGENTE_PUBLIC");
            entity.Property(e => e.NrCpfPensionista)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF_PENSIONISTA");
            entity.Property(e => e.NrExpedienteDesligamento)
                .HasMaxLength(10)
                .HasColumnName("NR_EXPEDIENTE_DESLIGAMENTO");
            entity.Property(e => e.NrExpedienteNomeacaoPosse)
                .HasMaxLength(10)
                .HasColumnName("NR_EXPEDIENTE_NOMEACAO_POSSE");
            entity.Property(e => e.TlPensionista)
                .HasMaxLength(11)
                .HasColumnName("TL_PENSIONISTA");
            entity.Property(e => e.TpDesligamento).HasColumnName("TP_DESLIGAMENTO");
            entity.Property(e => e.TpExpedienteDesligamento)
                .HasMaxLength(1)
                .HasColumnName("TP_EXPEDIENTE_DESLIGAMENTO");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabDesligamentoAgentePublicos)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .HasConstraintName("FK_dbo.TAB_DESLIGAMENTO_AGENTE_PUBLICO_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdFormaIngressoServicoPublicoNavigation).WithMany(p => p.TabDesligamentoAgentePublicos)
                .HasForeignKey(d => d.IdFormaIngressoServicoPublico)
                .HasConstraintName("FK_dbo.TAB_DESLIGAMENTO_AGENTE_PUBLICO_dbo.TAB_FORMA_INGRESSO_SERVICO_PUBLICO_ID_FORMA_INGRESSO_SERVICO_PUBLICO");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabDesligamentoAgentePublicos)
                .HasForeignKey(d => d.IdOrgao)
                .HasConstraintName("FK_dbo.TAB_DESLIGAMENTO_AGENTE_PUBLICO_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdTipoRelacaoServicoPublicoNavigation).WithMany(p => p.TabDesligamentoAgentePublicos)
                .HasForeignKey(d => d.IdTipoRelacaoServicoPublico)
                .HasConstraintName("FK_dbo.TAB_DESLIGAMENTO_AGENTE_PUBLICO_dbo.TAB_TIPO_RELACAO_SERVICO_PUBLICO_ID_TIPO_RELACAO_SERVICO_PUBLICO");

            entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation).WithMany(p => p.TabDesligamentoAgentePublicos)
                .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                .HasConstraintName("FK_dbo.TAB_DESLIGAMENTO_AGENTE_PUBLICO_dbo.TAB_UNIDADE_ORCAMENTARIA_ID_UNIDADE_ORCAMENTARIA");
        });

        modelBuilder.Entity<TabEntidadeAdministrativa>(entity =>
        {
            entity.HasKey(e => e.IdEntidadeAdministrativa).HasName("PK_dbo.TAB_ENTIDADE_ADMINISTRATIVA");

            entity.ToTable("TAB_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdMunicipio, "IX_ID_MUNICIPIO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.CdEntidadeAdministrativa).HasColumnName("CD_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.Complemento)
                .HasMaxLength(300)
                .HasColumnName("COMPLEMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmBairro)
                .HasMaxLength(80)
                .HasColumnName("NM_BAIRRO");
            entity.Property(e => e.NmEntidadeAdministrativa)
                .HasMaxLength(100)
                .HasColumnName("NM_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.NmLogradouro)
                .HasMaxLength(125)
                .HasColumnName("NM_LOGRADOURO");
            entity.Property(e => e.NrCep)
                .HasMaxLength(16)
                .HasColumnName("NR_CEP");
            entity.Property(e => e.NrCnpjEntidadeAdministrativa)
                .HasMaxLength(100)
                .HasColumnName("NR_CNPJ_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.NrLogradouro).HasColumnName("NR_LOGRADOURO");
            entity.Property(e => e.NrTelefoneContato)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_CONTATO");
            entity.Property(e => e.NrTelefoneOutro)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_OUTRO");
            entity.Property(e => e.TpLogradouro).HasColumnName("TP_LOGRADOURO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpUnidadeAdministrativa).HasColumnName("TP_UNIDADE_ADMINISTRATIVA");
            entity.Property(e => e.TpZona).HasColumnName("TP_ZONA");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabEntidadeAdministrativas)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ENTIDADE_ADMINISTRATIVA_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.TabEntidadeAdministrativas)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ENTIDADE_ADMINISTRATIVA_dbo.TAB_MUNICIPIO_ID_MUNICIPIO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabEntidadeAdministrativas)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_ENTIDADE_ADMINISTRATIVA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabEscritorio>(entity =>
        {
            entity.HasKey(e => e.IdEscritorio).HasName("PK_dbo.TAB_ESCRITORIO");

            entity.ToTable("TAB_ESCRITORIO");

            entity.HasIndex(e => e.IdControladora, "IX_ID_CONTROLADORA");

            entity.HasIndex(e => e.IdMantenedora, "IX_ID_MANTENEDORA");

            entity.HasIndex(e => e.IdMunicipio, "IX_ID_MUNICIPIO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.Complemento)
                .HasMaxLength(300)
                .HasColumnName("COMPLEMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdControladora).HasColumnName("ID_CONTROLADORA");
            entity.Property(e => e.IdMantenedora).HasColumnName("ID_MANTENEDORA");
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.Logomarca).HasColumnName("LOGOMARCA");
            entity.Property(e => e.NmBairro)
                .HasMaxLength(80)
                .HasColumnName("NM_BAIRRO");
            entity.Property(e => e.NmEscritorioFantasia)
                .HasMaxLength(100)
                .HasColumnName("NM_ESCRITORIO_FANTASIA");
            entity.Property(e => e.NmEscritorioRazaoSocial)
                .HasMaxLength(100)
                .HasColumnName("NM_ESCRITORIO_RAZAO_SOCIAL");
            entity.Property(e => e.NmLogoEscritorio).HasColumnName("NM_LOGO_ESCRITORIO");
            entity.Property(e => e.NmLogradouro)
                .HasMaxLength(125)
                .HasColumnName("NM_LOGRADOURO");
            entity.Property(e => e.NrCep)
                .HasMaxLength(16)
                .HasColumnName("NR_CEP");
            entity.Property(e => e.NrCnpjEscritorio)
                .HasMaxLength(100)
                .HasColumnName("NR_CNPJ_ESCRITORIO");
            entity.Property(e => e.NrLogradouro).HasColumnName("NR_LOGRADOURO");
            entity.Property(e => e.NrTelefoneContato)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_CONTATO");
            entity.Property(e => e.NrTelefoneOutro)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_OUTRO");
            entity.Property(e => e.RodapeRelatorio)
                .HasMaxLength(300)
                .HasColumnName("RODAPE_RELATORIO");
            entity.Property(e => e.TpLogradouro).HasColumnName("TP_LOGRADOURO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpZona).HasColumnName("TP_ZONA");

            entity.HasOne(d => d.IdControladoraNavigation).WithMany(p => p.TabEscritorios)
                .HasForeignKey(d => d.IdControladora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ESCRITORIO_dbo.TAB_CONTROLADORA_ID_CONTROLADORA");

            entity.HasOne(d => d.IdMantenedoraNavigation).WithMany(p => p.TabEscritorios)
                .HasForeignKey(d => d.IdMantenedora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ESCRITORIO_dbo.TAB_MANTENEDORA_ID_MANTENEDORA");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.TabEscritorios)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ESCRITORIO_dbo.TAB_MUNICIPIO_ID_MUNICIPIO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabEscritorios)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_ESCRITORIO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabEstado>(entity =>
        {
            entity.HasKey(e => e.Uf).HasName("PK_dbo.TAB_ESTADO");

            entity.ToTable("TAB_ESTADO");

            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("UF");
            entity.Property(e => e.NmEstado)
                .HasMaxLength(60)
                .HasColumnName("NM_ESTADO");
        });

        modelBuilder.Entity<TabFormaIngressoServicoPublico>(entity =>
        {
            entity.HasKey(e => e.FormaIngresso).HasName("PK_dbo.TAB_FORMA_INGRESSO_SERVICO_PUBLICO");

            entity.ToTable("TAB_FORMA_INGRESSO_SERVICO_PUBLICO");

            entity.Property(e => e.FormaIngresso)
                .HasMaxLength(128)
                .HasColumnName("FORMA_INGRESSO");
            entity.Property(e => e.DsIngresso)
                .HasMaxLength(100)
                .HasColumnName("DS_INGRESSO");
        });

        modelBuilder.Entity<TabItemRemuneratorio>(entity =>
        {
            entity.HasKey(e => e.IdItemRemuneratorio).HasName("PK_dbo.TAB_ITEM_REMUNERATORIO");

            entity.ToTable("TAB_ITEM_REMUNERATORIO");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.Property(e => e.IdItemRemuneratorio).HasColumnName("ID_ITEM_REMUNERATORIO");
            entity.Property(e => e.CdItem).HasColumnName("CD_ITEM");
            entity.Property(e => e.ClassificacaoItem).HasColumnName("CLASSIFICACAO_ITEM");
            entity.Property(e => e.DsItem).HasColumnName("DS_ITEM");
            entity.Property(e => e.DtAmparoLegal)
                .HasColumnType("datetime")
                .HasColumnName("DT_AMPARO_LEGAL");
            entity.Property(e => e.DtNormaLegalRegItem)
                .HasColumnType("datetime")
                .HasColumnName("DT_NORMA_LEGAL_REG_ITEM ");
            entity.Property(e => e.DtPublicacaoAmparoLegal)
                .HasColumnType("datetime")
                .HasColumnName("DT_PUBLICACAO_AMPARO_LEGAL ");
            entity.Property(e => e.DtPublicacaoNormaLegalRegItem)
                .HasColumnType("datetime")
                .HasColumnName("DT_PUBLICACAO_NORMA_LEGAL_REG_ITEM");
            entity.Property(e => e.DtReferenciaDocumentacao).HasColumnName("DT_REFERENCIA_DOCUMENTACAO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.NrAmparoLegalOrigemItem).HasColumnName("NR_AMPARO_LEGAL_ORIGEM_ITEM");
            entity.Property(e => e.NrUltimaNormaLegalRegItem).HasColumnName("NR_ULTIMA_NORMA_LEGAL_REG_ITEM");
            entity.Property(e => e.TpAmparoLegalOrigemItem).HasColumnName("TP_AMPARO_LEGAL_ORIGEM_ITEM");
            entity.Property(e => e.TpItem).HasColumnName("TP_ITEM");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabItemRemuneratorios)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ITEM_REMUNERATORIO_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");
        });

        modelBuilder.Entity<TabMantenedora>(entity =>
        {
            entity.HasKey(e => e.IdMantenedora).HasName("PK_dbo.TAB_MANTENEDORA");

            entity.ToTable("TAB_MANTENEDORA");

            entity.HasIndex(e => e.IdMunicipio, "IX_ID_MUNICIPIO");

            entity.Property(e => e.IdMantenedora).HasColumnName("ID_MANTENEDORA");
            entity.Property(e => e.Complemento)
                .HasMaxLength(300)
                .HasColumnName("COMPLEMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");
            entity.Property(e => e.NmBairro)
                .HasMaxLength(80)
                .HasColumnName("NM_BAIRRO");
            entity.Property(e => e.NmFantasia)
                .HasMaxLength(100)
                .HasColumnName("NM_FANTASIA");
            entity.Property(e => e.NmLogradouro)
                .HasMaxLength(125)
                .HasColumnName("NM_LOGRADOURO");
            entity.Property(e => e.NmRazaoSocial)
                .HasMaxLength(255)
                .HasColumnName("NM_RAZAO_SOCIAL");
            entity.Property(e => e.NrCep)
                .HasMaxLength(16)
                .HasColumnName("NR_CEP");
            entity.Property(e => e.NrCnpj)
                .HasMaxLength(14)
                .HasColumnName("NR_CNPJ");
            entity.Property(e => e.NrLogradouro).HasColumnName("NR_LOGRADOURO");
            entity.Property(e => e.NrTelefoneContato)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_CONTATO");
            entity.Property(e => e.NrTelefoneOutro)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_OUTRO");
            entity.Property(e => e.TpLogradouro).HasColumnName("TP_LOGRADOURO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpZona).HasColumnName("TP_ZONA");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.TabMantenedoras)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_MANTENEDORA_dbo.TAB_MUNICIPIO_ID_MUNICIPIO");
        });

        modelBuilder.Entity<TabMembroSetor>(entity =>
        {
            entity.HasKey(e => e.IdMembroSetor).HasName("PK_dbo.TAB_MEMBRO_SETOR");

            entity.ToTable("TAB_MEMBRO_SETOR");

            entity.HasIndex(e => e.IdResponsavelEscritorio, "IX_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasIndex(e => e.IdSetor, "IX_ID_SETOR");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdMembroSetor).HasColumnName("ID_MEMBRO_SETOR");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdResponsavelEscritorio).HasColumnName("ID_RESPONSAVEL_ESCRITORIO");
            entity.Property(e => e.IdSetor).HasColumnName("ID_SETOR");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdResponsavelEscritorioNavigation).WithMany(p => p.TabMembroSetors)
                .HasForeignKey(d => d.IdResponsavelEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_MEMBRO_SETOR_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasOne(d => d.IdSetorNavigation).WithMany(p => p.TabMembroSetors)
                .HasForeignKey(d => d.IdSetor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_MEMBRO_SETOR_dbo.TAB_SETOR_ID_SETOR");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabMembroSetors)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_MEMBRO_SETOR_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabMonitoramento>(entity =>
        {
            entity.HasKey(e => e.IdMonitoramento).HasName("PK_dbo.TAB_MONITORAMENTO");

            entity.ToTable("TAB_MONITORAMENTO");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdMunicipio, "IX_ID_MUNICIPIO");

            entity.HasIndex(e => e.IdTribunal, "IX_ID_TRIBUNAL");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.HasIndex(e => e.Uf, "IX_UF");

            entity.Property(e => e.IdMonitoramento).HasColumnName("ID_MONITORAMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");
            entity.Property(e => e.IdTribunal).HasColumnName("ID_TRIBUNAL");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("UF");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabMonitoramentos)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_MONITORAMENTO_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.TabMonitoramentos)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_dbo.TAB_MONITORAMENTO_dbo.TAB_MUNICIPIO_ID_MUNICIPIO");

            entity.HasOne(d => d.IdTribunalNavigation).WithMany(p => p.TabMonitoramentos)
                .HasForeignKey(d => d.IdTribunal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_MONITORAMENTO_dbo.TAB_TRIBUNAL_ID_TRIBUNAL");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabMonitoramentos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_MONITORAMENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");

            entity.HasOne(d => d.UfNavigation).WithMany(p => p.TabMonitoramentos)
                .HasForeignKey(d => d.Uf)
                .HasConstraintName("FK_dbo.TAB_MONITORAMENTO_dbo.TAB_ESTADO_UF");
        });

        modelBuilder.Entity<TabMunicipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK_dbo.TAB_MUNICIPIO");

            entity.ToTable("TAB_MUNICIPIO");

            entity.HasIndex(e => e.Uf, "IX_UF");

            entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");
            entity.Property(e => e.CepMunicipio)
                .HasMaxLength(16)
                .HasColumnName("CEP_MUNICIPIO");
            entity.Property(e => e.CodigoIbge)
                .HasMaxLength(10)
                .HasColumnName("CODIGO_IBGE");
            entity.Property(e => e.CodigoTcm)
                .HasMaxLength(3)
                .HasColumnName("CODIGO_TCM");
            entity.Property(e => e.NmMunicipio)
                .HasMaxLength(60)
                .HasColumnName("NM_MUNICIPIO");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("UF");

            entity.HasOne(d => d.UfNavigation).WithMany(p => p.TabMunicipios)
                .HasForeignKey(d => d.Uf)
                .HasConstraintName("FK_dbo.TAB_MUNICIPIO_dbo.TAB_ESTADO_UF");
        });

        modelBuilder.Entity<TabNotificacao>(entity =>
        {
            entity.HasKey(e => e.IdNotificacao).HasName("PK_dbo.TAB_NOTIFICACAO");

            entity.ToTable("TAB_NOTIFICACAO");

            entity.HasIndex(e => e.IdAcao, "IX_ID_ACAO");

            entity.HasIndex(e => e.IdControleNotificacao, "IX_ID_CONTROLE_NOTIFICACAO");

            entity.HasIndex(e => e.IdControleNotificacaoAssinatura, "IX_ID_CONTROLE_NOTIFICACAO_ASSINATURA");

            entity.HasIndex(e => e.IdControleProcessoAcao, "IX_ID_CONTROLE_PROCESSO_ACAO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdNotificacao).HasColumnName("ID_NOTIFICACAO");
            entity.Property(e => e.ControleId).HasColumnName("CONTROLE_ID");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdAcao).HasColumnName("ID_ACAO");
            entity.Property(e => e.IdControleNotificacao).HasColumnName("ID_CONTROLE_NOTIFICACAO");
            entity.Property(e => e.IdControleNotificacaoAssinatura).HasColumnName("ID_CONTROLE_NOTIFICACAO_ASSINATURA");
            entity.Property(e => e.IdControleProcessoAcao).HasColumnName("ID_CONTROLE_PROCESSO_ACAO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NotificacaoId).HasColumnName("NOTIFICACAO_ID");
            entity.Property(e => e.TpNotificacao).HasColumnName("TP_NOTIFICACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpSituacaoNotificacao).HasColumnName("TP_SITUACAO_NOTIFICACAO");

            entity.HasOne(d => d.IdAcaoNavigation).WithMany(p => p.TabNotificacaos)
                .HasForeignKey(d => d.IdAcao)
                .HasConstraintName("FK_dbo.TAB_NOTIFICACAO_dbo.TAB_ACAO_ID_ACAO");

            entity.HasOne(d => d.IdControleNotificacaoNavigation).WithMany(p => p.TabNotificacaos)
                .HasForeignKey(d => d.IdControleNotificacao)
                .HasConstraintName("FK_dbo.TAB_NOTIFICACAO_dbo.TAB_CONTROLE_NOTIFICACAO_ID_CONTROLE_NOTIFICACAO");

            entity.HasOne(d => d.IdControleNotificacaoAssinaturaNavigation).WithMany(p => p.TabNotificacaos)
                .HasForeignKey(d => d.IdControleNotificacaoAssinatura)
                .HasConstraintName("FK_dbo.TAB_NOTIFICACAO_dbo.TAB_CONTROLE_NOTIFICACAO_ASSINATURA_ID_CONTROLE_NOTIFICACAO_ASSINATURA");

            entity.HasOne(d => d.IdControleProcessoAcaoNavigation).WithMany(p => p.TabNotificacaos)
                .HasForeignKey(d => d.IdControleProcessoAcao)
                .HasConstraintName("FK_dbo.TAB_NOTIFICACAO_dbo.TAB_CONTROLE_PROCESSO_ACAO_ID_CONTROLE_PROCESSO_ACAO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabNotificacaos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_NOTIFICACAO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabOcorrencium>(entity =>
        {
            entity.HasKey(e => e.IdOcorrencia).HasName("PK_dbo.TAB_OCORRENCIA");

            entity.ToTable("TAB_OCORRENCIA");

            entity.HasIndex(e => e.IdAtendimento, "IX_ID_ATENDIMENTO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdOcorrencia).HasColumnName("ID_OCORRENCIA");
            entity.Property(e => e.Assunto)
                .HasMaxLength(500)
                .HasColumnName("ASSUNTO");
            entity.Property(e => e.Descricao)
                .HasMaxLength(4000)
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtConclusao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CONCLUSAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtOcorrencia)
                .HasColumnType("datetime")
                .HasColumnName("DT_OCORRENCIA");
            entity.Property(e => e.HorarioOcorrencia).HasColumnName("HORARIO_OCORRENCIA");
            entity.Property(e => e.IdAtendimento).HasColumnName("ID_ATENDIMENTO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.SituacaoOcorrencia).HasColumnName("SITUACAO_OCORRENCIA");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdAtendimentoNavigation).WithMany(p => p.TabOcorrencia)
                .HasForeignKey(d => d.IdAtendimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_OCORRENCIA_dbo.TAB_ATENDIMENTO_ID_ATENDIMENTO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabOcorrencia)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_OCORRENCIA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabOcupacao>(entity =>
        {
            entity.HasKey(e => e.IdOcupacao).HasName("PK_dbo.TAB_OCUPACAO");

            entity.ToTable("TAB_OCUPACAO");

            entity.Property(e => e.IdOcupacao).HasColumnName("ID_OCUPACAO");
            entity.Property(e => e.CdOcupacao).HasColumnName("CD_OCUPACAO");
            entity.Property(e => e.DsOcupacao)
                .HasMaxLength(150)
                .HasColumnName("DS_OCUPACAO");
        });

        modelBuilder.Entity<TabOrdenadorDespesa>(entity =>
        {
            entity.HasKey(e => e.IdOrdenador).HasName("PK_dbo.TAB_ORDENADOR_DESPESA");

            entity.ToTable("TAB_ORDENADOR_DESPESA");

            entity.HasIndex(e => e.CdFormaIngresso, "IX_CD_FORMA_INGRESSO");

            entity.HasIndex(e => e.CdTipoCargo, "IX_CD_TIPO_CARGO");

            entity.HasIndex(e => e.CdTipoRelacao, "IX_CD_TIPO_RELACAO");

            entity.HasIndex(e => e.IdAgentePublico, "IX_ID_AGENTE_PUBLICO");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdUnidadeGestora, "IX_ID_UNIDADE_GESTORA");

            entity.HasIndex(e => e.IdUnidadeOrcamentaria, "IX_ID_UNIDADE_ORCAMENTARIA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdOrdenador).HasColumnName("ID_ORDENADOR");
            entity.Property(e => e.CdFormaIngresso)
                .HasMaxLength(128)
                .HasColumnName("CD_FORMA_INGRESSO");
            entity.Property(e => e.CdTipoCargo)
                .HasMaxLength(128)
                .HasColumnName("CD_TIPO_CARGO");
            entity.Property(e => e.CdTipoRelacao)
                .HasMaxLength(128)
                .HasColumnName("CD_TIPO_RELACAO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtFimGestao)
                .HasColumnType("datetime")
                .HasColumnName("DT_FIM_GESTAO");
            entity.Property(e => e.DtIncUnidadeOrcamentaria)
                .HasColumnType("datetime")
                .HasColumnName("DT_INC_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.DtInicioGestao)
                .HasColumnType("datetime")
                .HasColumnName("DT_INICIO_GESTAO");
            entity.Property(e => e.DtReferenciaDocumentacao).HasColumnName("DT_REFERENCIA_DOCUMENTACAO");
            entity.Property(e => e.IdAgentePublico).HasColumnName("ID_AGENTE_PUBLICO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdUnidadeGestora).HasColumnName("ID_UNIDADE_GESTORA");
            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmOrdenador).HasColumnName("NM_ORDENADOR");
            entity.Property(e => e.NrCpf)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF");
            entity.Property(e => e.NrExercicio).HasColumnName("NR_EXERCICIO");
            entity.Property(e => e.NrExpedienteNomeacao).HasColumnName("NR_EXPEDIENTE_NOMEACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.CdFormaIngressoNavigation).WithMany(p => p.TabOrdenadorDespesas)
                .HasForeignKey(d => d.CdFormaIngresso)
                .HasConstraintName("FK_dbo.TAB_ORDENADOR_DESPESA_dbo.TAB_FORMA_INGRESSO_SERVICO_PUBLICO_CD_FORMA_INGRESSO");

            entity.HasOne(d => d.CdTipoCargoNavigation).WithMany(p => p.TabOrdenadorDespesas)
                .HasForeignKey(d => d.CdTipoCargo)
                .HasConstraintName("FK_dbo.TAB_ORDENADOR_DESPESA_dbo.TAB_TIPO_CARGO_CD_TIPO_CARGO");

            entity.HasOne(d => d.CdTipoRelacaoNavigation).WithMany(p => p.TabOrdenadorDespesas)
                .HasForeignKey(d => d.CdTipoRelacao)
                .HasConstraintName("FK_dbo.TAB_ORDENADOR_DESPESA_dbo.TAB_TIPO_RELACAO_SERVICO_PUBLICO_CD_TIPO_RELACAO");

            entity.HasOne(d => d.IdAgentePublicoNavigation).WithMany(p => p.TabOrdenadorDespesas)
                .HasForeignKey(d => d.IdAgentePublico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ORDENADOR_DESPESA_dbo.TAB_AGENTE_PUBLICO_ID_AGENTE_PUBLICO");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabOrdenadorDespesas)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ORDENADOR_DESPESA_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabOrdenadorDespesas)
                .HasForeignKey(d => d.IdOrgao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ORDENADOR_DESPESA_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdUnidadeGestoraNavigation).WithMany(p => p.TabOrdenadorDespesas)
                .HasForeignKey(d => d.IdUnidadeGestora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ORDENADOR_DESPESA_dbo.TAB_UNIDADE_GESTORA_ID_UNIDADE_GESTORA");

            entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation).WithMany(p => p.TabOrdenadorDespesas)
                .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ORDENADOR_DESPESA_dbo.TAB_UNIDADE_ORCAMENTARIA_ID_UNIDADE_ORCAMENTARIA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabOrdenadorDespesas)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_ORDENADOR_DESPESA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabOrgao>(entity =>
        {
            entity.HasKey(e => e.IdOrgao).HasName("PK_dbo.TAB_ORGAO");

            entity.ToTable("TAB_ORGAO");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.CdMunicipio)
                .HasMaxLength(3)
                .HasColumnName("CD_MUNICIPIO");
            entity.Property(e => e.CdOrcamentario).HasColumnName("CD_ORCAMENTARIO");
            entity.Property(e => e.CdOrgao)
                .HasMaxLength(2)
                .HasColumnName("CD_ORGAO");
            entity.Property(e => e.CepOrgao)
                .HasMaxLength(8)
                .HasColumnName("CEP_ORGAO");
            entity.Property(e => e.CnpjOrgao)
                .HasMaxLength(14)
                .HasColumnName("CNPJ_ORGAO");
            entity.Property(e => e.DsOrgao)
                .HasMaxLength(1000)
                .HasColumnName("DS_ORGAO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtCriacaoOrgao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO_ORGAO");
            entity.Property(e => e.EmailOrgao)
                .HasMaxLength(50)
                .HasColumnName("EMAIL_ORGAO");
            entity.Property(e => e.EnderecoOrgao).HasColumnName("ENDERECO_ORGAO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmOrgao)
                .HasMaxLength(100)
                .HasColumnName("NM_ORGAO");
            entity.Property(e => e.NrExercicio).HasColumnName("NR_EXERCICIO");
            entity.Property(e => e.ReferenciaLei)
                .HasMaxLength(100)
                .HasColumnName("REFERENCIA_LEI");
            entity.Property(e => e.TelOrgao)
                .HasMaxLength(11)
                .HasColumnName("TEL_ORGAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpUnidadeAdministrativa).HasColumnName("TP_UNIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabOrgaos)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_ORGAO_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabOrgaos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_ORGAO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabPessoa>(entity =>
        {
            entity.HasKey(e => e.IdPessoa).HasName("PK_dbo.TAB_PESSOA");

            entity.ToTable("TAB_PESSOA");

            entity.HasIndex(e => e.IdMunicipio, "IX_ID_MUNICIPIO");

            entity.HasIndex(e => e.IdMunicipioEleitor, "IX_ID_MUNICIPIO_ELEITOR");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.HasIndex(e => e.UfRg, "IX_UF_RG");

            entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");
            entity.Property(e => e.Biometria).HasColumnName("BIOMETRIA");
            entity.Property(e => e.Complemento)
                .HasMaxLength(300)
                .HasColumnName("COMPLEMENTO");
            entity.Property(e => e.DadosAdicionais)
                .HasMaxLength(255)
                .HasColumnName("DADOS_ADICIONAIS");
            entity.Property(e => e.DsNacionalidade)
                .HasMaxLength(100)
                .HasColumnName("DS_NACIONALIDADE");
            entity.Property(e => e.DsNaturalidade)
                .HasMaxLength(100)
                .HasColumnName("DS_NATURALIDADE");
            entity.Property(e => e.DtAdmissao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ADMISSAO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtExpedicaoRg)
                .HasColumnType("datetime")
                .HasColumnName("DT_EXPEDICAO_RG");
            entity.Property(e => e.DtNascimento)
                .HasColumnType("datetime")
                .HasColumnName("DT_NASCIMENTO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EnderecoCompleto).HasColumnName("ENDERECO_COMPLETO");
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");
            entity.Property(e => e.IdMunicipioEleitor).HasColumnName("ID_MUNICIPIO_ELEITOR");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmApelido)
                .HasMaxLength(50)
                .HasColumnName("NM_APELIDO");
            entity.Property(e => e.NmBairro)
                .HasMaxLength(80)
                .HasColumnName("NM_BAIRRO");
            entity.Property(e => e.NmCompletoConjuge)
                .HasMaxLength(60)
                .HasColumnName("NM_COMPLETO_CONJUGE");
            entity.Property(e => e.NmCompletoMae)
                .HasMaxLength(60)
                .HasColumnName("NM_COMPLETO_MAE");
            entity.Property(e => e.NmCompletoPai)
                .HasMaxLength(60)
                .HasColumnName("NM_COMPLETO_PAI");
            entity.Property(e => e.NmLogradouro)
                .HasMaxLength(125)
                .HasColumnName("NM_LOGRADOURO");
            entity.Property(e => e.NmPessoa)
                .HasMaxLength(100)
                .HasColumnName("NM_PESSOA");
            entity.Property(e => e.NrCep)
                .HasMaxLength(16)
                .HasColumnName("NR_CEP");
            entity.Property(e => e.NrCnpj)
                .HasMaxLength(14)
                .HasColumnName("NR_CNPJ");
            entity.Property(e => e.NrCpf)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF");
            entity.Property(e => e.NrCpfConjuge)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF_CONJUGE");
            entity.Property(e => e.NrCtps)
                .HasMaxLength(10)
                .HasColumnName("NR_CTPS");
            entity.Property(e => e.NrLogradouro).HasColumnName("NR_LOGRADOURO");
            entity.Property(e => e.NrMatricula).HasColumnName("NR_MATRICULA");
            entity.Property(e => e.NrNis)
                .HasMaxLength(11)
                .HasColumnName("NR_NIS");
            entity.Property(e => e.NrPisPasep)
                .HasMaxLength(11)
                .HasColumnName("NR_PIS_PASEP");
            entity.Property(e => e.NrRg)
                .HasMaxLength(15)
                .HasColumnName("NR_RG");
            entity.Property(e => e.NrSecaoEleitor).HasColumnName("NR_SECAO_ELEITOR");
            entity.Property(e => e.NrTelefoneCelularPrimario)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_CELULAR_PRIMARIO");
            entity.Property(e => e.NrTelefoneFixoComercial)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_FIXO_COMERCIAL");
            entity.Property(e => e.NrTelefoneFixoResidencial)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_FIXO_RESIDENCIAL");
            entity.Property(e => e.NrTelefoneOutroCelular)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_OUTRO_CELULAR");
            entity.Property(e => e.NrTituloEleitor)
                .HasMaxLength(25)
                .HasColumnName("NR_TITULO_ELEITOR");
            entity.Property(e => e.NrZonaEleitor).HasColumnName("NR_ZONA_ELEITOR");
            entity.Property(e => e.NumeroCrc)
                .HasMaxLength(10)
                .HasColumnName("NUMERO_CRC");
            entity.Property(e => e.NumeroOab)
                .HasMaxLength(10)
                .HasColumnName("NUMERO_OAB");
            entity.Property(e => e.SeccionalUf).HasColumnName("SECCIONAL_UF");
            entity.Property(e => e.SerieCtps)
                .HasMaxLength(10)
                .HasColumnName("SERIE_CTPS");
            entity.Property(e => e.SiglaOrgaoEmissorRg)
                .HasMaxLength(10)
                .HasColumnName("SIGLA_ORGAO_EMISSOR_RG");
            entity.Property(e => e.TpEstadoCivil).HasColumnName("TP_ESTADO_CIVIL");
            entity.Property(e => e.TpGrauInstrucao).HasColumnName("TP_GRAU_INSTRUCAO");
            entity.Property(e => e.TpInscricaoSeccional).HasColumnName("TP_INSCRICAO_SECCIONAL");
            entity.Property(e => e.TpLogradouro).HasColumnName("TP_LOGRADOURO");
            entity.Property(e => e.TpSexo).HasColumnName("TP_SEXO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpVinculacao).HasColumnName("TP_VINCULACAO");
            entity.Property(e => e.TpZona).HasColumnName("TP_ZONA");
            entity.Property(e => e.UfRg)
                .HasMaxLength(2)
                .HasColumnName("UF_RG");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.TabPessoaIdMunicipioNavigations)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_dbo.TAB_PESSOA_dbo.TAB_MUNICIPIO_ID_MUNICIPIO");

            entity.HasOne(d => d.IdMunicipioEleitorNavigation).WithMany(p => p.TabPessoaIdMunicipioEleitorNavigations)
                .HasForeignKey(d => d.IdMunicipioEleitor)
                .HasConstraintName("FK_dbo.TAB_PESSOA_dbo.TAB_MUNICIPIO_ID_MUNICIPIO_ELEITOR");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabPessoas)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_PESSOA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");

            entity.HasOne(d => d.UfRgNavigation).WithMany(p => p.TabPessoas)
                .HasForeignKey(d => d.UfRg)
                .HasConstraintName("FK_dbo.TAB_PESSOA_dbo.TAB_ESTADO_UF_RG");
        });

        modelBuilder.Entity<TabProtocolo>(entity =>
        {
            entity.HasKey(e => e.IdProtocolo).HasName("PK_dbo.TAB_PROTOCOLO");

            entity.ToTable("TAB_PROTOCOLO");

            entity.HasIndex(e => e.IdAssinatura, "IX_ID_ASSINATURA");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdResponsavelEscritorioEntrega, "IX_ID_RESPONSAVEL_ESCRITORIO_ENTREGA");

            entity.HasIndex(e => e.IdResponsavelEscritorioRecepcao, "IX_ID_RESPONSAVEL_ESCRITORIO_RECEPCAO");

            entity.HasIndex(e => e.IdUnidadeGestora, "IX_ID_UNIDADE_GESTORA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdProtocolo).HasColumnName("ID_PROTOCOLO");
            entity.Property(e => e.DataControle)
                .HasColumnType("datetime")
                .HasColumnName("DATA_CONTROLE");
            entity.Property(e => e.DsProtocolo)
                .HasMaxLength(4000)
                .HasColumnName("DS_PROTOCOLO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("EMAIL");
            entity.Property(e => e.HorarioControle).HasColumnName("HORARIO_CONTROLE");
            entity.Property(e => e.IdAssinatura).HasColumnName("ID_ASSINATURA");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdResponsavelEscritorioEntrega).HasColumnName("ID_RESPONSAVEL_ESCRITORIO_ENTREGA");
            entity.Property(e => e.IdResponsavelEscritorioRecepcao).HasColumnName("ID_RESPONSAVEL_ESCRITORIO_RECEPCAO");
            entity.Property(e => e.IdUnidadeGestora).HasColumnName("ID_UNIDADE_GESTORA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmContatoEmpresa)
                .HasMaxLength(100)
                .HasColumnName("NM_CONTATO_EMPRESA");
            entity.Property(e => e.NmDocumentoProtocolo)
                .HasMaxLength(100)
                .HasColumnName("NM_DOCUMENTO_PROTOCOLO");
            entity.Property(e => e.NmFuncaoPessoaProtocolada)
                .HasMaxLength(100)
                .HasColumnName("NM_FUNCAO_PESSOA_PROTOCOLADA");
            entity.Property(e => e.NmPessoaProtocolada)
                .HasMaxLength(100)
                .HasColumnName("NM_PESSOA_PROTOCOLADA");
            entity.Property(e => e.NrCnpj)
                .HasMaxLength(14)
                .HasColumnName("NR_CNPJ");
            entity.Property(e => e.NrCpf)
                .HasMaxLength(11)
                .HasColumnName("NR_CPF");
            entity.Property(e => e.NrTelefoneContato)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_CONTATO");
            entity.Property(e => e.NumeroProtocolo).HasColumnName("NUMERO_PROTOCOLO");
            entity.Property(e => e.TpProtocolo).HasColumnName("TP_PROTOCOLO");
            entity.Property(e => e.TpProtocoloCliente).HasColumnName("TP_PROTOCOLO_CLIENTE");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpTramitacaoProtocolo).HasColumnName("TP_TRAMITACAO_PROTOCOLO");

            entity.HasOne(d => d.IdAssinaturaNavigation).WithMany(p => p.TabProtocolos)
                .HasForeignKey(d => d.IdAssinatura)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_dbo.TAB_ASSINATURA_ID_ASSINATURA");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabProtocolos)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabProtocolos)
                .HasForeignKey(d => d.IdOrgao)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdResponsavelEscritorioEntregaNavigation).WithMany(p => p.TabProtocoloIdResponsavelEscritorioEntregaNavigations)
                .HasForeignKey(d => d.IdResponsavelEscritorioEntrega)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO_ENTREGA");

            entity.HasOne(d => d.IdResponsavelEscritorioRecepcaoNavigation).WithMany(p => p.TabProtocoloIdResponsavelEscritorioRecepcaoNavigations)
                .HasForeignKey(d => d.IdResponsavelEscritorioRecepcao)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO_RECEPCAO");

            entity.HasOne(d => d.IdUnidadeGestoraNavigation).WithMany(p => p.TabProtocolos)
                .HasForeignKey(d => d.IdUnidadeGestora)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_dbo.TAB_UNIDADE_GESTORA_ID_UNIDADE_GESTORA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabProtocolos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabProtocoloControle>(entity =>
        {
            entity.HasKey(e => e.IdProtocoloControle).HasName("PK_dbo.TAB_PROTOCOLO_CONTROLE");

            entity.ToTable("TAB_PROTOCOLO_CONTROLE");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdProtocoloControle).HasColumnName("ID_PROTOCOLO_CONTROLE");
            entity.Property(e => e.DataControle)
                .HasColumnType("datetime")
                .HasColumnName("DATA_CONTROLE");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.SequenciaControle).HasColumnName("SEQUENCIA_CONTROLE");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpTramitacaoProtocolo).HasColumnName("TP_TRAMITACAO_PROTOCOLO");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabProtocoloControles)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_CONTROLE_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabProtocoloControles)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_CONTROLE_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabProtocoloDocumento>(entity =>
        {
            entity.HasKey(e => e.IdProtocoloDocumento).HasName("PK_dbo.TAB_PROTOCOLO_DOCUMENTO");

            entity.ToTable("TAB_PROTOCOLO_DOCUMENTO");

            entity.HasIndex(e => e.IdProtocolo, "IX_ID_PROTOCOLO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdProtocoloDocumento).HasColumnName("ID_PROTOCOLO_DOCUMENTO");
            entity.Property(e => e.CaminhoCompletoDocumento)
                .HasMaxLength(255)
                .HasColumnName("CAMINHO_COMPLETO_DOCUMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdProtocolo).HasColumnName("ID_PROTOCOLO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmDocumento)
                .HasMaxLength(255)
                .HasColumnName("NM_DOCUMENTO");
            entity.Property(e => e.TpDocumento).HasColumnName("TP_DOCUMENTO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdProtocoloNavigation).WithMany(p => p.TabProtocoloDocumentos)
                .HasForeignKey(d => d.IdProtocolo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_DOCUMENTO_dbo.TAB_PROTOCOLO_ID_PROTOCOLO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabProtocoloDocumentos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_PROTOCOLO_DOCUMENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabPublicacaoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdPublicacaoDocumento).HasName("PK_dbo.TAB_PUBLICACAO_DOCUMENTO");

            entity.ToTable("TAB_PUBLICACAO_DOCUMENTO");

            entity.HasIndex(e => e.IdControladora, "IX_ID_CONTROLADORA");

            entity.HasIndex(e => e.IdTribunal, "IX_ID_TRIBUNAL");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdPublicacaoDocumento).HasColumnName("ID_PUBLICACAO_DOCUMENTO");
            entity.Property(e => e.AnoPublicacao).HasColumnName("ANO_PUBLICACAO");
            entity.Property(e => e.CaminhoCompletoDocumento)
                .HasMaxLength(500)
                .HasColumnName("CAMINHO_COMPLETO_DOCUMENTO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtDisponibilizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_DISPONIBILIZACAO");
            entity.Property(e => e.DtProcessamento)
                .HasColumnType("datetime")
                .HasColumnName("DT_PROCESSAMENTO");
            entity.Property(e => e.DtPublicacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_PUBLICACAO");
            entity.Property(e => e.IdControladora).HasColumnName("ID_CONTROLADORA");
            entity.Property(e => e.IdTribunal).HasColumnName("ID_TRIBUNAL");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.IdentificadorLeitura).HasColumnName("IDENTIFICADOR_LEITURA");
            entity.Property(e => e.NmDocumento)
                .HasMaxLength(100)
                .HasColumnName("NM_DOCUMENTO");
            entity.Property(e => e.NrPublicacao).HasColumnName("NR_PUBLICACAO");
            entity.Property(e => e.SituacaoProcessamento).HasColumnName("SITUACAO_PROCESSAMENTO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControladoraNavigation).WithMany(p => p.TabPublicacaoDocumentos)
                .HasForeignKey(d => d.IdControladora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_PUBLICACAO_DOCUMENTO_dbo.TAB_CONTROLADORA_ID_CONTROLADORA");

            entity.HasOne(d => d.IdTribunalNavigation).WithMany(p => p.TabPublicacaoDocumentos)
                .HasForeignKey(d => d.IdTribunal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_PUBLICACAO_DOCUMENTO_dbo.TAB_TRIBUNAL_ID_TRIBUNAL");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabPublicacaoDocumentos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_PUBLICACAO_DOCUMENTO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabRecebimentoSim>(entity =>
        {
            entity.HasKey(e => e.IdRecebimento).HasName("PK_dbo.TAB_RECEBIMENTO_SIM");

            entity.ToTable("TAB_RECEBIMENTO_SIM");

            entity.Property(e => e.IdRecebimento).HasColumnName("ID_RECEBIMENTO");
            entity.Property(e => e.DtRecebimento)
                .HasColumnType("datetime")
                .HasColumnName("DT_RECEBIMENTO");
            entity.Property(e => e.LgRecebimento).HasColumnName("LG_RECEBIMENTO");
            entity.Property(e => e.NmArquivoRecebido).HasColumnName("NM_ARQUIVO_RECEBIDO");
        });

        modelBuilder.Entity<TabRegimeJuridicoRelacaoFuncional>(entity =>
        {
            entity.HasKey(e => e.TpRegime).HasName("PK_dbo.TAB_REGIME_JURIDICO_RELACAO_FUNCIONAL");

            entity.ToTable("TAB_REGIME_JURIDICO_RELACAO_FUNCIONAL");

            entity.Property(e => e.TpRegime)
                .HasMaxLength(128)
                .HasColumnName("TP_REGIME");
            entity.Property(e => e.DsRegime)
                .HasMaxLength(50)
                .HasColumnName("DS_REGIME");
        });

        modelBuilder.Entity<TabRegimePrevidenciario>(entity =>
        {
            entity.HasKey(e => e.TpRegime).HasName("PK_dbo.TAB_REGIME_PREVIDENCIARIO");

            entity.ToTable("TAB_REGIME_PREVIDENCIARIO");

            entity.Property(e => e.TpRegime)
                .HasMaxLength(128)
                .HasColumnName("TP_REGIME");
            entity.Property(e => e.DsRegime)
                .HasMaxLength(50)
                .HasColumnName("DS_REGIME");
        });

        modelBuilder.Entity<TabReingressoAgentePublico>(entity =>
        {
            entity.HasKey(e => e.IdRap).HasName("PK_dbo.TAB_REINGRESSO_AGENTE_PUBLICO");

            entity.ToTable("TAB_REINGRESSO_AGENTE_PUBLICO");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdFormaIngressoServicoPublico, "IX_ID_FORMA_INGRESSO_SERVICO_PUBLICO");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdTipoRelacaoServicoPublico, "IX_ID_TIPO_RELACAO_SERVICO_PUBLICO");

            entity.HasIndex(e => e.IdUnidadeOrcamentaria, "IX_ID_UNIDADE_ORCAMENTARIA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdRap).HasColumnName("ID_RAP");
            entity.Property(e => e.CpfAgentePublico).HasColumnName("CPF_AGENTE_PUBLICO");
            entity.Property(e => e.DtAmparoLegalExpedienteReingresso)
                .HasColumnType("datetime")
                .HasColumnName("DT_AMPARO_LEGAL_EXPEDIENTE_REINGRESSO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtPublicacaoAmparoLegalExpedienteReingresso)
                .HasColumnType("datetime")
                .HasColumnName("DT_PUBLICACAO_AMPARO_LEGAL_EXPEDIENTE_REINGRESSO");
            entity.Property(e => e.DtPublicacaoExpedienteReingresso)
                .HasColumnType("datetime")
                .HasColumnName("DT_PUBLICACAO_EXPEDIENTE_REINGRESSO");
            entity.Property(e => e.DtReferenciaDocumentacao).HasColumnName("DT_REFERENCIA_DOCUMENTACAO");
            entity.Property(e => e.ExercicioOrcamento).HasColumnName("EXERCICIO_ORCAMENTO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdFormaIngressoServicoPublico)
                .HasMaxLength(128)
                .HasColumnName("ID_FORMA_INGRESSO_SERVICO_PUBLICO");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdTipoRelacaoServicoPublico)
                .HasMaxLength(128)
                .HasColumnName("ID_TIPO_RELACAO_SERVICO_PUBLICO");
            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NrAmparoLegalExpedienteReingresso).HasColumnName("NR_AMPARO_LEGAL_EXPEDIENTE_REINGRESSO");
            entity.Property(e => e.NrExpedienteDesligamento).HasColumnName("NR_EXPEDIENTE_DESLIGAMENTO");
            entity.Property(e => e.NrExpedienteNomeacao).HasColumnName("NR_EXPEDIENTE_NOMEACAO");
            entity.Property(e => e.NrExpedienteReingresso).HasColumnName("NR_EXPEDIENTE_REINGRESSO");
            entity.Property(e => e.TpAmparoLegalExpedienteReingresso).HasColumnName("TP_AMPARO_LEGAL_EXPEDIENTE_REINGRESSO");
            entity.Property(e => e.TpExpedienteReingresso).HasColumnName("TP_EXPEDIENTE_REINGRESSO");
            entity.Property(e => e.TpReingresso).HasColumnName("TP_REINGRESSO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabReingressoAgentePublicos)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_REINGRESSO_AGENTE_PUBLICO_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdFormaIngressoServicoPublicoNavigation).WithMany(p => p.TabReingressoAgentePublicos)
                .HasForeignKey(d => d.IdFormaIngressoServicoPublico)
                .HasConstraintName("FK_dbo.TAB_REINGRESSO_AGENTE_PUBLICO_dbo.TAB_FORMA_INGRESSO_SERVICO_PUBLICO_ID_FORMA_INGRESSO_SERVICO_PUBLICO");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabReingressoAgentePublicos)
                .HasForeignKey(d => d.IdOrgao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_REINGRESSO_AGENTE_PUBLICO_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdTipoRelacaoServicoPublicoNavigation).WithMany(p => p.TabReingressoAgentePublicos)
                .HasForeignKey(d => d.IdTipoRelacaoServicoPublico)
                .HasConstraintName("FK_dbo.TAB_REINGRESSO_AGENTE_PUBLICO_dbo.TAB_TIPO_RELACAO_SERVICO_PUBLICO_ID_TIPO_RELACAO_SERVICO_PUBLICO");

            entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation).WithMany(p => p.TabReingressoAgentePublicos)
                .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_REINGRESSO_AGENTE_PUBLICO_dbo.TAB_UNIDADE_ORCAMENTARIA_ID_UNIDADE_ORCAMENTARIA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabReingressoAgentePublicos)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_REINGRESSO_AGENTE_PUBLICO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabResponsavelControladora>(entity =>
        {
            entity.HasKey(e => e.IdResponsavelControladora).HasName("PK_dbo.TAB_RESPONSAVEL_CONTROLADORA");

            entity.ToTable("TAB_RESPONSAVEL_CONTROLADORA");

            entity.HasIndex(e => e.IdControladora, "IX_ID_CONTROLADORA");

            entity.HasIndex(e => e.IdPessoa, "IX_ID_PESSOA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.HasIndex(e => e.IdUsuarioSistema, "IX_ID_USUARIO_SISTEMA");

            entity.Property(e => e.IdResponsavelControladora).HasColumnName("ID_RESPONSAVEL_CONTROLADORA");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdControladora).HasColumnName("ID_CONTROLADORA");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.IdUsuarioSistema).HasColumnName("ID_USUARIO_SISTEMA");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControladoraNavigation).WithMany(p => p.TabResponsavelControladoras)
                .HasForeignKey(d => d.IdControladora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_RESPONSAVEL_CONTROLADORA_dbo.TAB_CONTROLADORA_ID_CONTROLADORA");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.TabResponsavelControladoras)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_RESPONSAVEL_CONTROLADORA_dbo.TAB_PESSOA_ID_PESSOA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabResponsavelControladoraIdUsuarioAtualizacaoNavigations)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_RESPONSAVEL_CONTROLADORA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");

            entity.HasOne(d => d.IdUsuarioSistemaNavigation).WithMany(p => p.TabResponsavelControladoraIdUsuarioSistemaNavigations)
                .HasForeignKey(d => d.IdUsuarioSistema)
                .HasConstraintName("FK_dbo.TAB_RESPONSAVEL_CONTROLADORA_dbo.TAB_USUARIO_ID_USUARIO_SISTEMA");
        });

        modelBuilder.Entity<TabResponsavelEscritorio>(entity =>
        {
            entity.HasKey(e => e.IdResponsavelEscritorio).HasName("PK_dbo.TAB_RESPONSAVEL_ESCRITORIO");

            entity.ToTable("TAB_RESPONSAVEL_ESCRITORIO");

            entity.HasIndex(e => e.IdControladora, "IX_ID_CONTROLADORA");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdPessoa, "IX_ID_PESSOA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.HasIndex(e => e.IdUsuarioSistema, "IX_ID_USUARIO_SISTEMA");

            entity.Property(e => e.IdResponsavelEscritorio).HasColumnName("ID_RESPONSAVEL_ESCRITORIO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdControladora).HasColumnName("ID_CONTROLADORA");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.IdUsuarioSistema).HasColumnName("ID_USUARIO_SISTEMA");
            entity.Property(e => e.TpFuncionario).HasColumnName("TP_FUNCIONARIO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdControladoraNavigation).WithMany(p => p.TabResponsavelEscritorios)
                .HasForeignKey(d => d.IdControladora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_RESPONSAVEL_ESCRITORIO_dbo.TAB_CONTROLADORA_ID_CONTROLADORA");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabResponsavelEscritorios)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_RESPONSAVEL_ESCRITORIO_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.TabResponsavelEscritorios)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_RESPONSAVEL_ESCRITORIO_dbo.TAB_PESSOA_ID_PESSOA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabResponsavelEscritorioIdUsuarioAtualizacaoNavigations)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_RESPONSAVEL_ESCRITORIO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");

            entity.HasOne(d => d.IdUsuarioSistemaNavigation).WithMany(p => p.TabResponsavelEscritorioIdUsuarioSistemaNavigations)
                .HasForeignKey(d => d.IdUsuarioSistema)
                .HasConstraintName("FK_dbo.TAB_RESPONSAVEL_ESCRITORIO_dbo.TAB_USUARIO_ID_USUARIO_SISTEMA");
        });

        modelBuilder.Entity<TabSetor>(entity =>
        {
            entity.HasKey(e => e.IdSetor).HasName("PK_dbo.TAB_SETOR");

            entity.ToTable("TAB_SETOR");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdResponsavelEscritorio, "IX_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdSetor).HasColumnName("ID_SETOR");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdResponsavelEscritorio).HasColumnName("ID_RESPONSAVEL_ESCRITORIO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmSetor)
                .HasMaxLength(100)
                .HasColumnName("NM_SETOR");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabSetors)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_SETOR_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdResponsavelEscritorioNavigation).WithMany(p => p.TabSetors)
                .HasForeignKey(d => d.IdResponsavelEscritorio)
                .HasConstraintName("FK_dbo.TAB_SETOR_dbo.TAB_RESPONSAVEL_ESCRITORIO_ID_RESPONSAVEL_ESCRITORIO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabSetors)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_SETOR_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabTarefa>(entity =>
        {
            entity.HasKey(e => e.IdTarefa).HasName("PK_dbo.TAB_TAREFA");

            entity.ToTable("TAB_TAREFA");

            entity.HasIndex(e => e.IdEscritorio, "IX_ID_ESCRITORIO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdTarefa).HasColumnName("ID_TAREFA");
            entity.Property(e => e.DsTarefa)
                .HasMaxLength(1000)
                .HasColumnName("DS_TAREFA");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdEscritorio).HasColumnName("ID_ESCRITORIO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.TituloTarefa)
                .HasMaxLength(255)
                .HasColumnName("TITULO_TAREFA");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpTarefa).HasColumnName("TP_TAREFA");

            entity.HasOne(d => d.IdEscritorioNavigation).WithMany(p => p.TabTarefas)
                .HasForeignKey(d => d.IdEscritorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_TAREFA_dbo.TAB_ESCRITORIO_ID_ESCRITORIO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabTarefas)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_TAREFA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabTipoAmparoLegalExpedienteNomeacao>(entity =>
        {
            entity.HasKey(e => e.TipoAmparo).HasName("PK_dbo.TAB_TIPO_AMPARO_LEGAL_EXPEDIENTE_NOMEACAO");

            entity.ToTable("TAB_TIPO_AMPARO_LEGAL_EXPEDIENTE_NOMEACAO");

            entity.Property(e => e.TipoAmparo)
                .HasMaxLength(128)
                .HasColumnName("TIPO_AMPARO");
            entity.Property(e => e.DsAmparoLegal)
                .HasMaxLength(100)
                .HasColumnName("DS_AMPARO_LEGAL");
        });

        modelBuilder.Entity<TabTipoCargo>(entity =>
        {
            entity.HasKey(e => e.CodigoTipo).HasName("PK_dbo.TAB_TIPO_CARGO");

            entity.ToTable("TAB_TIPO_CARGO");

            entity.Property(e => e.CodigoTipo)
                .HasMaxLength(128)
                .HasColumnName("CODIGO_TIPO");
            entity.Property(e => e.DsCargo)
                .HasMaxLength(60)
                .HasColumnName("DS_CARGO");
        });

        modelBuilder.Entity<TabTipoExpedienteNomeacao>(entity =>
        {
            entity.HasKey(e => e.TipoExpediente).HasName("PK_dbo.TAB_TIPO_EXPEDIENTE_NOMEACAO");

            entity.ToTable("TAB_TIPO_EXPEDIENTE_NOMEACAO");

            entity.Property(e => e.TipoExpediente)
                .HasMaxLength(128)
                .HasColumnName("TIPO_EXPEDIENTE");
            entity.Property(e => e.DsExpedienteNomeacao)
                .HasMaxLength(100)
                .HasColumnName("DS_EXPEDIENTE_NOMEACAO");
        });

        modelBuilder.Entity<TabTipoRelacaoServicoPublico>(entity =>
        {
            entity.HasKey(e => e.TipoRelacao).HasName("PK_dbo.TAB_TIPO_RELACAO_SERVICO_PUBLICO");

            entity.ToTable("TAB_TIPO_RELACAO_SERVICO_PUBLICO");

            entity.Property(e => e.TipoRelacao)
                .HasMaxLength(128)
                .HasColumnName("TIPO_RELACAO");
            entity.Property(e => e.DsRelacao)
                .HasMaxLength(100)
                .HasColumnName("DS_RELACAO");
        });

        modelBuilder.Entity<TabTribunal>(entity =>
        {
            entity.HasKey(e => e.IdTribunal).HasName("PK_dbo.TAB_TRIBUNAL");

            entity.ToTable("TAB_TRIBUNAL");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.HasIndex(e => e.Uf, "IX_UF");

            entity.Property(e => e.IdTribunal).HasColumnName("ID_TRIBUNAL");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmTribunal)
                .HasMaxLength(255)
                .HasColumnName("NM_TRIBUNAL");
            entity.Property(e => e.SiglaTribunal)
                .HasMaxLength(30)
                .HasColumnName("SIGLA_TRIBUNAL");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("UF");
            entity.Property(e => e.UrlTribunal)
                .HasMaxLength(100)
                .HasColumnName("URL_TRIBUNAL");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabTribunals)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_TRIBUNAL_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");

            entity.HasOne(d => d.UfNavigation).WithMany(p => p.TabTribunals)
                .HasForeignKey(d => d.Uf)
                .HasConstraintName("FK_dbo.TAB_TRIBUNAL_dbo.TAB_ESTADO_UF");
        });

        modelBuilder.Entity<TabUnidadeGestora>(entity =>
        {
            entity.HasKey(e => e.IdUnidadeGestora).HasName("PK_dbo.TAB_UNIDADE_GESTORA");

            entity.ToTable("TAB_UNIDADE_GESTORA");

            entity.HasIndex(e => e.IdEntidadeAdministrativa, "IX_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdUnidadeOrcamentaria, "IX_ID_UNIDADE_ORCAMENTARIA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdUnidadeGestora).HasColumnName("ID_UNIDADE_GESTORA");
            entity.Property(e => e.CdOrcamentario).HasColumnName("CD_ORCAMENTARIO");
            entity.Property(e => e.CdUnidadeGestora)
                .HasMaxLength(2)
                .HasColumnName("CD_UNIDADE_GESTORA");
            entity.Property(e => e.DtAtualizacao).HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao).HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtCriacaoUnidadeGestora).HasColumnName("DT_CRIACAO_UNIDADE_GESTORA");
            entity.Property(e => e.DtIncUnorcamentUngestora).HasColumnName("DT_INC_UNORCAMENT_UNGESTORA");
            entity.Property(e => e.DtRefDocumentacao).HasColumnName("DT_REF_DOCUMENTACAO");
            entity.Property(e => e.IdEntidadeAdministrativa).HasColumnName("ID_ENTIDADE_ADMINISTRATIVA");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmUnidadeGestora)
                .HasMaxLength(100)
                .HasColumnName("NM_UNIDADE_GESTORA");
            entity.Property(e => e.NrExercicio).HasColumnName("NR_EXERCICIO");
            entity.Property(e => e.ReferenciaLei)
                .HasMaxLength(100)
                .HasColumnName("REFERENCIA_LEI");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdEntidadeAdministrativaNavigation).WithMany(p => p.TabUnidadeGestoras)
                .HasForeignKey(d => d.IdEntidadeAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_UNIDADE_GESTORA_dbo.TAB_ENTIDADE_ADMINISTRATIVA_ID_ENTIDADE_ADMINISTRATIVA");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabUnidadeGestoras)
                .HasForeignKey(d => d.IdOrgao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_UNIDADE_GESTORA_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdUnidadeOrcamentariaNavigation).WithMany(p => p.TabUnidadeGestoras)
                .HasForeignKey(d => d.IdUnidadeOrcamentaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_UNIDADE_GESTORA_dbo.TAB_UNIDADE_ORCAMENTARIA_ID_UNIDADE_ORCAMENTARIA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabUnidadeGestoras)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_UNIDADE_GESTORA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabUnidadeOrcamentarium>(entity =>
        {
            entity.HasKey(e => e.IdUnidadeOrcamentaria).HasName("PK_dbo.TAB_UNIDADE_ORCAMENTARIA");

            entity.ToTable("TAB_UNIDADE_ORCAMENTARIA");

            entity.HasIndex(e => e.IdOrgao, "IX_ID_ORGAO");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdUnidadeOrcamentaria).HasColumnName("ID_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.CdOrcamentario).HasColumnName("CD_ORCAMENTARIO");
            entity.Property(e => e.CdUnidadeOrcamentaria)
                .HasMaxLength(4)
                .HasColumnName("CD_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.DtCriacaoUnidadeOrcamentaria)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.IdOrgao).HasColumnName("ID_ORGAO");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.NmUnidadeOrcamentaria)
                .HasMaxLength(100)
                .HasColumnName("NM_UNIDADE_ORCAMENTARIA");
            entity.Property(e => e.NrExercicio).HasColumnName("NR_EXERCICIO");
            entity.Property(e => e.TipoAdministracao)
                .HasMaxLength(2)
                .HasColumnName("TIPO_ADMINISTRACAO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");

            entity.HasOne(d => d.IdOrgaoNavigation).WithMany(p => p.TabUnidadeOrcamentaria)
                .HasForeignKey(d => d.IdOrgao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_UNIDADE_ORCAMENTARIA_dbo.TAB_ORGAO_ID_ORGAO");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.TabUnidadeOrcamentaria)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_UNIDADE_ORCAMENTARIA_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        modelBuilder.Entity<TabUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_dbo.TAB_USUARIO");

            entity.ToTable("TAB_USUARIO");

            entity.HasIndex(e => e.IdMantenedora, "IX_ID_MANTENEDORA");

            entity.HasIndex(e => e.IdUsuarioAtualizacao, "IX_ID_USUARIO_ATUALIZACAO");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.AvatarUsuario).HasColumnName("AVATAR_USUARIO");
            entity.Property(e => e.CodigoAutenticacao).HasColumnName("CODIGO_AUTENTICACAO");
            entity.Property(e => e.DtAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_ATUALIZACAO");
            entity.Property(e => e.DtCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DT_CRIACAO");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
            entity.Property(e => e.IdEscritorioConfigurado).HasColumnName("ID_ESCRITORIO_CONFIGURADO");
            entity.Property(e => e.IdMantenedora).HasColumnName("ID_MANTENEDORA");
            entity.Property(e => e.IdUsuarioAtualizacao).HasColumnName("ID_USUARIO_ATUALIZACAO");
            entity.Property(e => e.Identificacao)
                .HasMaxLength(32)
                .HasColumnName("IDENTIFICACAO");
            entity.Property(e => e.NmUsuario)
                .HasMaxLength(60)
                .HasColumnName("NM_USUARIO");
            entity.Property(e => e.NrTelefoneContato)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_CONTATO");
            entity.Property(e => e.NrTelefoneOutro)
                .HasMaxLength(15)
                .HasColumnName("NR_TELEFONE_OUTRO");
            entity.Property(e => e.SenhaUsuario).HasColumnName("SENHA_USUARIO");
            entity.Property(e => e.TpSituacaoCadastral).HasColumnName("TP_SITUACAO_CADASTRAL");
            entity.Property(e => e.TpUsuarioSistema).HasColumnName("TP_USUARIO_SISTEMA");

            entity.HasOne(d => d.IdMantenedoraNavigation).WithMany(p => p.TabUsuarios)
                .HasForeignKey(d => d.IdMantenedora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TAB_USUARIO_dbo.TAB_MANTENEDORA_ID_MANTENEDORA");

            entity.HasOne(d => d.IdUsuarioAtualizacaoNavigation).WithMany(p => p.InverseIdUsuarioAtualizacaoNavigation)
                .HasForeignKey(d => d.IdUsuarioAtualizacao)
                .HasConstraintName("FK_dbo.TAB_USUARIO_dbo.TAB_USUARIO_ID_USUARIO_ATUALIZACAO");
        });

        #endregion

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
