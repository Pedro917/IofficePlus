using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabRegimeJuridicoRelacaoFuncional
{
    public string TpRegime { get; set; } = null!;

    public string DsRegime { get; set; } = null!;

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();
}
