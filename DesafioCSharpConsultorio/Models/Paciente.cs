using System;

namespace ConsultorioOdontologico.Models
{
    public class Paciente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade => DateTime.Now.Year - DataNascimento.Year;
    }
}