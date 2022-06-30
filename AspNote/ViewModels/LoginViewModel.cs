using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace AspNote.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Inpur your ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Input your password")]
        public string UserPassword { get; set; }
    }
}