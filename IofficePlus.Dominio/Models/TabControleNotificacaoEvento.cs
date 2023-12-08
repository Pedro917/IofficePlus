using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabControleNotificacaoEvento
{
    public long IdControleNotificacaoEvento { get; set; }

    public byte TpControleNotificacaoEvento { get; set; }

    public DateTime DtEvento { get; set; }

    public long IdControleNotificacao { get; set; }

    public long? IdControleNotificacaoAssinatura { get; set; }

    public long? IdControleNotificacaoDocumento { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabControleNotificacaoAssinatura? IdControleNotificacaoAssinaturaNavigation { get; set; }

    public virtual TabControleNotificacaoDocumento? IdControleNotificacaoDocumentoNavigation { get; set; }

    public virtual TabControleNotificacao IdControleNotificacaoNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
