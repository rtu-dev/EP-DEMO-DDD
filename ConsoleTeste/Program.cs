using Eventos.IO.Domain.Eventos;
using System;

namespace ConsoleTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            var evento = new Evento(
                "",
                "Nome da empresa",
                DateTime.Now,
                DateTime.Now,
                true,
                false,
                50
                );

            var evento2 = evento;

            Console.WriteLine(evento.ToString());
            Console.WriteLine(evento.Valido());


            if (!evento.ValidationResult.IsValid)
            {
                foreach (var erro in evento.ValidationResult.Errors)
                {
                    Console.WriteLine(erro.ErrorMessage);
                }

            }
            
            Console.ReadKey();
        }
    }
}
