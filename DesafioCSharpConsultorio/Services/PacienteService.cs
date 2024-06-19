using System;
using System.Collections.Generic;
using System.Linq;
using ConsultorioOdontologico.Models;
using ConsultorioOdontologico.Repositories;

namespace ConsultorioOdontologico.Services
{
    public class PacienteService
    {
        private readonly PacienteRepository _pacienteRepository;
        private readonly ConsultaRepository _consultaRepository;

        public PacienteService(PacienteRepository pacienteRepository, ConsultaRepository consultaRepository)
        {
            _pacienteRepository = pacienteRepository;
            _consultaRepository = consultaRepository;
        }

        public void CadastrarPaciente(Paciente paciente)
        {
            _pacienteRepository.Adicionar(paciente);
        }

        public bool ExcluirPaciente(string cpf)
        {
            var consultasFuturas = _consultaRepository.Listar()
                .Where(c => c.CPF == cpf && c.DataConsulta >= DateTime.Today)
                .ToList();

            if (consultasFuturas.Any())
            {
                return false; 
            }

            var consultasPassadas = _consultaRepository.Listar()
                .Where(c => c.CPF == cpf && c.DataConsulta < DateTime.Today)
                .ToList();

            foreach (var consulta in consultasPassadas)
            {
                _consultaRepository.Remover(consulta.CPF, consulta.DataConsulta, consulta.HoraInicial);
            }

            _pacienteRepository.Remover(cpf);
            return true;
        }

        public List<Paciente> ListarPacientesOrdenadoPorCPF()
        {
            return _pacienteRepository.ListarOrdenadoPorCPF();
        }

        public List<Paciente> ListarPacientesOrdenadoPorNome()
        {
            return _pacienteRepository.ListarOrdenadoPorNome();
        }

        public bool CPFExistente(string cpf)
        {
            return _pacienteRepository.CPFExistente(cpf);
        }

        public Paciente ObterPacientePorCPF(string cpf)
        {
            return _pacienteRepository.ObterPorCPF(cpf);
        }
    }
}