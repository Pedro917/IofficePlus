using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabMonitoramento
{
    public long IdMonitoramento { get; set; }

    public long IdTribunal { get; set; }

    public long IdEscritorio { get; set; }

    public int? IdMunicipio { get; set; }

    public string? Uf { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabMunicipio? IdMunicipioNavigation { get; set; }

    public virtual TabTribunal IdTribunalNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual TabEstado? UfNavigation { get; set; }
}
