using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCompAplicada.CSharp.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string Sobrenome { get; set; } = null!;

        [Required]
        [Column("email")]
        public string Email { get; set; } = null!;

        [Required]
        public string Celular { get; set; } = null!;

        [Required]
        public string Cpf { get; set; } = null!;

        [Column("codigo_pagseguro")]
        public string? CodigoMercadoPago { get; set; }

        [Required]
        public string Senha { get; set; } = null!;
    }
}
