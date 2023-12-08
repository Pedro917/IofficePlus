using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabProtocoloDocumento
{
    public long IdProtocoloDocumento { get; set; }

    public long IdProtocolo { get; set; }

    public string NmDocumento { get; set; } = null!;

    public string CaminhoCompletoDocumento { get; set; } = null!;

    public byte TpDocumento { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabProtocolo IdProtocoloNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
