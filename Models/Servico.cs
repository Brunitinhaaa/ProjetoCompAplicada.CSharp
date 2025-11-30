using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCompAplicada.CSharp.Models
{
    [Table("servicos")]
    public class Servico
    {
        [Key]
        public long Id { get; set; }

        [Column("id_usuario")]
        public long IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("preco")]
        public double Preco { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; } = true;

        // Nova propriedade de visibilidade
        public ServicoVisibilidade Visibilidade { get; set; } = ServicoVisibilidade.Publico;

        public string? Cep { get; set; }
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        [StringLength(50)]
        public string Cidade { get; set; } = string.Empty;

        [Column("uf")]
        public string? Uf { get; set; }

        [Column("ddd")]
        public string? Ddd { get; set; }

        [Column("cod_ibge")]
        public string? CodIbge { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(50, ErrorMessage = "A categoria não pode ter mais de 50 caracteres")]
        public string Categoria { get; set; } = string.Empty;

        [Column("data_hora")]
        public DateTime? DataHora { get; set; }

        public Imagem? Imagem { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsAtivo() => Ativo;
    }

    // Enum para visibilidade do serviço
    public enum ServicoVisibilidade
    {
        Publico,
        Privado,
        Rascunho
    }
}
