using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabOcorrencium
{
    public long IdOcorrencia { get; set; }

    public long IdAtendimento { get; set; }

    public byte SituacaoOcorrencia { get; set; }

    public DateTime DtOcorrencia { get; set; }

    public TimeSpan HorarioOcorrencia { get; set; }

    public DateTime? DtConclusao { get; set; }

    public string? Assunto { get; set; }

    public string? Descricao { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabAtendimento IdAtendimentoNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
