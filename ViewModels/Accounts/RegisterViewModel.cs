using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.Accounts
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatorio")]
        [EmailAddress(ErrorMessage = "O e-mail é invalido")]
        public string Email { get; set; }


    }
}
