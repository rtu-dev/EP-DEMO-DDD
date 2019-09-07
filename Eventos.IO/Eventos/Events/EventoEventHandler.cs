using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoEventHandler :
        IHandler<EventoRegistradoEvent>,
        IHandler<EventoExcluidoEvent>,
        IHandler<EventoAtualizadoEvent>
    {
        public void Handle(EventoRegistradoEvent message)
        {
            //enviar e-mail
        }

        public void Handle(EventoExcluidoEvent message)
        {
            //enviar e-mail
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            //enviar e-mail
        }
    }
}
