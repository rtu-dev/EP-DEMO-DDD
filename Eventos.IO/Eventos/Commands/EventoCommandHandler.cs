using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Events;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using System;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>,
        IHandler<AtualizarEventoCommand>,
        IHandler<ExcluirEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IBus _bus;
        public EventoCommandHandler(IEventoRepository eventoRepository,
            IUnitOfWork unitOfWorkd, IBus bus, IDomainNotificationHandler<DomainNotification> notification) 
            : base(unitOfWorkd, bus, notification)
        {
            _eventoRepository = eventoRepository;
            _bus = bus;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var evento = new Evento(
                message.Nome,
                message.NomeDaEmpresa,
                message.DataInicio,
                message.DataFim,
                message.Gratuito,
                message.Online,
                message.Valor
            );

            if (!evento.Valido())
            {
                NotificarValidacoesErro(evento.ValidationResult);
                return;
            }

            //Validacoes de negocio

            //persistencia
            _eventoRepository.Add(evento);

            if (Commit())
            {
                //notificar processo conlcuido
                Console.WriteLine("Evento registrado com sucesso");
                _bus.RiseEvent(new EventoRegistradoEvent(
                    evento.Id, evento.Nome, evento.NomeDaEmpresa, evento.DataInicio,
                    evento.DataFim, evento.Gratuito, evento.Online, evento.Valor));
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(ExcluirEventoCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
