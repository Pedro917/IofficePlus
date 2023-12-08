using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabTipoExpedienteNomeacao
{
    public string TipoExpediente { get; set; } = null!;

    public string DsExpedienteNomeacao { get; set; } = null!;

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();
}
