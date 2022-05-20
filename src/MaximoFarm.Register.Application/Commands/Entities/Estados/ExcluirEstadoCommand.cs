using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Estados
{
    public class ExcluirEstadoCommand : Command
    {
        public int CodEstado { get; private set; }

        public ExcluirEstadoCommand(int codEstado)
        {
            CodEstado = codEstado;
        }
        public override bool EhValido()
        {
            ValidationResult = new ExcluirEstadoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class ExcluirEstadoValidation : AbstractValidator<ExcluirEstadoCommand>
        {
            public ExcluirEstadoValidation()
            {
                RuleFor(c => c.CodEstado)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
