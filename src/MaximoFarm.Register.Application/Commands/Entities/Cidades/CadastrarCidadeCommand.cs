using FluentValidation;
using MaximoFarm.Register.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Entities.Cidades
{
    public class CadastrarCidadeCommand : Command
    {
        public int CodCidade { get;  set; }
        public string DescCidade { get;  set; }
        public int CodEstado { get;  set; }
        public CadastrarCidadeCommand(int codCidade, string descCidade,int codEstado)
        {
            CodCidade = codCidade;
            DescCidade = descCidade;
            CodEstado = codEstado;
        }
        public override bool EhValido()
        {
            ValidationResult = new CadastrarCidadeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        internal class CadastrarCidadeValidation : AbstractValidator<CadastrarCidadeCommand>
        {
            public CadastrarCidadeValidation()
            {
                RuleFor(c => c.CodCidade)
                    .NotEmpty()
                    .WithMessage("O código não pode ser em branco.");
                RuleFor(c => c.DescCidade)
                    .NotNull()
                    .WithMessage("A descrição não pode ser em branco.");
                RuleFor(c => c.CodEstado)
                    .NotNull()
                    .WithMessage("O código não pode ser nulo.");
            }
        }
    }
}
