using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabEntidadeAdministrativa
{
    public long IdEntidadeAdministrativa { get; set; }

    public string NmEntidadeAdministrativa { get; set; } = null!;

    public string NrCnpjEntidadeAdministrativa { get; set; } = null!;

    public long? CdEntidadeAdministrativa { get; set; }

    public byte TpUnidadeAdministrativa { get; set; }

    public long IdEscritorio { get; set; }

    public byte TpLogradouro { get; set; }

    public string NmLogradouro { get; set; } = null!;

    public int NrLogradouro { get; set; }

    public string? NmBairro { get; set; }

    public int IdMunicipio { get; set; }

    public string NrCep { get; set; } = null!;

    public byte TpZona { get; set; }

    public string? Complemento { get; set; }

    public string? NrTelefoneContato { get; set; }

    public string? NrTelefoneOutro { get; set; }

    public string? Email { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabMunicipio IdMunicipioNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();

    public virtual ICollection<TabAtendimento> TabAtendimentos { get; set; } = new List<TabAtendimento>();

    public virtual ICollection<TabConcessaoItensRemuneratorio> TabConcessaoItensRemuneratorios { get; set; } = new List<TabConcessaoItensRemuneratorio>();

    public virtual ICollection<TabContaBancarium> TabContaBancaria { get; set; } = new List<TabContaBancarium>();

    public virtual ICollection<TabControleViagem> TabControleViagems { get; set; } = new List<TabControleViagem>();

    public virtual ICollection<TabDesligamentoAgentePublico> TabDesligamentoAgentePublicos { get; set; } = new List<TabDesligamentoAgentePublico>();

    public virtual ICollection<TabItemRemuneratorio> TabItemRemuneratorios { get; set; } = new List<TabItemRemuneratorio>();

    public virtual ICollection<TabOrdenadorDespesa> TabOrdenadorDespesas { get; set; } = new List<TabOrdenadorDespesa>();

    public virtual ICollection<TabOrgao> TabOrgaos { get; set; } = new List<TabOrgao>();

    public virtual ICollection<TabReingressoAgentePublico> TabReingressoAgentePublicos { get; set; } = new List<TabReingressoAgentePublico>();

    public virtual ICollection<TabUnidadeGestora> TabUnidadeGestoras { get; set; } = new List<TabUnidadeGestora>();
}
