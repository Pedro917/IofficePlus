using System;
using System.Collections.Generic;

namespace IofficePlus.Dominio.Models;

public partial class TabEscritorio
{
    public long IdEscritorio { get; set; }

    public long IdControladora { get; set; }

    public long IdMantenedora { get; set; }

    public string NmEscritorioRazaoSocial { get; set; } = null!;

    public string NmEscritorioFantasia { get; set; } = null!;

    public string NrCnpjEscritorio { get; set; } = null!;

    public byte TpLogradouro { get; set; }

    public string NmLogradouro { get; set; } = null!;

    public int NrLogradouro { get; set; }

    public string? NmBairro { get; set; }

    public int IdMunicipio { get; set; }

    public string NrCep { get; set; } = null!;

    public byte TpZona { get; set; }

    public string? Complemento { get; set; }

    public string? NrTelefoneContato { get; set; }

    public string? NrTelefoneOutro { get; set; }

    public string? Email { get; set; }

    public byte[]? Logomarca { get; set; }

    public string? NmLogoEscritorio { get; set; }

    public string? RodapeRelatorio { get; set; }

    public byte TpSituacaoCadastral { get; set; }

    public long? IdUsuarioAtualizacao { get; set; }

    public DateTime DtCriacao { get; set; }

    public DateTime? DtAtualizacao { get; set; }

    public virtual TabControladora IdControladoraNavigation { get; set; } = null!;

    public virtual TabMantenedora IdMantenedoraNavigation { get; set; } = null!;

    public virtual TabMunicipio IdMunicipioNavigation { get; set; } = null!;

    public virtual TabUsuario? IdUsuarioAtualizacaoNavigation { get; set; }

    public virtual ICollection<TabAtendimento> TabAtendimentos { get; set; } = new List<TabAtendimento>();

    public virtual ICollection<TabCliente> TabClientes { get; set; } = new List<TabCliente>();

    public virtual ICollection<TabControleNotificacao> TabControleNotificacaos { get; set; } = new List<TabControleNotificacao>();

    public virtual ICollection<TabControleProcesso> TabControleProcessos { get; set; } = new List<TabControleProcesso>();

    public virtual ICollection<TabControleViagem> TabControleViagems { get; set; } = new List<TabControleViagem>();

    public virtual ICollection<TabEntidadeAdministrativa> TabEntidadeAdministrativas { get; set; } = new List<TabEntidadeAdministrativa>();

    public virtual ICollection<TabMonitoramento> TabMonitoramentos { get; set; } = new List<TabMonitoramento>();

    public virtual ICollection<TabProtocoloControle> TabProtocoloControles { get; set; } = new List<TabProtocoloControle>();

    public virtual ICollection<TabProtocolo> TabProtocolos { get; set; } = new List<TabProtocolo>();

    public virtual ICollection<TabResponsavelEscritorio> TabResponsavelEscritorios { get; set; } = new List<TabResponsavelEscritorio>();

    public virtual ICollection<TabSetor> TabSetors { get; set; } = new List<TabSetor>();

    public virtual ICollection<TabTarefa> TabTarefas { get; set; } = new List<TabTarefa>();
}
