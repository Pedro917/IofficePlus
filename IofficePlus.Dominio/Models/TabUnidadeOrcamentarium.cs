using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabUnidadeOrcamentarium
{
    public long IdUnidadeOrcamentaria { get; set; }

    public string CdUnidadeOrcamentaria { get; set; } = null!;

    public string NmUnidadeOrcamentaria { get; set; } = null!;

    public long? CdOrcamentario { get; set; }

    public int NrExercicio { get; set; }

    public DateTime DtCriacaoUnidadeOrcamentaria { get; set; }

    public string? TipoAdministracao { get; set; }

    public long IdOrgao { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabOrgao IdOrgaoNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();

    public virtual ICollection<TabConcessaoItensRemuneratorio> TabConcessaoItensRemuneratorios { get; set; } = new List<TabConcessaoItensRemuneratorio>();

    public virtual ICollection<TabContaBancarium> TabContaBancaria { get; set; } = new List<TabContaBancarium>();

    public virtual ICollection<TabControleProcesso> TabControleProcessos { get; set; } = new List<TabControleProcesso>();

    public virtual ICollection<TabDesligamentoAgentePublico> TabDesligamentoAgentePublicos { get; set; } = new List<TabDesligamentoAgentePublico>();

    public virtual ICollection<TabOrdenadorDespesa> TabOrdenadorDespesas { get; set; } = new List<TabOrdenadorDespesa>();

    public virtual ICollection<TabReingressoAgentePublico> TabReingressoAgentePublicos { get; set; } = new List<TabReingressoAgentePublico>();

    public virtual ICollection<TabUnidadeGestora> TabUnidadeGestoras { get; set; } = new List<TabUnidadeGestora>();
}
