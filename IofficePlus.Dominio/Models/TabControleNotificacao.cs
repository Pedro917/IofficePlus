using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabControleNotificacao
{
    public long IdControleNotificacao { get; set; }

    public long IdEscritorio { get; set; }

    public long IdUnidadeGestora { get; set; }

    public long IdResponsavelEscritorio { get; set; }

    public byte SituacaoControleNotificacao { get; set; }

    public DateTime? DtNotificacao { get; set; }

    public DateTime? DtTransmissao { get; set; }

    public bool RealizarNotificacao { get; set; }

    public string TituloNotificacao { get; set; } = null!;

    public string? DsControleNotificacao { get; set; }

    public Guid? ControleId { get; set; }

    public DateTime? DtColetaTransmissao { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabResponsavelEscritorio IdResponsavelEscritorioNavigation { get; set; } = null!;

    public virtual TabUnidadeGestora IdUnidadeGestoraNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabControleNotificacaoAssinatura> TabControleNotificacaoAssinaturas { get; set; } = new List<TabControleNotificacaoAssinatura>();

    public virtual ICollection<TabControleNotificacaoDocumento> TabControleNotificacaoDocumentos { get; set; } = new List<TabControleNotificacaoDocumento>();

    public virtual ICollection<TabControleNotificacaoEvento> TabControleNotificacaoEventos { get; set; } = new List<TabControleNotificacaoEvento>();

    public virtual ICollection<TabNotificacao> TabNotificacaos { get; set; } = new List<TabNotificacao>();
}
