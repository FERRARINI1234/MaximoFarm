using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Safras
{
    public class ExcluirSafraCommand :  Command
    {
        public int CodSafra { get; set; }
        public ExcluirSafraCommand(int codSafra)
        {
            CodSafra = codSafra;
        }
        public override bool EhValido()
        {
            ValidationResult = new ExcluirSafraValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class ExcluirSafraValidation : AbstractValidator<ExcluirSafraCommand>
        {
            public ExcluirSafraValidation()
            {
                RuleFor(c => c.CodSafra)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
