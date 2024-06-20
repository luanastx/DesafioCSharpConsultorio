<<<<<<< HEAD
﻿using System.Collections.Generic; 
using System.Linq;
=======
﻿using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
=======
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
using ConsultorioOdontologico.Models;

namespace ConsultorioOdontologico.Repositories
{
    public class PacienteRepository
    {
        private readonly List<Paciente> _pacientes = new List<Paciente>();

        public void Adicionar(Paciente paciente)
        {
            _pacientes.Add(paciente);
        }
<<<<<<< HEAD
=======

<<<<<<< HEAD
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
        public void Remover(string cpf)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.CPF == cpf);
            if (paciente != null)
            {
                _pacientes.Remove(paciente);
            }
        }

        public List<Paciente> ListarOrdenadoPorCPF()
        {
            return _pacientes.OrderBy(p => p.CPF).ToList();
        }

        public List<Paciente> ListarOrdenadoPorNome()
        {
            return _pacientes.OrderBy(p => p.Nome).ToList();
        }

        public bool CPFExistente(string cpf)
        {
            return _pacientes.Any(p => p.CPF == cpf);
        }

        public Paciente ObterPorCPF(string cpf)
        {
            return _pacientes.FirstOrDefault(p => p.CPF == cpf);
<<<<<<< HEAD
=======
=======
        public List<Paciente> Listar()
        {
            return _pacientes;
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e
        }
    }
}