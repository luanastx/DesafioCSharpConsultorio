using System;

namespace ConsultorioOdontologico.Models
{
    public class Paciente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
<<<<<<< HEAD
        public int Idade => DateTime.Now.Year - DataNascimento.Year - (DateTime.Now.DayOfYear < DataNascimento.DayOfYear ? 1 : 0);
=======
        public int Idade => DateTime.Now.Year - DataNascimento.Year;
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
    }
}