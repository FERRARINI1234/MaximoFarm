using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Cargos
{
    public class ExcluirCargoCommand : Command
    {
        public int CodCargo { get; set; }

        public ExcluirCargoCommand(int codCargo)
        {
            CodCargo = codCargo;
        }

        public override bool EhValido()
        {
            return base.EhValido();
        }

        internal class ExcluirCargoValidation : AbstractValidator<ExcluirCargoCommand>
        {
            public ExcluirCargoValidation()
            {
                RuleFor(c => c.CodCargo)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
