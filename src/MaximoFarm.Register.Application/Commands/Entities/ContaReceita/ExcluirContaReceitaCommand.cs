using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.ContaReceita
{
    public class ExcluirContaReceitaCommand :  Command
    {
        public int CodContaReceita { get; set; }
        public ExcluirContaReceitaCommand(int codContaReceita)
        {
            CodContaReceita = codContaReceita;
        }
        public override bool EhValido()
        {
            ValidationResult = new ExcluirContaReceitaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class ExcluirContaReceitaValidation : AbstractValidator<ExcluirContaReceitaCommand>
        {
            public ExcluirContaReceitaValidation()
            {
                RuleFor(c => c.CodContaReceita)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
            }
        }
    }
}
