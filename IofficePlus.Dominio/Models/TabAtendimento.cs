using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabAtendimento
{
    public long IdAtendimento { get; set; }

    public byte TpAtendimentoEntidadeAdministrativa { get; set; }

    public byte TpAtendimentoEntidadeAdministrativaCliente { get; set; }

    public byte TpCanalAtendimento { get; set; }

    public long IdEscritorio { get; set; }

    public long IdResponsavelEscritorio { get; set; }

    public long? IdEntidadeAdministrativa { get; set; }

    public long? IdUnidadeGestora { get; set; }

    public long? IdOrgao { get; set; }

    public long? IdAssinatura { get; set; }

    public DateTime DataAtendimento { get; set; }

    public TimeSpan HorarioAtendimento { get; set; }

    public string? Observacao { get; set; }

    public string? NmPessoaIndicada { get; set; }

    public string? NmFuncaoPessoaIndicada { get; set; }

    public string? NrCnpj { get; set; }

    public string? NrCpf { get; set; }

    public string? NrTelefoneContato { get; set; }

    public string? Email { get; set; }

    public string? DsCanalAtendimento { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabAssinatura? IdAssinaturaNavigation { get; set; }

    public virtual TabEntidadeAdministrativa? IdEntidadeAdministrativaNavigation { get; set; }

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabOrgao? IdOrgaoNavigation { get; set; }

    public virtual TabResponsavelEscritorio IdResponsavelEscritorioNavigation { get; set; } = null!;

    public virtual TabUnidadeGestora? IdUnidadeGestoraNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabOcorrencium> TabOcorrencia { get; set; } = new List<TabOcorrencium>();
}
