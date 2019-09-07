using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public RegistrarEventoCommand(
            string nome,
            string nomeDaEmpresa,
            DateTime dataInicio,
            DateTime dataFim,
            bool gratuito,
            bool online,
            decimal valor
            )
        {
            Nome = nome;
            NomeDaEmpresa = nomeDaEmpresa;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
        }
    }
}
