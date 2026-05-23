using Microsoft.AspNetCore.Mvc;
using BarberTech.Models;
using BarberTech.Data;

namespace BarberTech.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly AppDbContext _context;

        public AgendamentoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Agendamentos.Add(agendamento);

                _context.SaveChanges();

                return RedirectToAction("Lista");
            }

            return View("Index");
        }

        public IActionResult Lista()
        {
            var lista = _context.Agendamentos.ToList();

            return View(lista);
        }
    public IActionResult Excluir(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);

            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);

                _context.SaveChanges();
            }

            return RedirectToAction("Lista");
        }
        public IActionResult Editar(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);

            return View(agendamento);
        }

        [HttpPost]
        public IActionResult Editar(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);

            _context.SaveChanges();

            return RedirectToAction("Lista");
        }
    }
}
