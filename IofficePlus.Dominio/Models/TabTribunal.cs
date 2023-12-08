using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabTribunal
{
    public long IdTribunal { get; set; }

    public string NmTribunal { get; set; } = null!;

    public string SiglaTribunal { get; set; } = null!;

    public string? UrlTribunal { get; set; }

    public byte TipoAtuacaoTribunal { get; set; }

    public string? Uf { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabMonitoramento> TabMonitoramentos { get; set; } = new List<TabMonitoramento>();

    public virtual ICollection<TabPublicacaoDocumento> TabPublicacaoDocumentos { get; set; } = new List<TabPublicacaoDocumento>();

    public virtual TabEstado? UfNavigation { get; set; }
}
