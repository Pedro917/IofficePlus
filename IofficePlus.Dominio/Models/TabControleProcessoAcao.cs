using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabControleProcessoAcao
{
    public long IdControleProcessoAcao { get; set; }

    public string? DsControleProcessoAcao { get; set; }

    public long IdControleProcesso { get; set; }

    public long IdResponsavelEscritorioAcao { get; set; }

    public byte TpSituacaoAcao { get; set; }

    public DateTime DtInicioAcao { get; set; }

    public DateTime? DtFimAcao { get; set; }

    public DateTime DtPrevisaoFim { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabControleProcesso IdControleProcessoNavigation { get; set; } = null!;

    public virtual TabResponsavelEscritorio IdResponsavelEscritorioAcaoNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabControleProcessoAcaoDocumento> TabControleProcessoAcaoDocumentos { get; set; } = new List<TabControleProcessoAcaoDocumento>();

    public virtual ICollection<TabNotificacao> TabNotificacaos { get; set; } = new List<TabNotificacao>();
}
