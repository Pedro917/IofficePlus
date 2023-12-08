using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabMunicipio
{
    public int IdMunicipio { get; set; }

    public string NmMunicipio { get; set; } = null!;

    public string? CepMunicipio { get; set; }

    public string? CodigoIbge { get; set; }

    public string? CodigoTcm { get; set; }

    public string? Uf { get; set; }

    public virtual ICollection<TabControladora> TabControladoras { get; set; } = new List<TabControladora>();

    public virtual ICollection<TabEntidadeAdministrativa> TabEntidadeAdministrativas { get; set; } = new List<TabEntidadeAdministrativa>();

    public virtual ICollection<TabEscritorio> TabEscritorios { get; set; } = new List<TabEscritorio>();

    public virtual ICollection<TabMantenedora> TabMantenedoras { get; set; } = new List<TabMantenedora>();

    public virtual ICollection<TabMonitoramento> TabMonitoramentos { get; set; } = new List<TabMonitoramento>();

    public virtual ICollection<TabPessoa> TabPessoaIdMunicipioEleitorNavigations { get; set; } = new List<TabPessoa>();

    public virtual ICollection<TabPessoa> TabPessoaIdMunicipioNavigations { get; set; } = new List<TabPessoa>();

    public virtual TabEstado? UfNavigation { get; set; }
}
