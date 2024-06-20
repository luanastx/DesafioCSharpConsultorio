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
    public class ConsultaService
    {
        private readonly ConsultaRepository _consultaRepository;
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
        private readonly PacienteService _pacienteService;

        public ConsultaService(ConsultaRepository consultaRepository, PacienteService pacienteService)
        {
            _consultaRepository = consultaRepository;
            _pacienteService = pacienteService;
        }

        public bool AgendarConsulta(string cpf, string dataConsultaStr, string horaInicialStr, string horaFinalStr)
        {
            if (!_pacienteService.CPFExistente(cpf))
            {
                Console.WriteLine("Paciente não encontrado.");
                return false;
            }

            if (!DateTime.TryParseExact(dataConsultaStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataConsulta))
            {
                Console.WriteLine("Data da consulta inválida. Use o formato dd/MM/yyyy.");
                return false;
            }

            if (!TimeSpan.TryParseExact(horaInicialStr, "hh\\:mm", null, out TimeSpan horaInicial) ||
                !TimeSpan.TryParseExact(horaFinalStr, "hh\\:mm", null, out TimeSpan horaFinal))
            {
                Console.WriteLine("Hora inicial ou final inválida. Use o formato hh\\:mm.");
                return false;
            }

            DateTime dataHoraInicial = dataConsulta.Add(horaInicial);
            DateTime dataHoraFinal = dataConsulta.Add(horaFinal);

            if (dataHoraInicial <= DateTime.Now || dataHoraFinal <= DateTime.Now)
            {
                Console.WriteLine("A consulta deve ser agendada para um período futuro.");
                return false;
            }

            if (horaFinal <= horaInicial)
            {
                Console.WriteLine("Hora final deve ser maior que a hora inicial.");
                return false;
            }

            if (horaInicial.Minutes % 15 != 0 || horaFinal.Minutes % 15 != 0)
            {
                Console.WriteLine("As horas inicial e final devem ser múltiplas de 15 minutos.");
                return false;
            }

            if (horaInicial < new TimeSpan(8, 0, 0) || horaFinal > new TimeSpan(19, 0, 0))
            {
                Console.WriteLine("O horário de funcionamento do consultório é das 8:00h às 19:00h.");
                return false;
            }

            var consultasFuturas = _consultaRepository.Listar()
                .Where(c => c.CPF == cpf && c.DataConsulta >= DateTime.Today)
                .ToList();

            if (consultasFuturas.Any())
            {
                Console.WriteLine("O paciente já possui um agendamento futuro.");
                return false;
            }

            var consultasSobrepostas = _consultaRepository.Listar()
                .Where(c => c.DataConsulta == dataConsulta &&
                            ((c.HoraInicial < horaFinal && c.HoraFinal > horaInicial) ||
                             (c.HoraInicial >= horaInicial && c.HoraInicial < horaFinal) ||
                             (c.HoraFinal > horaInicial && c.HoraFinal <= horaFinal)))
                .ToList();

            if (consultasSobrepostas.Any())
            {
                Console.WriteLine("Já existe uma consulta agendada nesse horário.");
                return false;
            }

<<<<<<< HEAD
=======
=======

        public ConsultaService(ConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public bool AgendarConsulta(string cpf, DateTime dataConsulta, TimeSpan horaInicial, TimeSpan horaFinal)
        {
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
            var consulta = new Consulta
            {
                CPF = cpf,
                DataConsulta = dataConsulta,
                HoraInicial = horaInicial,
                HoraFinal = horaFinal
            };
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e

            _consultaRepository.Adicionar(consulta);
            return true;
        }
<<<<<<< HEAD

        public List<Consulta> ListarConsultas()
=======
public List<Consulta> ListarConsultas()
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
        {
            return _consultaRepository.Listar();
        }

        public List<Consulta> ListarConsultasOrdenadoPorDataHora()
        {
            return _consultaRepository.ListarOrdenadoPorDataHora();
        }

        public bool ConsultaExistente(string cpf, DateTime dataConsulta, TimeSpan horaInicial)
        {
            return _consultaRepository.ConsultaExistente(cpf, dataConsulta, horaInicial);
        }

        public void RemoverConsulta(string cpf, DateTime dataConsulta, TimeSpan horaInicial)
        {
            _consultaRepository.Remover(cpf, dataConsulta, horaInicial);
        }

        public bool PacienteExistente(string cpf)
        {
            return _pacienteService.CPFExistente(cpf);
        }

        public Paciente ObterPacientePorCPF(string cpf)
        {
            return _pacienteService.ObterPacientePorCPF(cpf);
        }
<<<<<<< HEAD
=======
=======
            _consultaRepository.Adicionar(consulta);
            return true;
        }

        public List<Consulta> ListarConsultas()
        {
            return _consultaRepository.Listar();
        }
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
    }
}