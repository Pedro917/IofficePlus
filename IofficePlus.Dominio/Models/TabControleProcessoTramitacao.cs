using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabControleProcessoTramitacao
{
    public long IdControleProcessoTramitacao { get; set; }

    public DateTime DtTramitacao { get; set; }

    public string? DsFinalidade { get; set; }

    public long IdControleProcesso { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabControleProcesso IdControleProcessoNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
