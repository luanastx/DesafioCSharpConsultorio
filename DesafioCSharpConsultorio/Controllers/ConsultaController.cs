using System;
using ConsultorioOdontologico.Services;

namespace ConsultorioOdontologico.Controllers
{
    public class ConsultaController
    {
        private readonly ConsultaService _consultaService;

        public ConsultaController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        public void AgendarConsulta()
        {
            Console.Clear();
            Console.WriteLine("Agendamento de Consultas");

            string cpf;
            while (true)
            {
                Console.Write("CPF do Paciente: ");
                cpf = Console.ReadLine();
                if (VerificadorCPF.Validar(cpf))
                {
                    break;
                }
                Console.WriteLine("CPF inválido. Tente novamente.");
            }

            DateTime dataConsulta;
            while (true)
            {
                Console.Write("Data da Consulta (dd/MM/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out dataConsulta))
                {
                    break;
                }
                Console.WriteLine("Data da consulta inválida. Tente novamente.");
            }

            TimeSpan horaInicial;
            while (true)
            {
                Console.Write("Hora Inicial (HH:mm): ");
                if (TimeSpan.TryParse(Console.ReadLine(), out horaInicial))
                {
                    break;
                }
                Console.WriteLine("Hora inicial inválida. Tente novamente.");
            }

            TimeSpan horaFinal;
            while (true)
            {
                Console.Write("Hora Final (HH:mm): ");
                if (TimeSpan.TryParse(Console.ReadLine(), out horaFinal))
                {
                    break;
                }
                Console.WriteLine("Hora final inválida. Tente novamente.");
            }

            if (_consultaService.AgendarConsulta(cpf, dataConsulta, horaInicial, horaFinal))
            {
                Console.WriteLine("Consulta agendada com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao agendar consulta. Verifique os dados e tente novamente.");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ListarConsultas()
        {
            Console.Clear();
            Console.WriteLine("Lista de Consultas");
            var consultas = _consultaService.ListarConsultas();

            foreach (var consulta in consultas)
            {
                Console.WriteLine($"CPF: {consulta.CPF}, Data: {consulta.DataConsulta:dd/MM/yyyy}, Hora Inicial: {consulta.HoraInicial}, Hora Final: {consulta.HoraFinal}");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}