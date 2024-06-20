using System;
using ConsultorioOdontologico.Services;
using ConsultorioOdontologico.Models;

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
            Console.WriteLine("Cadastro de Paciente");

            string nome;
            while (true)
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                if (nome.Length >= 5)
                {
                    break;
                }
                Console.WriteLine("O nome deve ter pelo menos 5 caracteres. Tente novamente.");
            }

            string cpf;
            while (true)
            {
                Console.Write("CPF: ");
                cpf = Console.ReadLine();
                if (VerificadorCPF.Validar(cpf) && !_pacienteService.CPFExistente(cpf))
                {
                    break;
                }
                Console.WriteLine("CPF inválido ou já cadastrado. Tente novamente.");
            }

            Console.Write("Data de Nascimento (dd/MM/yyyy): ");
            DateTime dataNascimento;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
            {
                Console.WriteLine("Data de nascimento inválida. Tente novamente.");
            }

            var paciente = new Paciente
            {
                Nome = nome,
                CPF = cpf,
                DataNascimento = dataNascimento
            };

            _pacienteService.CadastrarPaciente(paciente);

            Console.WriteLine("Paciente cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ExcluirPaciente()
        {
            Console.Clear();
            Console.WriteLine("Exclusão de Paciente");

            string cpf;
            while (true)
            {
                Console.Write("CPF do Paciente: ");
                cpf = Console.ReadLine();
                if (VerificadorCPF.Validar(cpf) && _pacienteService.CPFExistente(cpf))
                {
                    break;
                }
                Console.WriteLine("CPF inválido ou paciente não cadastrado. Tente novamente.");
            }

            if (_pacienteService.ExcluirPaciente(cpf))
            {
                Console.WriteLine("Paciente excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Não é possível excluir o paciente. Ele possui consultas futuras agendadas.");

            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ListarPacientesOrdenadoPorCPF()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("CPF Nome Dt.Nasc. Idade");
            Console.WriteLine(new string('-', 40));

            var pacientes = _pacienteService.ListarPacientesOrdenadoPorCPF();
            foreach (var paciente in pacientes)
            {
                Console.WriteLine($"{paciente.CPF} {paciente.Nome.PadRight(30)} {paciente.DataNascimento:dd/MM/yyyy} {paciente.Idade}");
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ListarPacientesOrdenadoPorNome()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("CPF Nome Dt.Nasc. Idade");
            Console.WriteLine(new string('-', 40));

            var pacientes = _pacienteService.ListarPacientesOrdenadoPorNome();
            foreach (var paciente in pacientes)
            {
                Console.WriteLine($"{paciente.CPF} {paciente.Nome.PadRight(30)} {paciente.DataNascimento:dd/MM/yyyy} {paciente.Idade}");
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}