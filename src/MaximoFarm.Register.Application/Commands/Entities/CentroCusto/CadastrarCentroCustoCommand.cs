using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.CentroCusto
{
    public class CadastrarCentroCustoCommand : Command
    {
        public int CodCentroCusto { get; private set; }
        public string DescCentroCusto { get; private set; }
        public bool Ativo { get; private set; }

        public CadastrarCentroCustoCommand(int codCentroCusto, string descCentroCusto, bool ativo)
        {
            CodCentroCusto = codCentroCusto;
            DescCentroCusto = descCentroCusto;
            Ativo = ativo;
        }
        public override bool EhValido()
        {
            ValidationResult = new CadastrarCentroCustoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class CadastrarCentroCustoValidation: AbstractValidator<CadastrarCentroCustoCommand>
        {
            public CadastrarCentroCustoValidation()
            {
                RuleFor(c=>c.CodCentroCusto)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c=>c.DescCentroCusto)
                    .NotNull()
                    .WithMessage("A descrição não pode ser em branco.");
                RuleFor(c=>c.Ativo)
                    .NotEmpty()
                    .WithMessage("É preciso informar se está ativo ou inativo.");
            }
        }
    }
}
