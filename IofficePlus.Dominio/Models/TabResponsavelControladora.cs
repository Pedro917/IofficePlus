using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabResponsavelControladora
{
    public long IdResponsavelControladora { get; set; }

    public long IdPessoa { get; set; }

    public long IdControladora { get; set; }

    public long? IdUsuarioSistema { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabControladora IdControladoraNavigation { get; set; } = null!;

    public virtual TabPessoa IdPessoaNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioSistemaNavigation { get; set; }
}
