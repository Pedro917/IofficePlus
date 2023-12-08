using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabResponsavelEscritorio
{
    public long IdResponsavelEscritorio { get; set; }

    public byte TpFuncionario { get; set; }

    public long IdPessoa { get; set; }

    public long IdControladora { get; set; }

    public long? IdUsuarioSistema { get; set; }

    public long IdEscritorio { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabControladora IdControladoraNavigation { get; set; } = null!;

    public virtual TabEscritorio IdEscritorioNavigation { get; set; } = null!;

    public virtual TabPessoa IdPessoaNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual TabUsuario? IdUsuarioSistemaNavigation { get; set; }

    public virtual ICollection<TabAcao> TabAcaos { get; set; } = new List<TabAcao>();

    public virtual ICollection<TabAtendimento> TabAtendimentos { get; set; } = new List<TabAtendimento>();

    public virtual ICollection<TabControleNotificacao> TabControleNotificacaos { get; set; } = new List<TabControleNotificacao>();

    public virtual ICollection<TabControleProcessoAcao> TabControleProcessoAcaos { get; set; } = new List<TabControleProcessoAcao>();

    public virtual ICollection<TabControleProcesso> TabControleProcessos { get; set; } = new List<TabControleProcesso>();

    public virtual ICollection<TabControleViagem> TabControleViagems { get; set; } = new List<TabControleViagem>();

    public virtual ICollection<TabMembroSetor> TabMembroSetors { get; set; } = new List<TabMembroSetor>();

    public virtual ICollection<TabProtocolo> TabProtocoloIdResponsavelEscritorioEntregaNavigations { get; set; } = new List<TabProtocolo>();

    public virtual ICollection<TabProtocolo> TabProtocoloIdResponsavelEscritorioRecepcaoNavigations { get; set; } = new List<TabProtocolo>();

    public virtual ICollection<TabSetor> TabSetors { get; set; } = new List<TabSetor>();
}
