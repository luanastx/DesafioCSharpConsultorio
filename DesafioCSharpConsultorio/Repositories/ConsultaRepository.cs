using System.Collections.Generic;
using System.Linq;
using ConsultorioOdontologico.Models;

namespace ConsultorioOdontologico.Repositories
{
    public class ConsultaRepository
    {
        private readonly List<Consulta> _consultas = new List<Consulta>();

        public void Adicionar(Consulta consulta)
        {
            _consultas.Add(consulta);
        }

        public List<Consulta> Listar()
        {
            return _consultas;
        }

        public bool ConsultaExistente(string cpf, DateTime dataConsulta, TimeSpan horaInicial)
        {
            return _consultas.Any(c => c.CPF == cpf && c.DataConsulta == dataConsulta && c.HoraInicial == horaInicial);
        }

        public void Remover(string cpf, DateTime dataConsulta, TimeSpan horaInicial)
        {
            var consulta = _consultas.FirstOrDefault(c => c.CPF == cpf && c.DataConsulta == dataConsulta && c.HoraInicial == horaInicial);
            if (consulta != null)
            {
                _consultas.Remove(consulta);
            }
        }

        public List<Consulta> ListarOrdenadoPorDataHora()
        {
            return _consultas.OrderBy(c => c.DataConsulta).ThenBy(c => c.HoraInicial).ToList();
        }
    }
}