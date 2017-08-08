using System.ComponentModel.DataAnnotations;

namespace Amesc.WebApp.ViewModels
{
    public class AutenticacaoViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
