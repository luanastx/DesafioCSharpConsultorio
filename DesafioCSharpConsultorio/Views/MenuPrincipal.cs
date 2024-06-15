using System;
using ConsultorioOdontologico.Controllers;

namespace ConsultorioOdontologico.Views
{
    public class MenuPrincipal
    {
        private readonly PacienteController _pacienteController;
        private readonly ConsultaController _consultaController;

        public MenuPrincipal(PacienteController pacienteController, ConsultaController consultaController)
        {
            _pacienteController = pacienteController;
            _consultaController = consultaController;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Consultório Odontológico");
                Console.WriteLine("1. Cadastro de Pacientes");
                Console.WriteLine("2. Agendamento de Consultas");
                Console.WriteLine("3. Listar Pacientes");
                Console.WriteLine("4. Listar Consultas");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _pacienteController.CadastrarPaciente();
                        break;
                    case "2":
                        _consultaController.AgendarConsulta();
                        break;
                    case "3":
                        _pacienteController.ListarPacientes();
                        break;
                    case "4":
                        _consultaController.ListarConsultas();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}