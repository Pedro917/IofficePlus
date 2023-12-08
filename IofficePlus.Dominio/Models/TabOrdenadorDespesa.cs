using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabOrdenadorDespesa
{
    public long IdOrdenador { get; set; }

    public long IdEntidadeAdministrativa { get; set; }

    public int NrExercicio { get; set; }

    public long IdUnidadeGestora { get; set; }

    public long IdOrgao { get; set; }

    public long IdUnidadeOrcamentaria { get; set; }

    public DateTime DtIncUnidadeOrcamentaria { get; set; }

    public long IdAgentePublico { get; set; }

    public string? CdFormaIngresso { get; set; }

    public string? CdTipoRelacao { get; set; }

    public string? NrExpedienteNomeacao { get; set; }

    public DateTime DtInicioGestao { get; set; }

    public int DtReferenciaDocumentacao { get; set; }

    public DateTime? DtFimGestao { get; set; }

    public string? CdTipoCargo { get; set; }

    public string? NrCpf { get; set; }

    public string? NmOrdenador { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabFormaIngressoServicoPublico? CdFormaIngressoNavigation { get; set; }

    public virtual TabTipoCargo? CdTipoCargoNavigation { get; set; }

    public virtual TabTipoRelacaoServicoPublico? CdTipoRelacaoNavigation { get; set; }

    public virtual TabAgentePublico IdAgentePublicoNavigation { get; set; } = null!;

    public virtual TabEntidadeAdministrativa IdEntidadeAdministrativaNavigation { get; set; } = null!;

    public virtual TabOrgao IdOrgaoNavigation { get; set; } = null!;

    public virtual TabUnidadeGestora IdUnidadeGestoraNavigation { get; set; } = null!;

    public virtual TabUnidadeOrcamentarium IdUnidadeOrcamentariaNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
