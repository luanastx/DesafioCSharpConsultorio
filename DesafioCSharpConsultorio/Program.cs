using ConsultorioOdontologico.Controllers;
using ConsultorioOdontologico.Repositories;
using ConsultorioOdontologico.Services;
using ConsultorioOdontologico.Views;

namespace ConsultorioOdontologico
{
    class Program
    {
        static void Main(string[] args)
        {
            var pacienteRepository = new PacienteRepository();
            var consultaRepository = new ConsultaRepository();

<<<<<<< HEAD
            var pacienteService = new PacienteService(pacienteRepository, consultaRepository);
            var consultaService = new ConsultaService(consultaRepository, pacienteService);
=======
<<<<<<< HEAD
            var pacienteService = new PacienteService(pacienteRepository, consultaRepository);
            var consultaService = new ConsultaService(consultaRepository, pacienteService);
=======
            var pacienteService = new PacienteService(pacienteRepository);
            var consultaService = new ConsultaService(consultaRepository);
>>>>>>> a0dc5e61dd2bf873b782059fa2d02b92ab301b79
>>>>>>> 87fa56328a1421ebcd0eb13a7135485f7f74406e

            var pacienteController = new PacienteController(pacienteService);
            var consultaController = new ConsultaController(consultaService);

            var menuPrincipal = new MenuPrincipal(pacienteController, consultaController);
            menuPrincipal.ExibirMenu();
        }
    }
}