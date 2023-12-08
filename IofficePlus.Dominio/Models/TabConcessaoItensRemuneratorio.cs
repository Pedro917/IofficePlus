using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabConcessaoItensRemuneratorio
{
    public long IdConcessaoItens { get; set; }

    public long IdEntidadeAdministrativa { get; set; }

    public long? ExercicioOrcamento { get; set; }

    public long? IdOrgao { get; set; }

    public long? IdUnidadeOrcamentaria { get; set; }

    public string? NrCpfAgentePublico { get; set; }

    public string? FmIngressoServicoPublico { get; set; }

    public string? TpRelacaoServicoPublico { get; set; }

    public string? NrExpedienteNomeacaoPosse { get; set; }

    public int? CdItem { get; set; }

    public string? NrExpedienteConcessao { get; set; }

    public string? TpExpedienteConcessao { get; set; }

    public DateTime? DtExpedienteConcessao { get; set; }

    public DateTime? DtPublicacaoExpediente { get; set; }

    public int? DtReferenciaDocumentacao { get; set; }

    public virtual TabFormaIngressoServicoPublico? FmIngressoServicoPublicoNavigation { get; set; }

    public virtual TabEntidadeAdministrativa IdEntidadeAdministrativaNavigation { get; set; } = null!;

    public virtual TabOrgao? IdOrgaoNavigation { get; set; }

    public virtual TabUnidadeOrcamentarium? IdUnidadeOrcamentariaNavigation { get; set; }

    public virtual TabTipoRelacaoServicoPublico? TpRelacaoServicoPublicoNavigation { get; set; }
}
