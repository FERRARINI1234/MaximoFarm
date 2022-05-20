using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.CentroReceita
{
    public class ExcluirCentroReceitaCommand : Command
    {
        public int CodCentroReceita { get; private set; }

        public ExcluirCentroReceitaCommand(int codCentroReceita)
        {
            CodCentroReceita = codCentroReceita;
        }
        public override bool EhValido()
        {
            ValidationResult = new ExcluirCentroReceitaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class ExcluirCentroReceitaValidation : AbstractValidator<ExcluirCentroReceitaCommand>
        {
            public ExcluirCentroReceitaValidation()
            {
                RuleFor(c => c.CodCentroReceita)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
