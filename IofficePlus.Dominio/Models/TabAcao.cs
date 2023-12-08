using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabAcao
{
    public long IdAcao { get; set; }

    public string? DsAcao { get; set; }

    public long IdTarefa { get; set; }

    public long IdResponsavelEscritorioAcao { get; set; }

    public long? IdUnidadeGestora { get; set; }

    public long? IdAgentePublico { get; set; }

    public byte TpSituacaoAcao { get; set; }

    public DateTime DtInicioAcao { get; set; }

    public DateTime? DtFimAcao { get; set; }

    public DateTime DtPrevisaoFim { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabAgentePublico? IdAgentePublicoNavigation { get; set; }

    public virtual TabResponsavelEscritorio IdResponsavelEscritorioAcaoNavigation { get; set; } = null!;

    public virtual TabTarefa IdTarefaNavigation { get; set; } = null!;

    public virtual TabUnidadeGestora? IdUnidadeGestoraNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAcaoDocumento> TabAcaoDocumentos { get; set; } = new List<TabAcaoDocumento>();

    public virtual ICollection<TabNotificacao> TabNotificacaos { get; set; } = new List<TabNotificacao>();
}
