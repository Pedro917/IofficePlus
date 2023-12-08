using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabMantenedora
{
    public long IdMantenedora { get; set; }

    public string NmRazaoSocial { get; set; } = null!;

    public string NmFantasia { get; set; } = null!;

    public string NrCnpj { get; set; } = null!;

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

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabMunicipio IdMunicipioNavigation { get; set; } = null!;

    public virtual ICollection<TabControladora> TabControladoras { get; set; } = new List<TabControladora>();

    public virtual ICollection<TabEscritorio> TabEscritorios { get; set; } = new List<TabEscritorio>();

    public virtual ICollection<TabUsuario> TabUsuarios { get; set; } = new List<TabUsuario>();
}
