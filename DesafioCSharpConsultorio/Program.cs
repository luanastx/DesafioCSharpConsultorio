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

            var pacienteService = new PacienteService(pacienteRepository, consultaRepository);
            var consultaService = new ConsultaService(consultaRepository, pacienteService);

            var pacienteController = new PacienteController(pacienteService);
            var consultaController = new ConsultaController(consultaService);

            var menuPrincipal = new MenuPrincipal(pacienteController, consultaController);
            menuPrincipal.ExibirMenu();
        }
    }
}