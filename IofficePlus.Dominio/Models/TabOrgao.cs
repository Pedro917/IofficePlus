using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabOrgao
{
    public long IdOrgao { get; set; }

    public string? CdMunicipio { get; set; }

    public int NrExercicio { get; set; }

    public string CdOrgao { get; set; } = null!;

    public byte TpUnidadeAdministrativa { get; set; }

    public string NmOrgao { get; set; } = null!;

    public string? CnpjOrgao { get; set; }

    public string? EnderecoOrgao { get; set; }

    public string? CepOrgao { get; set; }

    public string? TelOrgao { get; set; }

    public string? EmailOrgao { get; set; }

    public long? CdOrcamentario { get; set; }

    public string? DsOrgao { get; set; }

    public DateTime DtCriacaoOrgao { get; set; }

    public string? ReferenciaLei { get; set; }

    public long IdEntidadeAdministrativa { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEntidadeAdministrativa IdEntidadeAdministrativaNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();

    public virtual ICollection<TabAtendimento> TabAtendimentos { get; set; } = new List<TabAtendimento>();

    public virtual ICollection<TabConcessaoItensRemuneratorio> TabConcessaoItensRemuneratorios { get; set; } = new List<TabConcessaoItensRemuneratorio>();

    public virtual ICollection<TabContaBancarium> TabContaBancaria { get; set; } = new List<TabContaBancarium>();

    public virtual ICollection<TabDesligamentoAgentePublico> TabDesligamentoAgentePublicos { get; set; } = new List<TabDesligamentoAgentePublico>();

    public virtual ICollection<TabOrdenadorDespesa> TabOrdenadorDespesas { get; set; } = new List<TabOrdenadorDespesa>();

    public virtual ICollection<TabProtocolo> TabProtocolos { get; set; } = new List<TabProtocolo>();

    public virtual ICollection<TabReingressoAgentePublico> TabReingressoAgentePublicos { get; set; } = new List<TabReingressoAgentePublico>();

    public virtual ICollection<TabUnidadeGestora> TabUnidadeGestoras { get; set; } = new List<TabUnidadeGestora>();

    public virtual ICollection<TabUnidadeOrcamentarium> TabUnidadeOrcamentaria { get; set; } = new List<TabUnidadeOrcamentarium>();
}
