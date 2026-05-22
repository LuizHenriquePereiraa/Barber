using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(string usuario, string senha)
        {
            if (usuario == "admin" && senha == "123")
            {
                return RedirectToAction("Index", "Agendamento");
            }

            ViewBag.Erro = "Usuário ou senha inválidos";

            return View("Index");
        }
    }
}

