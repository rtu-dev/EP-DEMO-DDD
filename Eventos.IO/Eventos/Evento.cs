using Eventos.IO.Domain.Core.Eventos;
using Eventos.IO.Domain.Organizadores;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Eventos
{
    public class Evento : Entity<Evento>
    {
        public Evento(
            string nome,
            string nomeDaEmpresa,
            DateTime dataInicio,
            DateTime dataFim,
            bool gratuito,
            bool online,
            decimal valor
            )
        {
            Id = Guid.NewGuid();
            Nome = nome;
            NomeDaEmpresa = nomeDaEmpresa;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;

            #region Codigo de validacao comentado

            //ErrosValidacao = new Dictionary<string, string>();

            //if (gratuito && valor != 0)
            //    ErrosValidacao.Add("Valor", "Não pode conter valor se evento for gratuito");


            //if (ErrosValidacao.Any())
            //    throw new Exception("A entidade possui " + ErrosValidacao.Count() + " Erros");
            #endregion
        }

        public string Nome { get; private set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoLonga { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool Gratuito { get; private set; }
        public decimal Valor { get; private set; }
        public bool Online { get; private set; }
        public string NomeDaEmpresa { get; private set; }
        public Categoria Categoria { get; private set; }
        public Endereco Endereco { get; private set; }
        public Organizador Organizador { get; private set; }
        public ICollection<Tags> Tags { get; private set; }
        //public IDictionary<string, string> ErrosValidacao { get; set; }

        public bool Valido()
        {
            Validar();
            return false;
        }

        #region Validações

        private void Validar()
        {
            ValidarNome();
            ValidarValor();

            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Mensagem de validacao de nome")
                .Length(5, 150).WithMessage("Mensagem de validacao de nome");
        }

        private void ValidarValor()
        {
            if(!Gratuito)
            RuleFor(c => c.Valor)
                .ExclusiveBetween(1, 1000).WithMessage("Mensagem de validacao de valor");                
        }

        #endregion
    }
}
