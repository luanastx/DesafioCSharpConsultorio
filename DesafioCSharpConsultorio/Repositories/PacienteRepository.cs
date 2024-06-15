using System.Collections.Generic;
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

        public List<Paciente> Listar()
        {
            return _pacientes;
        }
    }
}