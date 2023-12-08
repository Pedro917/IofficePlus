using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabAgentePublico
{
    public long IdAgentePublico { get; set; }

    public long? IdEntidadeAdministrativa { get; set; }

    public int NrExercicio { get; set; }

    public long? IdOrgao { get; set; }

    public long? IdUnidadeOrcamentaria { get; set; }

    public long? IdPessoa { get; set; }

    public string? NrCpf { get; set; }

    public long IdControladora { get; set; }

    public string NrExpedienteNomeacao { get; set; } = null!;

    public string? TpExpedienteNomeacao { get; set; }

    public DateTime DtExpedienteNomeacao { get; set; }

    public string? TpAmparoLegal { get; set; }

    public string NrAmparoLegal { get; set; } = null!;

    public DateTime DtAmaparoLegal { get; set; }

    public DateTime DtPubAmparoLegal { get; set; }

    public DateTime DtPosse { get; set; }

    public string NrMatriculaMunicipal { get; set; } = null!;

    public byte StFuncional { get; set; }

    public string? TpRegimeJuridico { get; set; }

    public string? TpRegimePrevidenciario { get; set; }

    public int? IdOcupacao { get; set; }

    public string? CdTipoCargo { get; set; }

    public int CargaHorariaSemanal { get; set; }

    public byte TpPrograma { get; set; }

    public int? NrDependentes { get; set; }

    public int? DtRefDocumentacao { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public string FormaIngressoServicoPublicoFormaIngresso { get; set; } = null!;

    public string TipoRelacaoServicoPublicoTipoRelacao { get; set; } = null!;

    public virtual TabTipoCargo? CdTipoCargoNavigation { get; set; }

    public virtual TabFormaIngressoServicoPublico FormaIngressoServicoPublicoFormaIngressoNavigation { get; set; } = null!;

    public virtual TabControladora IdControladoraNavigation { get; set; } = null!;

    public virtual TabEntidadeAdministrativa? IdEntidadeAdministrativaNavigation { get; set; }

    public virtual TabOcupacao? IdOcupacaoNavigation { get; set; }

    public virtual TabOrgao? IdOrgaoNavigation { get; set; }

    public virtual TabPessoa? IdPessoaNavigation { get; set; }

    public virtual TabUnidadeOrcamentarium? IdUnidadeOrcamentariaNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAcao> TabAcaos { get; set; } = new List<TabAcao>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();

    public virtual ICollection<TabOrdenadorDespesa> TabOrdenadorDespesas { get; set; } = new List<TabOrdenadorDespesa>();

    public virtual TabTipoRelacaoServicoPublico TipoRelacaoServicoPublicoTipoRelacaoNavigation { get; set; } = null!;

    public virtual TabTipoAmparoLegalExpedienteNomeacao? TpAmparoLegalNavigation { get; set; }

    public virtual TabTipoExpedienteNomeacao? TpExpedienteNomeacaoNavigation { get; set; }

    public virtual TabRegimeJuridicoRelacaoFuncional? TpRegimeJuridicoNavigation { get; set; }

    public virtual TabRegimePrevidenciario? TpRegimePrevidenciarioNavigation { get; set; }
}
