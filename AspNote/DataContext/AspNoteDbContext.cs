using System.Configuration;
using System.Data.Common;
using AspNote.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AspNote.DataContext
{
    public class AspNoteDbContext : DbContext
    {
        // public AspNoteDbContext(DbContextOptions<AspNoteDbContext> options): base(options)
        // {
        //     
        // }
        //

        protected readonly IConfiguration Configuration;
        public AspNoteDbContext()
        {
           
        }

        public AspNoteDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

      

        public DbSet<User> Users { get; set; } 
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connnectionString = Configuration.GetConnectionString("Default");
            options.UseMySql(connnectionString, ServerVersion.AutoDetect(connnectionString));
        }
        // protected override void OnModelCreating(DbModelBuilder  modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<User>.MapToStoredProcedures();
        // }


        // DB connection
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //
        //         optionsBuilder.UseMySQL("@Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;");
        //     }
        //
        //     // optionsBuilder.UseMySQL(@"Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;",
        //     //     options => optioinsBuilder.Enable);
        // }

        // protected override void OnConfiguring(DbContextOptionsBuilder ptionsBuilder)
        // {
        //     // optionsBuilder.UseMySql(ServerVersion.AutoDetect("Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;"));
        //
        //     optionsBuilder.UseMySql(
        //         ServerVersion.AutoDetect(
        //             "Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;"),
        //             options => options.EnableRetryOnFailure( ));
        // }
        
    } 
} 