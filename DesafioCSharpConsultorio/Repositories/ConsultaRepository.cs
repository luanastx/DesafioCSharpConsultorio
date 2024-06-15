using System.Collections.Generic;
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
    }
}