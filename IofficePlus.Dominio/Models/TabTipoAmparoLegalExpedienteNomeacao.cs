using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabTipoAmparoLegalExpedienteNomeacao
{
    public string TipoAmparo { get; set; } = null!;

    public string DsAmparoLegal { get; set; } = null!;

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();
}
