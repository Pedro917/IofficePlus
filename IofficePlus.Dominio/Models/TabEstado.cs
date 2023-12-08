using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabEstado
{
    public string Uf { get; set; } = null!;

    public string NmEstado { get; set; } = null!;

    public virtual ICollection<TabMonitoramento> TabMonitoramentos { get; set; } = new List<TabMonitoramento>();

    public virtual ICollection<TabMunicipio> TabMunicipios { get; set; } = new List<TabMunicipio>();

    public virtual ICollection<TabPessoa> TabPessoas { get; set; } = new List<TabPessoa>();

    public virtual ICollection<TabTribunal> TabTribunals { get; set; } = new List<TabTribunal>();
}
