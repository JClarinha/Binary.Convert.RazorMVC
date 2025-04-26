using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ConversorMVC.Models // MVC Model - representa os dados da aplicação (Classes)
{
    public class ConversorViewModel
    {
        [Required(ErrorMessage ="Por favor introduza um valor válido.")] // Validações para o model state, obriga o utilizador a introduzir valor valido e caso não o faça envia uma mensagem de erro.
        public string ConvertionType {get; set;}

        [Required(ErrorMessage = "Por favor introduza um valor válido.")]
        public string Input {get; set;}

        [HiddenInput(DisplayValue = false)]
        public string Output {get; set;}
    }
    
}