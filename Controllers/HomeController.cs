using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05___FRIDMAN_DE_MARCO_WILDER.Models;

namespace TP05___FRIDMAN_DE_MARCO_WILDER.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Tutorial()
        {
            return View();
        }
        public IActionResult Comenzar()
        {
            int estado = Escape.GetEstadoJuego();
            return RedirectToAction("Habitacion", new { sala = estado });
        }
        public IActionResult Habitacion(int sala, string clave)
        {
            if (sala != Escape.GetEstadoJuego())
            {
                return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });
            }

            bool resultado = Escape.ResolverSala(sala, clave);

            if (resultado)
            {
                if (sala == 6)
                {
                    return RedirectToAction("Victoria");
                }
                else
                {
                    return RedirectToAction("Habitacion", new { sala = sala + 1 });
                }
            }
            else
            {
                ViewBag.Error = "Clave incorrecta. Inténtalo nuevamente.";
                return View($"Habitacion{sala}");
            }
        }
        public IActionResult Habitacion(int sala)
        {
            if (sala != Escape.GetEstadoJuego())
            {
                return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });
            }

            return View($"Habitacion{sala}");
        }

        public IActionResult Victoria()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
}