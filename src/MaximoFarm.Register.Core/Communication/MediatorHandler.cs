using MaximoFarm.Register.Core.Messages;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Core.Communication
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
           return await _mediator.Send(comando);
        }
        public async Task PublicarEnvento<T>(T evento) where T : Event
        {
           await _mediator.Publish(evento); //LOG 
        }
        public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }
    }
}
