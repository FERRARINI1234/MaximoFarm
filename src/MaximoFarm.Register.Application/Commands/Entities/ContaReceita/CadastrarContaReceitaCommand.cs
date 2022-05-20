using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.ContaReceita
{
    public class CadastrarContaReceitaCommand : Command
    {
        public int CodContaReceita { get;  set; }
        public string DescContaReceita { get;  set; }
        public bool Ativo { get;  set; }

        public CadastrarContaReceitaCommand(int codContaReceita, string descContaReceita, bool ativo)
        {
            CodContaReceita=codContaReceita;
            DescContaReceita=descContaReceita;
            Ativo=ativo;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarContaReceitaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class CadastrarContaReceitaValidation : AbstractValidator<CadastrarContaReceitaCommand>
        {
            public CadastrarContaReceitaValidation()
            {
                RuleFor(c => c.CodContaReceita)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c => c.DescContaReceita)
                    .NotNull()
                    .WithMessage("A descrição não pode ser em branco.");
                RuleFor(c => c.Ativo)
                    .NotNull()
                    .WithMessage("O campo não pode ser em branco");
            }
        }
    }
}
