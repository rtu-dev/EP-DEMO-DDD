using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime TimeStamp { get; private set; }

        public Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
