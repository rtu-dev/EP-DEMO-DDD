using Eventos.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoRegistradoEvent : BaseEventoEvent
    {
        public EventoRegistradoEvent(
             Guid id,
            string nome,
            string nomeDaEmpresa,
            DateTime dataInicio,
            DateTime dataFim,
            bool gratuito,
            bool online,
            decimal valor
            )
        {
            Id = id;
            Nome = nome;
            NomeDaEmpresa = nomeDaEmpresa;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;

            AggregateId = id;

        }
    }
}
