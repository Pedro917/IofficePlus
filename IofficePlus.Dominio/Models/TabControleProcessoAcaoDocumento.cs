using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabControleProcessoAcaoDocumento
{
    public long IdControleProcessoAcaoDocumento { get; set; }

    public long IdControleProcessoAcao { get; set; }

    public string NmDocumento { get; set; } = null!;

    public string CaminhoCompletoDocumento { get; set; } = null!;

    public byte TpDocumento { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabControleProcessoAcao IdControleProcessoAcaoNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
