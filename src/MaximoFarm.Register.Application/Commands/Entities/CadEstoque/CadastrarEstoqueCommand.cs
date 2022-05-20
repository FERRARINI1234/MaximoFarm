using FluentValidation;
using MaximoFarm.Register.Core.Messages;

namespace MaximoFarm.Register.Application.Commands.Entities.CadEstoque
{
    public class CadastrarEstoqueCommand : Command
    {
        public int CodCadEstoque { get; private set; }
        public string DescCadEstoque { get; private set; }

        public CadastrarEstoqueCommand(int codCadEstoque, string descCadEstoque)
        {
            CodCadEstoque = codCadEstoque;
            DescCadEstoque = descCadEstoque;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarEstoqueValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
    internal class CadastrarEstoqueValidation : AbstractValidator<CadastrarEstoqueCommand>
    {
        public CadastrarEstoqueValidation()
        {
            RuleFor(c => c.CodCadEstoque)
                .NotEmpty()
                .WithMessage("Codigo do estoque não pode ser em branco.");
            RuleFor(c => c.DescCadEstoque)
                .NotNull()
                .WithMessage("Descrição do estoque não pode ser vazia.")
                .MaximumLength(150);
        }
    }
}
