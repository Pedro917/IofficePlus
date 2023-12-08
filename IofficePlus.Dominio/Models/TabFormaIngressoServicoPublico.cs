using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabFormaIngressoServicoPublico
{
    public string FormaIngresso { get; set; } = null!;

    public string DsIngresso { get; set; } = null!;

    public virtual ICollection<TabAgentePublico> TabAgentePublicos { get; set; } = new List<TabAgentePublico>();

    public virtual ICollection<TabAssinatura> TabAssinaturas { get; set; } = new List<TabAssinatura>();

    public virtual ICollection<TabConcessaoItensRemuneratorio> TabConcessaoItensRemuneratorios { get; set; } = new List<TabConcessaoItensRemuneratorio>();

    public virtual ICollection<TabDesligamentoAgentePublico> TabDesligamentoAgentePublicos { get; set; } = new List<TabDesligamentoAgentePublico>();

    public virtual ICollection<TabOrdenadorDespesa> TabOrdenadorDespesas { get; set; } = new List<TabOrdenadorDespesa>();

    public virtual ICollection<TabReingressoAgentePublico> TabReingressoAgentePublicos { get; set; } = new List<TabReingressoAgentePublico>();
}
