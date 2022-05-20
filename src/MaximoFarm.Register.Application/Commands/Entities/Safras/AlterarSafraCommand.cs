using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Safras
{
    public class AlterarSafraCommand : Command
    {
        public int CodSafra { get; set; }
        public string DescSafra { get; set; }

        public AlterarSafraCommand(int codSafra, string descSafra)
        {
            CodSafra = codSafra;
            DescSafra = descSafra;
        }
        public override bool EhValido()
        {
            ValidationResult = new AlterarSafraValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class AlterarSafraValidation : AbstractValidator<AlterarSafraCommand>
        {
            public AlterarSafraValidation()
            {
                RuleFor(c => c.CodSafra)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c => c.DescSafra)
                    .NotNull()
                    .WithMessage("A descrição abreviada não pode ser em branco.");
            }
        }
    }
}
