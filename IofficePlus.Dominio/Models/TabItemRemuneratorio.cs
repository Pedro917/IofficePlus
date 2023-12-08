using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabItemRemuneratorio
{
    public long IdItemRemuneratorio { get; set; }

    public long IdEntidadeAdministrativa { get; set; }

    public int CdItem { get; set; }

    public string? TpItem { get; set; }

    public string? DsItem { get; set; }

    public string? TpAmparoLegalOrigemItem { get; set; }

    public string? NrAmparoLegalOrigemItem { get; set; }

    public DateTime DtAmparoLegal { get; set; }

    public DateTime DtPublicacaoAmparoLegal { get; set; }

    public string? NrUltimaNormaLegalRegItem { get; set; }

    public DateTime DtNormaLegalRegItem { get; set; }

    public DateTime DtPublicacaoNormaLegalRegItem { get; set; }

    public string? ClassificacaoItem { get; set; }

    public int DtReferenciaDocumentacao { get; set; }

    public virtual TabEntidadeAdministrativa IdEntidadeAdministrativaNavigation { get; set; } = null!;
}
