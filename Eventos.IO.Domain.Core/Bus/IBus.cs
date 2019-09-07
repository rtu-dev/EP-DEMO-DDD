using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Core.Bus
{
    public interface IBus
    {
        //um comando é sempre enviado
        void SendCommand<T>(T theCommand) where T : Command;
        //um evento eh sempre lançado
        void RiseEvent<T>(T theEvent) where T : Event;
    }
}
