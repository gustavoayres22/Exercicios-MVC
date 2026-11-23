
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjetoMVC.Models;
using PrimeiroProjetoMVC.ViewModels;

namespace PrimeiroProjetoMVC.Controllers
{
    public class EventosController : Controller
    {
        // Lista em memória para armazenar os eventos
        private static List<Evento> eventos = new List<Evento>();

        // GET: Eventos/Index
        public IActionResult Index()
        {
            return View(eventos);
        }

        // GET: Eventos/Criar
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // POST: Eventos/Criar
        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View(evento);
            }

            evento.Id = eventos.Count + 1;
            eventos.Add(evento);

            return RedirectToAction("Index");
        }

        // GET: Eventos/Buscar
        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModel());
        }

        // POST: Eventos/Buscar
        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel vm)
        {
            vm.Resultados = eventos;

            if (!string.IsNullOrWhiteSpace(vm.NomeBusca))
            {
                vm.Resultados = vm.Resultados
                    .Where(e => e.Nome.Contains(
                        vm.NomeBusca,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(vm.LocalBusca))
            {
                vm.Resultados = vm.Resultados
                    .Where(e => e.Local.Contains(
                        vm.LocalBusca,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (vm.DataInicial.HasValue)
            {
                vm.Resultados = vm.Resultados
                    .Where(e => e.DataEvento.Date >= vm.DataInicial.Value.Date)
                    .ToList();
            }

            return View(vm);
        }
    }
}
