using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ConversorMVC.Models // MVC Model - representa os dados da aplica��o (Classes)
{
    public class ConversorViewModel
    {
        [Required(ErrorMessage ="Por favor introduza um valor v�lido.")] // Valida��es para o model state, obriga o utilizador a introduzir valor valido e caso n�o o fa�a envia uma mensagem de erro.
        public string ConvertionType {get; set;}

        [Required(ErrorMessage = "Por favor introduza um valor v�lido.")]
        public string Input {get; set;}

        [HiddenInput(DisplayValue = false)]
        public string Output {get; set;}
    }
    
}