using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Cidades
{
    public class ExcluirCidadeCommand : Command
    {
        public int CodCidade { get; private set; }

        public ExcluirCidadeCommand(int codCidade)
        {
            CodCidade = codCidade;
        }
        public override bool EhValido()
        {
            ValidationResult = new ExcluirCidadeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class ExcluirCidadeValidation : AbstractValidator<ExcluirCidadeCommand>
        {
            public ExcluirCidadeValidation()
            {
                RuleFor(c => c.CodCidade)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
