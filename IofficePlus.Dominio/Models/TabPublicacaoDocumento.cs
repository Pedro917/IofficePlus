using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabPublicacaoDocumento
{
    public long IdPublicacaoDocumento { get; set; }

    public long IdTribunal { get; set; }

    public long IdControladora { get; set; }

    public byte SituacaoProcessamento { get; set; }

    public DateTime? DtProcessamento { get; set; }

    public DateTime? DtDisponibilizacao { get; set; }

    public DateTime? DtPublicacao { get; set; }

    public int? NrPublicacao { get; set; }

    public int? AnoPublicacao { get; set; }

    public string NmDocumento { get; set; } = null!;

    public string CaminhoCompletoDocumento { get; set; } = null!;

    public Guid? IdentificadorLeitura { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabControladora IdControladoraNavigation { get; set; } = null!;

    public virtual TabTribunal IdTribunalNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }
}
