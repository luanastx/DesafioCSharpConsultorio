using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
=======
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
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
<<<<<<< HEAD

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
=======
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
    }
}