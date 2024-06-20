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

                Console.WriteLine("Menu Principal");
                Console.WriteLine("1. Cadastro de Pacientes");
                Console.WriteLine("2. Agenda");
                Console.WriteLine("3. Fim");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ExibirMenuCadastroPacientes();
                        break;
                    case "2":
                        ExibirMenuAgenda();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void ExibirMenuCadastroPacientes()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu do Cadastro de Pacientes");
                Console.WriteLine("1. Cadastrar novo paciente");
                Console.WriteLine("2. Excluir paciente");
                Console.WriteLine("3. Listar pacientes (ordenado por CPF)");
                Console.WriteLine("4. Listar pacientes (ordenado por nome)");
                Console.WriteLine("5. Voltar p/ menu principal");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _pacienteController.CadastrarPaciente();
                        break;
                    case "2":
                        _pacienteController.ExcluirPaciente();
                        break;
                    case "3":
                        _pacienteController.ListarPacientesOrdenadoPorCPF();
                        break;
                    case "4":
                        _pacienteController.ListarPacientesOrdenadoPorNome();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void ExibirMenuAgenda()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu da Agenda");
                Console.WriteLine("1. Agendar consulta");
                Console.WriteLine("2. Cancelar agendamento");
                Console.WriteLine("3. Listar agenda");
                Console.WriteLine("4. Voltar p/ menu principal");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _consultaController.AgendarConsulta();
                        break;
                    case "2":
                        _consultaController.CancelarConsulta();
                        break;
                    case "3":
                        _consultaController.ListarConsultasOrdenadoPorDataHora();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
