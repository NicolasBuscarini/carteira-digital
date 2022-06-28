using CarteiraDigital.Model.Domain;
using FluentValidation;
using FluentValidation.Results;


namespace CarteiraDigital.Model.Validator;

public class CartaoValidator : AbstractValidator<CartaoModel>
{
    public CartaoValidator()
    {
        RuleFor(x => x.InformacaoCartaoModel).Custom((informacaoCartao, context) =>
        {
            if (null == informacaoCartao)
            {
                context.AddFailure(new ValidationFailure("InformacaoCartao", "Informações do cartão vazia." ));
            }
            else if (int.Parse(informacaoCartao.CodigoSeguranca) < 0)
            {
                context.AddFailure(new ValidationFailure("CodigoSeguranca", "Codigo de segurança inválido." ));
            }
            else if (int.Parse(informacaoCartao.NumeroCartao) < 0)
            {
                context.AddFailure(new ValidationFailure("CodigoSeguranca", "Codigo de segurança inválido." ));
            }
            else if (informacaoCartao.DataValidade < DateTime.Now)
            {
                context.AddFailure(new ValidationFailure("DataValidade", "Validade de cartão expirado." ));
            }
        });
    }
}
    
