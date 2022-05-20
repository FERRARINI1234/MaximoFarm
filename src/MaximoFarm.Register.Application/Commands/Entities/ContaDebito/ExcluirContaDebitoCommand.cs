using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.ContaDebito
{
    public class ExcluirContaDebitoCommand : Command
    {
        public int CodContaDebito { get; set; }
        public ExcluirContaDebitoCommand(int codContaDebito)
        {
            CodContaDebito = codContaDebito;
        }
        public override bool EhValido()
        {
            ValidationResult = new ExcluirContaDebitoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class ExcluirContaDebitoValidation : AbstractValidator<ExcluirContaDebitoCommand>
        {
            public ExcluirContaDebitoValidation()
            {
                RuleFor(c => c.CodContaDebito)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
