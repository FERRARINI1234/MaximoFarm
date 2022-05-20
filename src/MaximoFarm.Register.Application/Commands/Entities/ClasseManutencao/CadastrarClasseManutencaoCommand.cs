using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.ClasseManutencao
{
    public class CadastrarClasseManutencaoCommand : Command
    {
        public int CodClasseManutencao { get;  set; }
        public string DescClasseManutencao { get;  set; }

        public CadastrarClasseManutencaoCommand(int codClasseManutencao, string descClasseManutencao)
        {
            CodClasseManutencao = codClasseManutencao;
            DescClasseManutencao = descClasseManutencao;
        }
        public override bool EhValido()
        {
            ValidationResult = new CadastrarClasseManutencaoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class CadastrarClasseManutencaoValidation : AbstractValidator<CadastrarClasseManutencaoCommand> 
        {
            public CadastrarClasseManutencaoValidation()
            {
                RuleFor(c => c.CodClasseManutencao)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c => c.DescClasseManutencao)
                    .NotNull()
                    .WithMessage("A descrição não pode ser em branco.");
            }
        }
    }
}
