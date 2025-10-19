using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCompAplicada.CSharp.Models;

[Table("users")]
public class User
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Nome { get; set; } = default!;

    [Required]
    public string Sobrenome { get; set; } = default!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    public string Celular { get; set; } = default!;

    [Required]
    public string Cpf { get; set; } = default!;

    public string? CodigoPagseguro { get; set; }

    [Required]
    public string Senha { get; set; } = default!;
}
