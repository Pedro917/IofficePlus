using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabContaBancarium
{
    public long IdConta { get; set; }

    public long IdEntidadeAdministrativa { get; set; }

    public int? NrExercicio { get; set; }

    public long? IdOrgao { get; set; }

    public long? IdUnidadeOrcamentaria { get; set; }

    public string NrBanco { get; set; } = null!;

    public string NrAgencia { get; set; } = null!;

    public string NrConta { get; set; } = null!;

    public int DtRefDocumentacao { get; set; }

    public DateTime DtAbertura { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabEntidadeAdministrativa IdEntidadeAdministrativaNavigation { get; set; } = null!;

    public virtual TabOrgao? IdOrgaoNavigation { get; set; }

    public virtual TabUnidadeOrcamentarium? IdUnidadeOrcamentariaNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
