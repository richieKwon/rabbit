using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNote.Models
{
    public class Note
    {
        [Key]
        public int NoteNo { get; set; }
        
        [Required(ErrorMessage = "Put down the title of your article")]
        public string NoteTitle { get; set; }
        
        [Required(ErrorMessage = "Type down your article")]
        public string NoteContents { get; set; }
        
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
    }  
}