using System.Configuration;
using System.Data.Common;
using AspNote.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AspNote.DataContext
{
    public class AspNoteDbContext : DbContext
    {
        public AspNoteDbContext(DbContextOptions<AspNoteDbContext> options): base(options)
        {
            
        }
      

        public AspNoteDbContext()
        {
           
        }  

        public DbSet<User> Users { get; set; } 
        public DbSet<Note> Notes { get; set; }

        // protected override void OnModelCreating(DbModelBuilder  modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<User>.MapToStoredProcedures();
        // }


        // DB connection
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySQL(@"Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;",
        //         options => optioinsBuilder.Enable);
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;");

            // optionsBuilder.UseMySql(
            //     ServerVersion.AutoDetect(
            //         "Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;"),
            //         options => options.EnableRetryOnFailure( ));
        }
        
    } 
} 