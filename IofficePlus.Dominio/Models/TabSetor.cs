using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabSetor
{
    public long IdSetor { get; set; }

    public string NmSetor { get; set; } = null!;

    public string? Email { get; set; }

    public long IdEscritorio { get; set; }

    public long? IdResponsavelEscritorio { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabResponsavelEscritorio? IdResponsavelEscritorioNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabMembroSetor> TabMembroSetors { get; set; } = new List<TabMembroSetor>();
}
