using FluentValidation;
using FluentValidation.Results;
using MaximoFarm.Register.Core.Messages;

namespace MaximoFarm.Register.Application.Commands.Entities.ClasseManutencao
{
    public class AlterarClasseManutencaoCommand :  Command
    {
        public int CodClasseManutencao { get;  set; }
        public string DescClasseManutencao { get;  set; }

        public AlterarClasseManutencaoCommand(int codClasseManutencao, string descClasseManutencao)
        {
            CodClasseManutencao = codClasseManutencao;
            DescClasseManutencao = descClasseManutencao;
        }
        public override bool EhValido()
        {
            ValidationResult = new AlterarClasseManutencaoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class AlterarClasseManutencaoValidation : AbstractValidator<AlterarClasseManutencaoCommand>
        {
            public AlterarClasseManutencaoValidation()
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
