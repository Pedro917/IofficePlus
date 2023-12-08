using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabProtocoloControle
{
    public long IdProtocoloControle { get; set; }

    public long IdEscritorio { get; set; }

    public DateTime DataControle { get; set; }

    public byte TpTramitacaoProtocolo { get; set; }

    public int SequenciaControle { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
