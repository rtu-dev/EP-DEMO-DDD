using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(IUnitOfWork unitOfWork,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                _bus.RiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            //TODO: validar se a há alguma validacao de negocio com erro!
            //se houver nao entra em commit 
            if (_notifications.HasNotifications()) return false;
            

            var commandResponse = _unitOfWork.Commit();

            if (commandResponse.Success) return true;

            Console.WriteLine("Erro ao salvar dados no banco");
            _bus.RiseEvent(new DomainNotification("Commit", "Erro ao salvar dados no banco"));
            return false;
        }
    }
}
