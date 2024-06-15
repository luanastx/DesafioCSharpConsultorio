using System;
using System.Collections.Generic;
using ConsultorioOdontologico.Models;
using ConsultorioOdontologico.Repositories;

namespace ConsultorioOdontologico.Services
{
    public class PacienteService
    {
        private readonly PacienteRepository _pacienteRepository;

        public PacienteService(PacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public bool AdicionarPaciente(string cpf, string nome, DateTime dataNascimento)
        {
            if (VerificadorCPF.Validar(cpf))
            {
                var paciente = new Paciente
                {
                    CPF = cpf,
                    Nome = nome,
                    DataNascimento = dataNascimento
                };
                _pacienteRepository.Adicionar(paciente);
                return true;
            }
            return false;
        }

        public List<Paciente> ListarPacientes()
        {
            return _pacienteRepository.Listar();
        }
    }
}