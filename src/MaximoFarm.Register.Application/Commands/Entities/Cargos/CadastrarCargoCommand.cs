using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Cargos
{
    public class CadastrarCargoCommand : Command
    {
        public int CodCargo { get; set; }
        public string DescCargo { get; set; }

        public CadastrarCargoCommand(int codCargo, string descCargo)
        {
            CodCargo = codCargo;
            DescCargo = descCargo;
        }
        public override bool EhValido()
        {
            ValidationResult = new CadastrarCargoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class CadastrarCargoValidation : AbstractValidator<CadastrarCargoCommand>
        {
            public CadastrarCargoValidation()
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
