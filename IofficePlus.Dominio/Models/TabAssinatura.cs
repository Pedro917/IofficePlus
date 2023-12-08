using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabAssinatura
{
    public long IdAssinatura { get; set; }

    public long IdEntidadeAdministrativa { get; set; }

    public int NrExercicio { get; set; }

    public long IdUnidadeGestora { get; set; }

    public long IdOrgao { get; set; }

    public long IdUnidadeOrcamentaria { get; set; }

    public string? NrCpf { get; set; }

    public long IdAgentePublico { get; set; }

    public string? FormaIngresso { get; set; }

    public string? TipoRelacao { get; set; }

    public string? NrExpediente { get; set; }

    public DateTime DtInicioVigencia { get; set; }

    public int DtRefDocumentacao { get; set; }

    public DateTime? DtFimVigencia { get; set; }

    public string? CdTipoCargo { get; set; }

    public string? ObsAssinatura { get; set; }

    public string? NrAmparo { get; set; }

    public DateTime? DtAmparo { get; set; }

    public string? TipoAmparo { get; set; }

    public DateTime? DtPublicacaoAmparo { get; set; }

    public DateTime? DtExpediente { get; set; }

    public string? TipoExpediente { get; set; }

    public bool OrndenadorDespesas { get; set; }

    public DateTime? DtInicioVigenciaCertificado { get; set; }

    public DateTime? DtFimVigenciaCertificado { get; set; }

    public string? NrCertificado { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabTipoCargo? CdTipoCargoNavigation { get; set; }

    public virtual TabFormaIngressoServicoPublico? FormaIngressoNavigation { get; set; }

    public virtual TabAgentePublico IdAgentePublicoNavigation { get; set; } = null!;

    public virtual TabEntidadeAdministrativa IdEntidadeAdministrativaNavigation { get; set; } = null!;

    public virtual TabOrgao IdOrgaoNavigation { get; set; } = null!;

    public virtual TabUnidadeGestora IdUnidadeGestoraNavigation { get; set; } = null!;

    public virtual TabUnidadeOrcamentarium IdUnidadeOrcamentariaNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAtendimento> TabAtendimentos { get; set; } = new List<TabAtendimento>();

    public virtual ICollection<TabControleNotificacaoAssinatura> TabControleNotificacaoAssinaturas { get; set; } = new List<TabControleNotificacaoAssinatura>();

    public virtual ICollection<TabControleProcesso> TabControleProcessos { get; set; } = new List<TabControleProcesso>();

    public virtual ICollection<TabProtocolo> TabProtocolos { get; set; } = new List<TabProtocolo>();

    public virtual TabTipoAmparoLegalExpedienteNomeacao? TipoAmparoNavigation { get; set; }

    public virtual TabTipoExpedienteNomeacao? TipoExpedienteNavigation { get; set; }

    public virtual TabTipoRelacaoServicoPublico? TipoRelacaoNavigation { get; set; }
}
