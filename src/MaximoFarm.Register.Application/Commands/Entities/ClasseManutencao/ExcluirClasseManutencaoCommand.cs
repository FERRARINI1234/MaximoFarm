using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.ClasseManutencao
{
    public class ExcluirClasseManutencaoCommand :  Command 
    {
        public int CodClasseManutencao { get;  set; }

        public ExcluirClasseManutencaoCommand(int codClasseManutencao)
        {
            CodClasseManutencao = codClasseManutencao;
        }
        public override bool EhValido()
        {
            ValidationResult = new ExcluirClasseManutencaoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class ExcluirClasseManutencaoValidation : AbstractValidator<ExcluirClasseManutencaoCommand>
        {
            public ExcluirClasseManutencaoValidation()
            {
                RuleFor(c => c.CodClasseManutencao)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
