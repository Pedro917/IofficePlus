using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabPessoa
{
    public long IdPessoa { get; set; }

    public byte TpVinculacao { get; set; }

    public string NmPessoa { get; set; } = null!;

    public string? NmApelido { get; set; }

    public string? NrCnpj { get; set; }

    public string? NrCpf { get; set; }

    public byte? TpSexo { get; set; }

    public DateTime? DtNascimento { get; set; }

    public byte? TpEstadoCivil { get; set; }

    public byte? TpGrauInstrucao { get; set; }

    public string? DsNaturalidade { get; set; }

    public string? DsNacionalidade { get; set; }

    public string? NmCompletoMae { get; set; }

    public string? NmCompletoPai { get; set; }

    public string? NmCompletoConjuge { get; set; }

    public string? NrCpfConjuge { get; set; }

    public string? NrRg { get; set; }

    public DateTime? DtExpedicaoRg { get; set; }

    public string? SiglaOrgaoEmissorRg { get; set; }

    public string? UfRg { get; set; }

    public string? NrPisPasep { get; set; }

    public string? NrTituloEleitor { get; set; }

    public short? NrZonaEleitor { get; set; }

    public short? NrSecaoEleitor { get; set; }

    public int? IdMunicipioEleitor { get; set; }

    public string? NrCtps { get; set; }

    public string? SerieCtps { get; set; }

    public string? NrTelefoneFixoResidencial { get; set; }

    public string? NrTelefoneFixoComercial { get; set; }

    public string? NrTelefoneCelularPrimario { get; set; }

    public string? NrTelefoneOutroCelular { get; set; }

    public string? Email { get; set; }

    public long? NrMatricula { get; set; }

    public DateTime? DtAdmissao { get; set; }

    public string? Biometria { get; set; }

    public string? NrNis { get; set; }

    public string? DadosAdicionais { get; set; }

    public byte? TpLogradouro { get; set; }

    public string? NmLogradouro { get; set; }

    public int? NrLogradouro { get; set; }

    public string? NmBairro { get; set; }

    public int? IdMunicipio { get; set; }

    public string? NrCep { get; set; }

    public string? EnderecoCompleto { get; set; }

    public byte? TpZona { get; set; }

    public string? Complemento { get; set; }

    public string? NumeroOab { get; set; }

    public string? SeccionalUf { get; set; }

    public byte? TpInscricaoSeccional { get; set; }

    public string? NumeroCrc { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabMunicipio? IdMunicipioEleitorNavigation { get; set; }

    public virtual TabMunicipio? IdMunicipioNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabCliente> TabClientes { get; set; } = new List<TabCliente>();

    public virtual ICollection<TabResponsavelControladora> TabResponsavelControladoras { get; set; } = new List<TabResponsavelControladora>();

    public virtual ICollection<TabResponsavelEscritorio> TabResponsavelEscritorios { get; set; } = new List<TabResponsavelEscritorio>();

    public virtual TabEstado? UfRgNavigation { get; set; }
}
