using AspNote.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AspNote.DataContext
{
    public class AspNoteDbContext : DbContext
    {
        public AspNoteDbContext(DbContextOptions<AspNoteDbContext> options): base(options)
        {
            
        }
        public DbSet<User> Users { get; set; } 
        public DbSet<Note> Notes { get; set; }
        
        // DB connection
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySQL(@"Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;");
        // }
    } 
}