using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.ContaDebito
{
    public class CadastrarContaDebitoCommand : Command
    {
        public int CodContaDebito { get;  set; }
        public string DescContaDebito { get;  set; }
        public bool Ativo { get;  set; }

        public CadastrarContaDebitoCommand(int codContaDebito, string descContaDebito, bool ativo)
        {
            CodContaDebito = codContaDebito;
            DescContaDebito = descContaDebito;
            Ativo = ativo;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarContaDebitoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class CadastrarContaDebitoValidation : AbstractValidator<CadastrarContaDebitoCommand>
        {
            public CadastrarContaDebitoValidation()
            {
                RuleFor(c => c.CodContaDebito)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c => c.DescContaDebito)
                    .NotNull()
                    .WithMessage("A descrição não pode ser em branco.");
                RuleFor(c => c.Ativo)
                    .NotNull()
                    .WithMessage("O campo não pode ser em branco");
            }
        }
    }
}
