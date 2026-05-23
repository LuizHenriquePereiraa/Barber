using Microsoft.AspNetCore.Mvc;
using BarberTech.Data;

namespace BarberTech.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalAgendamentos =
                _context.Agendamentos.Count();

            ViewBag.TotalCortes =
                _context.Agendamentos
                .Count(a => a.Servico == "Corte");

            ViewBag.TotalBarbas =
                _context.Agendamentos
                .Count(a => a.Servico == "Barba");

            ViewBag.TotalSobrancelha =
                _context.Agendamentos
                .Count(a => a.Servico == "Sobrancelha");

            ViewBag.ProximosAgendamentos =
                _context.Agendamentos
                .OrderBy(a => a.DataHora)
                .ToList();

            return View();
        }
    }
}