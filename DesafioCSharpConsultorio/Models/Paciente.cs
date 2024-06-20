using System;

namespace ConsultorioOdontologico.Models
{
    public class Paciente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade => DateTime.Now.Year - DataNascimento.Year - (DateTime.Now.DayOfYear < DataNascimento.DayOfYear ? 1 : 0);
<<<<<<< HEAD

=======
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
    }
}
