using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabTipoCargo
{
    public string CodigoTipo { get; set; } = null!;

    public string DsCargo { get; set; } = null!;

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();

    public virtual ICollection<TabOrdenadorDespesa> TabOrdenadorDespesas { get; set; } = new List<TabOrdenadorDespesa>();
}
