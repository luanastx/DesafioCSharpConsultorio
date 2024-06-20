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
            Console.WriteLine("Agendamento de Consulta");
<<<<<<< HEAD
=======

            Console.WriteLine("Agendamento de Consultas");
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e

            string cpf;
            while (true)
            {
                Console.Write("CPF do Paciente: ");
                cpf = Console.ReadLine();
<<<<<<< HEAD

=======
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
                if (VerificadorCPF.Validar(cpf) && _consultaService.PacienteExistente(cpf))
                {
                    break;
                }
                Console.WriteLine("CPF inválido ou paciente não cadastrado. Tente novamente.");
            }

            string dataConsulta;
            while (true)
            {
                Console.Write("Data da Consulta (DD/MM/AAAA): ");
                dataConsulta = Console.ReadLine();
                if (DateTime.TryParseExact(dataConsulta, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
                {
                    break;
                }
                Console.WriteLine("Data da consulta inválida. Use o formato DD/MM/AAAA.");
            }

            string horaInicial;
            while (true)
            {
                Console.Write("Hora Inicial (hh\\:mm): ");
                horaInicial = Console.ReadLine();
                if (TimeSpan.TryParseExact(horaInicial, "hh\\:mm", null, out _))
                {
                    break;
                }
                Console.WriteLine("Hora inicial inválida. Use o formato hh\\:mm.");
            }

            string horaFinal;
            while (true)
            {
                Console.Write("Hora Final (hh\\:mm): ");
                horaFinal = Console.ReadLine();
                if (TimeSpan.TryParseExact(horaFinal, "hh\\:mm", null, out _))
                {
                    break;
                }
                Console.WriteLine("Hora final inválida. Use o formato hh\\:mm.");
<<<<<<< HEAD
               
=======
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
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
            }

            if (_consultaService.AgendarConsulta(cpf, dataConsulta, horaInicial, horaFinal))
            {
                Console.WriteLine("Consulta agendada com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao agendar a consulta. Verifique as mensagens de erro.");
<<<<<<< HEAD
=======
                Console.WriteLine("Erro ao agendar consulta. Verifique os dados e tente novamente.");
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
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

        public void ListarConsultasOrdenadoPorDataHora()
        {
            Console.Clear();
            Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo: ");
            var opcao = Console.ReadLine().ToUpper();

            DateTime dataInicial = DateTime.MinValue;
            DateTime dataFinal = DateTime.MaxValue;

            if (opcao == "P")
            {
                Console.Write("Data inicial (dd/MM/yyyy): ");
                DateTime.TryParse(Console.ReadLine(), out dataInicial);

                Console.Write("Data final (dd/MM/yyyy): ");
                DateTime.TryParse(Console.ReadLine(), out dataFinal);
            }

            Console.Clear();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Data H.Ini H.Fim Tempo Nome Dt.Nasc.");
            Console.WriteLine(new string('-', 40));

            var consultas = _consultaService.ListarConsultasOrdenadoPorDataHora();
            foreach (var consulta in consultas)
            {
                if (consulta.DataConsulta >= dataInicial && consulta.DataConsulta <= dataFinal)
                {
                    var paciente = _consultaService.ObterPacientePorCPF(consulta.CPF);
                    var tempo = consulta.HoraFinal - consulta.HoraInicial;
                    Console.WriteLine($"{consulta.DataConsulta:dd/MM/yyyy} {consulta.HoraInicial:hh\\:mm} {consulta.HoraFinal:hh\\:mm} {tempo:hh\\:mm} {paciente.Nome.PadRight(25)} {paciente.DataNascimento:dd/MM/yyyy}");
                }
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void CancelarConsulta()
        {
            Console.Clear();
            Console.WriteLine("Cancelamento de Consulta");

            string cpf;
            while (true)
            {
                Console.Write("CPF do Paciente: ");
                cpf = Console.ReadLine();
                if (VerificadorCPF.Validar(cpf) && _consultaService.PacienteExistente(cpf))
                {
                    break;
                }
                Console.WriteLine("CPF inválido ou paciente não cadastrado. Tente novamente.");
            }

            DateTime dataConsulta;
            while (true)
            {
                Console.Write("Data da Consulta (dd/MM/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out dataConsulta) && dataConsulta >= DateTime.Today)
                {
                    break;
                }
                Console.WriteLine("Data da consulta inválida ou no passado. Tente novamente.");
            }

            TimeSpan horaInicial;
            while (true)
            {
                Console.Write("Hora Inicial (HH:mm): ");
                if (TimeSpan.TryParse(Console.ReadLine(), out horaInicial) && horaInicial.Minutes % 15 == 0 && horaInicial >= new TimeSpan(8, 0, 0) && horaInicial <= new TimeSpan(19, 0, 0))
                {
                    break;
                }
                Console.WriteLine("Hora inicial inválida. Deve ser em intervalos de 15 minutos e dentro do horário de funcionamento (08:00 - 19:00). Tente novamente.");
            }

            _consultaService.RemoverConsulta(cpf, dataConsulta, horaInicial);
            Console.WriteLine("Consulta cancelada com sucesso!");

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
