using System.ComponentModel.DataAnnotations;

namespace AspNote.Models
{
    public class User
    {
        [Key]
        public int UserNo { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public string UserPassword { get; set; }
    }
} 