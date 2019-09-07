using Eventos.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class AtualizarEventoCommand : BaseEventoCommand
    {
        public AtualizarEventoCommand(
            Guid id,
           string nome,
           string nomeDaEmpresa,
           string descCurta,
           string descLonga,
           DateTime dataInicio,
           DateTime dataFim,
           bool gratuito,
           bool online,
           decimal valor
           )
        {
            Id = id;
            Nome = nome;
            DescricaoCurta = descCurta;
            DescricaoLonga = descLonga;
            NomeDaEmpresa = nomeDaEmpresa;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;

        }
    }
}
