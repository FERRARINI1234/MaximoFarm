using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Estados
{
    public class CadastrarEstadoCommand : Command
    {
        public int CodEstado { get; private set; }
        public string DescEstado { get; private set; }
        public string DescAbrevEstado { get; private set; }

        public CadastrarEstadoCommand(int codEstado, string descEstado, string descAbrevEstado)
        {
            CodEstado = codEstado;
            DescEstado = descEstado;
            DescAbrevEstado = descAbrevEstado;
        }
        public override bool EhValido()
        {
            ValidationResult = new CadastrarEstadoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class CadastrarEstadoValidation : AbstractValidator<CadastrarEstadoCommand>
        {
            public CadastrarEstadoValidation()
            {
                RuleFor(c => c.CodEstado)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c => c.DescAbrevEstado)
                    .NotNull()
                    .WithMessage("A descrição abreviada não pode ser em branco.");
                RuleFor(c => c.DescEstado)
                    .NotNull()
                    .WithMessage("A descrição não pode ser em branco.");
            }
        }
    }
}
