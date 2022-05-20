using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Ciclo
{
    public class ExcluirCicloCommand : Command
    {
        public int CodCiclo { get; private set; }

        public ExcluirCicloCommand(int codCiclo)
        {
            CodCiclo = codCiclo;
        }
        public override bool EhValido()
        {
            ValidationResult = new ExcluirCicloValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class ExcluirCicloValidation : AbstractValidator<ExcluirCicloCommand>
        {
            public ExcluirCicloValidation()
            {
                RuleFor(c => c.CodCiclo)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
