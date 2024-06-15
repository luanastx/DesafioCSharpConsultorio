using System;

namespace ConsultorioOdontologico.Models
{
    public class Consulta
    {
        public string CPF { get; set; }
        public DateTime DataConsulta { get; set; }
        public TimeSpan HoraInicial { get; set; }
        public TimeSpan HoraFinal { get; set; }
    }
}