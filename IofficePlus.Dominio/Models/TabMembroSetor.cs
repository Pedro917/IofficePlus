using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabMembroSetor
{
    public long IdMembroSetor { get; set; }

    public long IdSetor { get; set; }

    public long IdResponsavelEscritorio { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabResponsavelEscritorio IdResponsavelEscritorioNavigation { get; set; } = null!;

    public virtual TabSetor IdSetorNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
