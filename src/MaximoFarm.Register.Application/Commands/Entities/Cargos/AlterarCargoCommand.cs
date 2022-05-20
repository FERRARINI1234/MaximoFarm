using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Cargos
{
    public class AlterarCargoCommand : Command
    {
        public int CodCargo { get; set; }
        public string DescCargo { get; set; }

        public AlterarCargoCommand(int codCargo, string descCargo)
        {
            CodCargo = codCargo;
            DescCargo = descCargo;
        }

        public override bool EhValido()
        {
            ValidationResult = new AlterarCargoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class AlterarCargoValidation : AbstractValidator<AlterarCargoCommand>
        {
            public AlterarCargoValidation()
            {
                RuleFor(c => c.CodCargo)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c => c.DescCargo)
                    .NotNull()
                    .WithMessage("A Descrição não pode ser em branco.")
                    .MaximumLength(150);
            }
        }
    }
}
