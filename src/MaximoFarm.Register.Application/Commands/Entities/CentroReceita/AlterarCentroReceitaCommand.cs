using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.CentroReceita
{
    public class AlterarCentroReceitaCommand : Command
    {
        public int CodCentroReceita { get; private set; }
        public string DescCentroReceita { get; private set; }
        public bool Ativo { get; private set; }

        public AlterarCentroReceitaCommand(int codCentroReceita, string descCentroReceita, bool ativo)
        {
            CodCentroReceita = codCentroReceita;
            DescCentroReceita = descCentroReceita;
            Ativo = ativo;
        }
        public override bool EhValido()
        {
            ValidationResult = new AlterarCentroReceitaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class AlterarCentroReceitaValidation : AbstractValidator<AlterarCentroReceitaCommand>
        {
            public AlterarCentroReceitaValidation()
            {
                RuleFor(c => c.CodCentroReceita)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c => c.DescCentroReceita)
                    .NotNull()
                    .WithMessage("A descrição não pode ser em branco.");
                RuleFor(c => c.Ativo)
                    .NotNull()
                    .WithMessage("É preciso informar se está ativo ou inativo.");
            }
        }
    }
}
