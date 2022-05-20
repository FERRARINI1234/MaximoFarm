using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Ciclo
{
    public class AlterarCicloCommand : Command
    {
        public int CodCiclo { get; private set; }
        public string DescCiclo { get; private set; }
        public bool Ativo { get; private set; }

        public AlterarCicloCommand(int codCiclo, string descCiclo, bool ativo)
        {
            CodCiclo = codCiclo;
            DescCiclo = descCiclo;
            Ativo = ativo;
        }
        public override bool EhValido()
        {
            ValidationResult = new AlterarCicloValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class AlterarCicloValidation : AbstractValidator<AlterarCicloCommand>
        {
            public AlterarCicloValidation()
            {
                RuleFor(c => c.CodCiclo)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c => c.DescCiclo)
                    .NotNull()
                    .WithMessage("A descrição não pode ser em branco.");
                RuleFor(c => c.Ativo)
                    .NotNull()
                    .WithMessage("É preciso informar se está ativo ou inativo.");
            }
        }
    }
}
