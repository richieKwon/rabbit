using AspNote.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNote.DataContext
{
    public class AspNoteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        
        // DB connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=127.0.0.0;Database=myDataBase;Uid=root;Pwd=dookie91Sql!;");
        }
    } 
}