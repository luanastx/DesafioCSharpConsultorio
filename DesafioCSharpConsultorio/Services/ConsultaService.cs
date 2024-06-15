using System;
using System.Collections.Generic;
using ConsultorioOdontologico.Models;
using ConsultorioOdontologico.Repositories;

namespace ConsultorioOdontologico.Services
{
    public class ConsultaService
    {
        private readonly ConsultaRepository _consultaRepository;

        public ConsultaService(ConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public bool AgendarConsulta(string cpf, DateTime dataConsulta, TimeSpan horaInicial, TimeSpan horaFinal)
        {
            var consulta = new Consulta
            {
                CPF = cpf,
                DataConsulta = dataConsulta,
                HoraInicial = horaInicial,
                HoraFinal = horaFinal
            };
            _consultaRepository.Adicionar(consulta);
            return true;
        }

        public List<Consulta> ListarConsultas()
        {
            return _consultaRepository.Listar();
        }
    }
}