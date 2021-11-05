using System.ComponentModel.DataAnnotations;

namespace EducacionVitual.ViewsModels
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
