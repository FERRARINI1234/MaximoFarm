using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Core.Messages
{
    public class Validation : IValidation

    {
        private readonly IMediatorHandler _mediatorHandler;
        public Validation(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }
        public bool ValidarComando(Command command)
        {
            if (command.EhValido()) return true;

            foreach (var error in command.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(command.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
