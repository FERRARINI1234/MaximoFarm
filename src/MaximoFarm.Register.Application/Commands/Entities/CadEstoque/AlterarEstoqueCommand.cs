using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.CadEstoque
{
    public class AlterarEstoqueCommand : Command
    {
        public int CodCadEstoque { get; private set; }
        public string DescCadEstoque { get; private set; }

        public AlterarEstoqueCommand(int codCadEstoque, string descCadEstoque)
        {
            CodCadEstoque = codCadEstoque;
            DescCadEstoque = descCadEstoque;
        }

        public override bool EhValido()
        {
            ValidationResult = new AlterarEstoqueValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class AlterarEstoqueValidation : AbstractValidator<AlterarEstoqueCommand>
        {
            public AlterarEstoqueValidation()
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
}
