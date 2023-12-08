using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabTarefa
{
    public long IdTarefa { get; set; }

    public long IdEscritorio { get; set; }

    public string TituloTarefa { get; set; } = null!;

    public string? DsTarefa { get; set; }

    public byte TpTarefa { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAcao> TabAcaos { get; set; } = new List<TabAcao>();
}
