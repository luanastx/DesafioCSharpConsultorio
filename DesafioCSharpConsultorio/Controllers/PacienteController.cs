using System;
using ConsultorioOdontologico.Services;

namespace ConsultorioOdontologico.Controllers
{
    public class PacienteController
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public void CadastrarPaciente()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Pacientes");

            string cpf;
            while (true)
            {
                Console.Write("CPF: ");
                cpf = Console.ReadLine();
                if (VerificadorCPF.Validar(cpf))
                {
                    break;
                }
                Console.WriteLine("CPF inválido. Tente novamente.");
            }

            Console.Write("Nome: ");
            var nome = Console.ReadLine();

            DateTime dataNascimento;
            while (true)
            {
                Console.Write("Data de Nascimento (dd/MM/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                {
                    break;
                }
                Console.WriteLine("Data de nascimento inválida. Tente novamente.");
            }

            if (_pacienteService.AdicionarPaciente(cpf, nome, dataNascimento))
            {
                Console.WriteLine("Paciente cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar paciente. Verifique os dados e tente novamente.");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ListarPacientes()
        {
            Console.Clear();
            Console.WriteLine("Lista de Pacientes");
            var pacientes = _pacienteService.ListarPacientes();

            foreach (var paciente in pacientes)
            {
                Console.WriteLine($"CPF: {paciente.CPF}, Nome: {paciente.Nome}, Data de Nascimento: {paciente.DataNascimento:dd/MM/yyyy}, Idade: {paciente.Idade}");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}