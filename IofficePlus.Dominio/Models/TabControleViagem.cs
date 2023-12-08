using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabControleViagem
{
    public long IdControleViagem { get; set; }

    public long IdEscritorio { get; set; }

    public long IdResponsavelEscritorio { get; set; }

    public long IdEntidadeAdministrativa { get; set; }

    public DateTime DataViagem { get; set; }

    public string? Objetivo { get; set; }

    public string? DsViagem { get; set; }

    public byte SituacaoViagem { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEntidadeAdministrativa IdEntidadeAdministrativaNavigation { get; set; } = null!;

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabResponsavelEscritorio IdResponsavelEscritorioNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabControleViagemDocumento> TabControleViagemDocumentos { get; set; } = new List<TabControleViagemDocumento>();
}
