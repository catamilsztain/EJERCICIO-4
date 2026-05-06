using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EJ4_FORM.Models;

namespace EJ4_FORM.Controllers;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public ActionResult GuardarDatos(string nombre, int edad, int DNI, string trabaja, string tipoEmpleo, double ingresos, 
    string deudas, List<string> deudi, double monto, string plazo, string terminosyco){
        bool accede = true;
        if (edad < 18 || trabaja == "No" || ingresos < 250000 || monto < ingresos*5 || deudas == "Sí" || terminosyco == "No")
        {
           accede = false;
            return View("denegado");
        }
        else{

            accede = true;
            return View("aceptado");
        }

        ViewBag.acceso = accede;
        return View("denegado");


    }
}
