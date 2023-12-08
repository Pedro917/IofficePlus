using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabUsuario
{
    public long IdUsuario { get; set; }

    public string NmUsuario { get; set; } = null!;

    public string Identificacao { get; set; } = null!;

    public string? NrTelefoneContato { get; set; }

    public string? NrTelefoneOutro { get; set; }

    public string Email { get; set; } = null!;

    public string SenhaUsuario { get; set; } = null!;

    public string CodigoAutenticacao { get; set; } = null!;

    public byte TpUsuarioSistema { get; set; }

    public byte[]? AvatarUsuario { get; set; }

    public long IdMantenedora { get; set; }

    public long? IdEscritorioConfigurado { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabMantenedora IdMantenedoraNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabUsuario> InverseIdUsuarioAtualizacaoNavigation { get; set; } = new List<TabUsuario>();

    public virtual ICollection<TabAcaoDocumento> TabAcaoDocumentos { get; set; } = new List<TabAcaoDocumento>();

    public virtual ICollection<TabAcao> TabAcaos { get; set; } = new List<TabAcao>();

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();

    public virtual ICollection<TabAtendimento> TabAtendimentos { get; set; } = new List<TabAtendimento>();

    public virtual ICollection<TabClienteDocumento> TabClienteDocumentos { get; set; } = new List<TabClienteDocumento>();

    public virtual ICollection<TabCliente> TabClienteIdUsuarioAtualizacaoNavigations { get; set; } = new List<TabCliente>();

    public virtual ICollection<TabCliente> TabClienteIdUsuarioSistemaNavigations { get; set; } = new List<TabCliente>();

    public virtual ICollection<TabContaBancarium> TabContaBancaria { get; set; } = new List<TabContaBancarium>();

    public virtual ICollection<TabControladora> TabControladoras { get; set; } = new List<TabControladora>();

    public virtual ICollection<TabControleNotificacaoAssinatura> TabControleNotificacaoAssinaturas { get; set; } = new List<TabControleNotificacaoAssinatura>();

    public virtual ICollection<TabControleNotificacaoDocumento> TabControleNotificacaoDocumentos { get; set; } = new List<TabControleNotificacaoDocumento>();

    public virtual ICollection<TabControleNotificacaoEvento> TabControleNotificacaoEventos { get; set; } = new List<TabControleNotificacaoEvento>();

    public virtual ICollection<TabControleNotificacao> TabControleNotificacaos { get; set; } = new List<TabControleNotificacao>();

    public virtual ICollection<TabControleProcessoAcaoDocumento> TabControleProcessoAcaoDocumentos { get; set; } = new List<TabControleProcessoAcaoDocumento>();

    public virtual ICollection<TabControleProcessoAcao> TabControleProcessoAcaos { get; set; } = new List<TabControleProcessoAcao>();

    public virtual ICollection<TabControleProcessoTramitacao> TabControleProcessoTramitacaos { get; set; } = new List<TabControleProcessoTramitacao>();

    public virtual ICollection<TabControleProcesso> TabControleProcessos { get; set; } = new List<TabControleProcesso>();

    public virtual ICollection<TabControleViagemDocumento> TabControleViagemDocumentos { get; set; } = new List<TabControleViagemDocumento>();

    public virtual ICollection<TabControleViagem> TabControleViagems { get; set; } = new List<TabControleViagem>();

    public virtual ICollection<TabEntidadeAdministrativa> TabEntidadeAdministrativas { get; set; } = new List<TabEntidadeAdministrativa>();

    public virtual ICollection<TabEscritorio> TabEscritorios { get; set; } = new List<TabEscritorio>();

    public virtual ICollection<TabMembroSetor> TabMembroSetors { get; set; } = new List<TabMembroSetor>();

    public virtual ICollection<TabMonitoramento> TabMonitoramentos { get; set; } = new List<TabMonitoramento>();

    public virtual ICollection<TabNotificacao> TabNotificacaos { get; set; } = new List<TabNotificacao>();

    public virtual ICollection<TabOcorrencium> TabOcorrencia { get; set; } = new List<TabOcorrencium>();

    public virtual ICollection<TabOrdenadorDespesa> TabOrdenadorDespesas { get; set; } = new List<TabOrdenadorDespesa>();

    public virtual ICollection<TabOrgao> TabOrgaos { get; set; } = new List<TabOrgao>();

    public virtual ICollection<TabPessoa> TabPessoas { get; set; } = new List<TabPessoa>();

    public virtual ICollection<TabProtocoloControle> TabProtocoloControles { get; set; } = new List<TabProtocoloControle>();

    public virtual ICollection<TabProtocoloDocumento> TabProtocoloDocumentos { get; set; } = new List<TabProtocoloDocumento>();

    public virtual ICollection<TabProtocolo> TabProtocolos { get; set; } = new List<TabProtocolo>();

    public virtual ICollection<TabPublicacaoDocumento> TabPublicacaoDocumentos { get; set; } = new List<TabPublicacaoDocumento>();

    public virtual ICollection<TabReingressoAgentePublico> TabReingressoAgentePublicos { get; set; } = new List<TabReingressoAgentePublico>();

    public virtual ICollection<TabResponsavelControladora> TabResponsavelControladoraIdUsuarioAtualizacaoNavigations { get; set; } = new List<TabResponsavelControladora>();

    public virtual ICollection<TabResponsavelControladora> TabResponsavelControladoraIdUsuarioSistemaNavigations { get; set; } = new List<TabResponsavelControladora>();

    public virtual ICollection<TabResponsavelEscritorio> TabResponsavelEscritorioIdUsuarioAtualizacaoNavigations { get; set; } = new List<TabResponsavelEscritorio>();

    public virtual ICollection<TabResponsavelEscritorio> TabResponsavelEscritorioIdUsuarioSistemaNavigations { get; set; } = new List<TabResponsavelEscritorio>();

    public virtual ICollection<TabSetor> TabSetors { get; set; } = new List<TabSetor>();

    public virtual ICollection<TabTarefa> TabTarefas { get; set; } = new List<TabTarefa>();

    public virtual ICollection<TabTribunal> TabTribunals { get; set; } = new List<TabTribunal>();

    public virtual ICollection<TabUnidadeGestora> TabUnidadeGestoras { get; set; } = new List<TabUnidadeGestora>();

    public virtual ICollection<TabUnidadeOrcamentarium> TabUnidadeOrcamentaria { get; set; } = new List<TabUnidadeOrcamentarium>();
}
