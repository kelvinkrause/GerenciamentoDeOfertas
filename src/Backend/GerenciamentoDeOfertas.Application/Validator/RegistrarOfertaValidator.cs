using FluentValidation;
using GerenciamentoDeOfertas.Communication.Requests;

namespace GerenciamentoDeOfertas.Application.Validator
{
    public class RegistrarOfertaValidator : AbstractValidator<RequestRegistrarOfertaJson>
    {
        public RegistrarOfertaValidator()
        {
            RuleFor(oferta => oferta.Nome)
                .NotEmpty().WithMessage("Nome não pode ser vazio.")
                .MaximumLength(100).WithMessage("Nome não pode conter mais de 100 caracteres.");
            
            RuleFor(oferta => oferta.Descricao)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Descrição não pode ser vazia.")
                .MaximumLength(100).WithMessage("Descrição não pode conter mais de 500 caracteres.");

            RuleFor(oferta => oferta.Valor)
                .GreaterThan(0).WithMessage("Preço deve ser maior que zero.");

        }
    }
}
