using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabOcupacao
{
    public int IdOcupacao { get; set; }

    public int CdOcupacao { get; set; }

    public string? DsOcupacao { get; set; }

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();
}
