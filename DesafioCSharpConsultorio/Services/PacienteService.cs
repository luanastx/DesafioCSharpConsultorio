using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
=======
<<<<<<< HEAD
using System.Linq;
=======
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
using ConsultorioOdontologico.Models;
using ConsultorioOdontologico.Repositories;

namespace ConsultorioOdontologico.Services
{
    public class PacienteService
    {
        private readonly PacienteRepository _pacienteRepository;
<<<<<<< HEAD

=======
<<<<<<< HEAD
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
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
<<<<<<< HEAD
=======
=======

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
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
        }
    }
}