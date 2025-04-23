using Microsoft.AspNetCore.Mvc;
using ConversorMVC.Models;
using ConversorMVC.Services;

namespace ConversorMVC.Controllers
{
    public class ConversorController : Controller
    {
        private readonly IConversorService _conversorService;

        public ConversorController(IConversorService conversorService)
        {
            _conversorService = conversorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ConversorViewModel());
        }

        [HttpPost]
        public IActionResult Index(ConversorViewModel model)
        {
            model.Output = _conversorService.Converter(model.ConvertionType, model.Input);
            return View(model);
        }
    }
}