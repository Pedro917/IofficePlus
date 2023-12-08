using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabControladora
{
    public long IdControladora { get; set; }

    public byte TpPessoa { get; set; }

    public long IdMantenedora { get; set; }

    public string NmRazaoSocial { get; set; } = null!;

    public string NmFantasia { get; set; } = null!;

    public string? NrCnpj { get; set; }

    public string? NrCpf { get; set; }

    public string? NrTelefoneContato { get; set; }

    public string? NrTelefoneOutro { get; set; }

    public string? Email { get; set; }

    public byte TpLogradouro { get; set; }

    public string NmLogradouro { get; set; } = null!;

    public int NrLogradouro { get; set; }

    public string? NmBairro { get; set; }

    public int IdMunicipio { get; set; }

    public string NrCep { get; set; } = null!;

    public byte TpZona { get; set; }

    public string? Complemento { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabMantenedora IdMantenedoraNavigation { get; set; } = null!;

    public virtual TabMunicipio IdMunicipioNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabCliente> TabClientes { get; set; } = new List<TabCliente>();

    public virtual ICollection<TabEscritorio> TabEscritorios { get; set; } = new List<TabEscritorio>();

    public virtual ICollection<TabPublicacaoDocumento> TabPublicacaoDocumentos { get; set; } = new List<TabPublicacaoDocumento>();

    public virtual ICollection<TabResponsavelControladora> TabResponsavelControladoras { get; set; } = new List<TabResponsavelControladora>();

    public virtual ICollection<TabResponsavelEscritorio> TabResponsavelEscritorios { get; set; } = new List<TabResponsavelEscritorio>();
}
