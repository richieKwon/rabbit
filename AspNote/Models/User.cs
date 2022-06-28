using System.ComponentModel.DataAnnotations;

namespace AspNote.Models
{
    public class User
    {
        [Key]
        public int UserNo { get; set; }
        
        [Required(ErrorMessage = "Input User name!")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Input User ID")]
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "Input correct Password")]
        public string UserPassword { get; set; }
    }
} 