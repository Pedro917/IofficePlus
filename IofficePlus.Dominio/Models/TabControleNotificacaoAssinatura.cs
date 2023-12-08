using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabControleNotificacaoAssinatura
{
    public long IdControleNotificacaoAssinatura { get; set; }

    public long IdControleNotificacao { get; set; }

    public long IdAssinatura { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabAssinatura IdAssinaturaNavigation { get; set; } = null!;

    public virtual TabControleNotificacao IdControleNotificacaoNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabControleNotificacaoEvento> TabControleNotificacaoEventos { get; set; } = new List<TabControleNotificacaoEvento>();

    public virtual ICollection<TabNotificacao> TabNotificacaos { get; set; } = new List<TabNotificacao>();
}
