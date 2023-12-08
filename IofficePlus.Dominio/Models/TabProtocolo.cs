using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabProtocolo
{
    public long IdProtocolo { get; set; }

    public long IdEscritorio { get; set; }

    public string? NumeroProtocolo { get; set; }

    public string NmDocumentoProtocolo { get; set; } = null!;

    public long? IdUnidadeGestora { get; set; }

    public long? IdOrgao { get; set; }

    public long? IdAssinatura { get; set; }

    public long? IdResponsavelEscritorioRecepcao { get; set; }

    public long? IdResponsavelEscritorioEntrega { get; set; }

    public string? DsProtocolo { get; set; }

    public DateTime DataControle { get; set; }

    public TimeSpan HorarioControle { get; set; }

    public byte TpTramitacaoProtocolo { get; set; }

    public byte TpProtocolo { get; set; }

    public byte TpProtocoloCliente { get; set; }

    public string? NmPessoaProtocolada { get; set; }

    public string? NmFuncaoPessoaProtocolada { get; set; }

    public string? NrCnpj { get; set; }

    public string? NrCpf { get; set; }

    public string? NmContatoEmpresa { get; set; }

    public string? NrTelefoneContato { get; set; }

    public string? Email { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabAssinatura? IdAssinaturaNavigation { get; set; }

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabOrgao? IdOrgaoNavigation { get; set; }

    public virtual TabResponsavelEscritorio? IdResponsavelEscritorioEntregaNavigation { get; set; }

    public virtual TabResponsavelEscritorio? IdResponsavelEscritorioRecepcaoNavigation { get; set; }

    public virtual TabUnidadeGestora? IdUnidadeGestoraNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabProtocoloDocumento> TabProtocoloDocumentos { get; set; } = new List<TabProtocoloDocumento>();
}
