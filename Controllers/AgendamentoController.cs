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
        public IActionResult Salvar(string ClienteNome, string Servico, DateTime DataHora)
        {
            try
            {
                Agendamento novo = new Agendamento();

                novo.ClienteNome = ClienteNome;
                novo.Servico = Servico;
                novo.DataHora = DataHora;

                _context.Agendamentos.Add(novo);

                _context.SaveChanges();

                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }

        public IActionResult Lista()
        {
            var lista = _context.Agendamentos.ToList();

            return View(lista);
        }
    }
}