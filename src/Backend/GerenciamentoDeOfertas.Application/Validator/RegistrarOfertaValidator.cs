using FluentValidation;
using GerenciamentoDeOfertas.Communication.Requests;

namespace GerenciamentoDeOfertas.Application.Validator
{
    public class RegistrarOfertaValidator : AbstractValidator<RequestRegistrarOfertaJson>
    {
        public RegistrarOfertaValidator()
        {
            RuleFor(oferta => oferta.Nome)
                .NotEmpty().WithMessage("Nome não pode ser vazio.");
            
            RuleFor(oferta => oferta.Descricao)
                .NotEmpty().WithMessage("Descrição não pode ser vazia.");

            RuleFor(oferta => oferta.Preco)
                .GreaterThan(0).WithMessage("Preço deve ser maior que zero.");

        }
    }
}
