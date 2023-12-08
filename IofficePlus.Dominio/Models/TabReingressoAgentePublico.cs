using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabReingressoAgentePublico
{
    public long IdRap { get; set; }

    public long IdEntidadeAdministrativa { get; set; }

    public long ExercicioOrcamento { get; set; }

    public long IdOrgao { get; set; }

    public long IdUnidadeOrcamentaria { get; set; }

    public string? CpfAgentePublico { get; set; }

    public string? IdFormaIngressoServicoPublico { get; set; }

    public string? IdTipoRelacaoServicoPublico { get; set; }

    public string? NrExpedienteNomeacao { get; set; }

    public string? NrExpedienteDesligamento { get; set; }

    public string? NrExpedienteReingresso { get; set; }

    public string? TpReingresso { get; set; }

    public string? TpExpedienteReingresso { get; set; }

    public DateTime DtPublicacaoExpedienteReingresso { get; set; }

    public string? TpAmparoLegalExpedienteReingresso { get; set; }

    public string? NrAmparoLegalExpedienteReingresso { get; set; }

    public DateTime DtAmparoLegalExpedienteReingresso { get; set; }

    public DateTime DtPublicacaoAmparoLegalExpedienteReingresso { get; set; }

    public long DtReferenciaDocumentacao { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEntidadeAdministrativa IdEntidadeAdministrativaNavigation { get; set; } = null!;

    public virtual TabFormaIngressoServicoPublico? IdFormaIngressoServicoPublicoNavigation { get; set; }

    public virtual TabOrgao IdOrgaoNavigation { get; set; } = null!;

    public virtual TabTipoRelacaoServicoPublico? IdTipoRelacaoServicoPublicoNavigation { get; set; }

    public virtual TabUnidadeOrcamentarium IdUnidadeOrcamentariaNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
