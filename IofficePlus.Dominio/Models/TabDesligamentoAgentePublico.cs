using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabDesligamentoAgentePublico
{
    public long IdDesligamentoAgentePublico { get; set; }

    public long? IdEntidadeAdministrativa { get; set; }

    public long? ExercicioOrcamento { get; set; }

    public long? IdOrgao { get; set; }

    public long? IdUnidadeOrcamentaria { get; set; }

    public string? NrCpfAgentePublic { get; set; }

    public string? IdFormaIngressoServicoPublico { get; set; }

    public string? IdTipoRelacaoServicoPublico { get; set; }

    public string? NrExpedienteNomeacaoPosse { get; set; }

    public string? NrExpedienteDesligamento { get; set; }

    public byte TpDesligamento { get; set; }

    public string? TpExpedienteDesligamento { get; set; }

    public DateTime? DtExpedienteDesligamento { get; set; }

    public DateTime? DtPublicacaoExpedienteDesligamento { get; set; }

    public string? NrCpfPensionista { get; set; }

    public string? NmPensionista { get; set; }

    public string? EnderecoCompleto { get; set; }

    public string? TlPensionista { get; set; }

    public long? DtReferenciaDocumentacao { get; set; }

    public virtual TabEntidadeAdministrativa? IdEntidadeAdministrativaNavigation { get; set; }

    public virtual TabFormaIngressoServicoPublico? IdFormaIngressoServicoPublicoNavigation { get; set; }

    public virtual TabOrgao? IdOrgaoNavigation { get; set; }

    public virtual TabTipoRelacaoServicoPublico? IdTipoRelacaoServicoPublicoNavigation { get; set; }

    public virtual TabUnidadeOrcamentarium? IdUnidadeOrcamentariaNavigation { get; set; }
}
