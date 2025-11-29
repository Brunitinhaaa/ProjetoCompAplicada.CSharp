using FluentValidation;

namespace ProjetoCompAplicada.CSharp.UseCases.Servicos
{
    public class PublicServicosFilterValidator : AbstractValidator<PublicServicosFilter>
    {
        public PublicServicosFilterValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Page deve ser maior ou igual a 0.");

            RuleFor(x => x.Size)
                .InclusiveBetween(1, 100)
                .WithMessage("Size deve estar entre 1 e 100.");

            RuleFor(x => x.Nome)
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.Nome))
                .WithMessage("Nome não pode ter mais que 100 caracteres.");

            RuleFor(x => x.PrecoMin)
                .GreaterThanOrEqualTo(0)
                .When(x => x.PrecoMin.HasValue);

            RuleFor(x => x.PrecoMax)
                .GreaterThanOrEqualTo(0)
                .When(x => x.PrecoMax.HasValue);

            RuleFor(x => x.PrecoMax)
                .GreaterThanOrEqualTo(x => x.PrecoMin!.Value)
                .When(x => x.PrecoMin.HasValue && x.PrecoMax.HasValue)
                .WithMessage("PrecoMax deve ser maior ou igual a PrecoMin.");
        }
    }
}
