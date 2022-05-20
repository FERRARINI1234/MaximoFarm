using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.CentroCusto
{
    public class ExcluirCentroCustoCommand : Command
    {
        public int CodCentroCusto { get; private set; }

        public ExcluirCentroCustoCommand(int codCentroCusto)
        {
            CodCentroCusto = codCentroCusto;
        }
        public override bool EhValido()
        {
            ValidationResult = new CadastrarCentroCustoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class CadastrarCentroCustoValidation : AbstractValidator<ExcluirCentroCustoCommand>
        {
            public CadastrarCentroCustoValidation()
            {
                RuleFor(c => c.CodCentroCusto)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
