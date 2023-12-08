using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabRecebimentoSim
{
    public long IdRecebimento { get; set; }

    public DateTime DtRecebimento { get; set; }

    public string? NmArquivoRecebido { get; set; }

    public string? LgRecebimento { get; set; }
}
