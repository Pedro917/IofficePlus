using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabControleProcesso
{
    public long IdControleProcesso { get; set; }

    public long IdEscritorio { get; set; }

    public string? NumeroProcesso { get; set; }

    public byte TpConta { get; set; }

    public long IdUnidadeGestora { get; set; }

    public long? IdUnidadeOrcamentaria { get; set; }

    public long IdAssinatura { get; set; }

    public DateTime DataPublicacaoDoe { get; set; }

    public DateTime DataPrazo { get; set; }

    public long IdResponsavelEscritorio { get; set; }

    public string? DsControleProcesso { get; set; }

    public int NrExercicio { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabAssinatura IdAssinaturaNavigation { get; set; } = null!;

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabResponsavelEscritorio IdResponsavelEscritorioNavigation { get; set; } = null!;

    public virtual TabUnidadeGestora IdUnidadeGestoraNavigation { get; set; } = null!;

    public virtual TabUnidadeOrcamentarium? IdUnidadeOrcamentariaNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabControleProcessoAcao> TabControleProcessoAcaos { get; set; } = new List<TabControleProcessoAcao>();

    public virtual ICollection<TabControleProcessoTramitacao> TabControleProcessoTramitacaos { get; set; } = new List<TabControleProcessoTramitacao>();
}
