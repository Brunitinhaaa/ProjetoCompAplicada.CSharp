using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCompAplicada.CSharp.Models;

[Table("servicos")]
public class Servico
{
    [Key]
    public long Id { get; set; }

    [Column("id_usuario")]
    public long IdUsuario { get; set; }

    [Required]
    public string Nome { get; set; } = default!;

    [MaxLength(1000)]
    public string? Descricao { get; set; }

    [Required]
    public double Preco { get; set; } = default!;

    [Required]
    public bool Ativo { get; set; } = default!;

    public string? Cep { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Uf { get; set; }
    public string? Ddd { get; set; }

    [Column("cod_ibge")]
    public string? CodIbge { get; set; }

    public string? Categoria { get; set; }

    [Column("data_hora")]
    public DateTime? DataHora { get; set; }

    public Imagem? Imagem { get; set; }
}
