using System.Collections.Generic; 
using System.Linq;
using ConsultorioOdontologico.Models;

namespace ConsultorioOdontologico.Repositories
{
    public class PacienteRepository
    {
        private readonly List<Paciente> _pacientes = new List<Paciente>();

        public void Adicionar(Paciente paciente)
        {
            _pacientes.Add(paciente);
        }
        public void Remover(string cpf)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.CPF == cpf);
            if (paciente != null)
            {
                _pacientes.Remove(paciente);
            }
        }

        public List<Paciente> ListarOrdenadoPorCPF()
        {
            return _pacientes.OrderBy(p => p.CPF).ToList();
        }

        public List<Paciente> ListarOrdenadoPorNome()
        {
            return _pacientes.OrderBy(p => p.Nome).ToList();
        }

        public bool CPFExistente(string cpf)
        {
            return _pacientes.Any(p => p.CPF == cpf);
        }

        public Paciente ObterPorCPF(string cpf)
        {
            return _pacientes.FirstOrDefault(p => p.CPF == cpf);
        }
    }
}