using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabNotificacao
{
    public long IdNotificacao { get; set; }

    public long? IdAcao { get; set; }

    public long? IdControleProcessoAcao { get; set; }

    public long? IdControleNotificacao { get; set; }

    public long? IdControleNotificacaoAssinatura { get; set; }

    public byte TpNotificacao { get; set; }

    public Guid? NotificacaoId { get; set; }

    public Guid? ControleId { get; set; }

    public byte TpSituacaoNotificacao { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabAcao? IdAcaoNavigation { get; set; }

    public virtual TabControleNotificacaoAssinatura? IdControleNotificacaoAssinaturaNavigation { get; set; }

    public virtual TabControleNotificacao? IdControleNotificacaoNavigation { get; set; }

    public virtual TabControleProcessoAcao? IdControleProcessoAcaoNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
