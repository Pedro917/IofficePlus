using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabUnidadeGestora
{
    public long IdUnidadeGestora { get; set; }

    public long IdEntidadeAdministrativa { get; set; }

    public int NrExercicio { get; set; }

    public string CdUnidadeGestora { get; set; } = null!;

    public long IdOrgao { get; set; }

    public long IdUnidadeOrcamentaria { get; set; }

    public DateTime DtIncUnorcamentUngestora { get; set; }

    public int DtRefDocumentacao { get; set; }

    public string NmUnidadeGestora { get; set; } = null!;

    public DateTime DtCriacaoUnidadeGestora { get; set; }

    public string? ReferenciaLei { get; set; }

    public long? CdOrcamentario { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEntidadeAdministrativa IdEntidadeAdministrativaNavigation { get; set; } = null!;

    public virtual TabOrgao IdOrgaoNavigation { get; set; } = null!;

    public virtual TabUnidadeOrcamentarium IdUnidadeOrcamentariaNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAcao> TabAcaos { get; set; } = new List<TabAcao>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();

    public virtual ICollection<TabAtendimento> TabAtendimentos { get; set; } = new List<TabAtendimento>();

    public virtual ICollection<TabControleNotificacao> TabControleNotificacaos { get; set; } = new List<TabControleNotificacao>();

    public virtual ICollection<TabControleProcesso> TabControleProcessos { get; set; } = new List<TabControleProcesso>();

    public virtual ICollection<TabOrdenadorDespesa> TabOrdenadorDespesas { get; set; } = new List<TabOrdenadorDespesa>();

    public virtual ICollection<TabProtocolo> TabProtocolos { get; set; } = new List<TabProtocolo>();
}
