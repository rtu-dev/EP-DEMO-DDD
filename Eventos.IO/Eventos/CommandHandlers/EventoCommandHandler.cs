using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Eventos.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.CommandHandlers
{
    public class EventoCommandHandler : 
        IHandler<RegistrarEventoCommand>,
        IHandler<AtualizarEventoCommand>,
        IHandler<ExcluirEventoCommand>
    {
        public void Handle(RegistrarEventoCommand message)
        {
            throw new NotImplementedException();
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
