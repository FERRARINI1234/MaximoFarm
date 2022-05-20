using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.CadEstoque
{
    public class ExcluirEstoqueCommand : Command
    {
        public int CodCadEstoque { get; private set; }

        public ExcluirEstoqueCommand(int codCadEstoque)
        {
            CodCadEstoque = codCadEstoque;
        }

        public override bool EhValido()
        {
            ValidationResult = new ExcluirEstoqueValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class ExcluirEstoqueValidation : AbstractValidator<ExcluirEstoqueCommand>
        {
            public ExcluirEstoqueValidation()
            {
                RuleFor(c => c.CodCadEstoque)
                    .NotEmpty()
                    .WithMessage("Codigo do estoque não pode ser em branco.");
            }
        }
    }
}
