using Microsoft.AspNetCore.Mvc; // MVC Controllers - contem as requesições HTTP
using ConversorMVC.Models;

namespace ConversorMVC.Controllers
{
    public class ConversorController : Controller
    {
        private readonly IConversorService _conversorService;

        public ConversorController(IConversorService conversorService)
        {
            _conversorService = conversorService;
        }

        [HttpGet] // Vai buscar a View (HTML)
        public IActionResult Index()
        {
            return View(new ConversorViewModel());
        }

        [HttpPost] // Vai enviar o que foi introduzido na View (HTML) para os services
        public IActionResult Index(ConversorViewModel model)
        {
            Console.WriteLine("POST recebido!");
            ModelState.Remove("Output");

            foreach (var item in ModelState)
            {
                if (item.Value.Errors.Count > 0)
                {
                    Console.WriteLine($"Campo: {item.Key}");
                    foreach (var error in item.Value.Errors)
                    {
                        Console.WriteLine($"Erro: {error.ErrorMessage}");
                    }
                }
            }

            if (ModelState.IsValid) // Valida se os dados introduzidos são válidos.
            {
                model.Output = _conversorService.Converter(model.ConvertionType, model.Input);
                Console.WriteLine($"Resultado da conversão: {model.Output}");
            }
            else
            {
                Console.WriteLine(model.Input);
                Console.WriteLine(model.ConvertionType);
                Console.WriteLine("ModelState inválido!");
            }
                return View(model);
        }
    }
}





