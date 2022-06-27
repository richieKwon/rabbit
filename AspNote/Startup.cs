using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNote.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
// using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AspNote
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddCors();
            // services.AddDbContext<AspNoteDbContext>(options => options.UseMySQL(
            //     Configuration.GetConnectionString("Default")));


            // string mySqlConnectionStr = Configuration.GetConnectionString("Default");
            // services.AddDbContextPool<AspNoteDbContext>(options =>
            //     options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddControllers();


            // services.AddDbContextPool<AspNoteDbContext>(options =>
            // {
            //     string connectionString = Configuration.GetConnectionString("Default");
            //     options.UseMySql(connectionString,
            //             ServerVersion.AutoDetect(connectionString),
            //             mySqlOptions =>
            //                 mySqlOptions.EnableRetryOnFailure(
            //                     maxRetryCount: 10,
            //                     maxRetryDelay: TimeSpan.FromSeconds(30),
            //                     errorNumbersToAdd: null)
            //         );
            // });


            // services.AddDbContext<AspNoteDbContext>(
            //     options =>
            //         options.UseMySql(Configuration.GetConnectionString("DatabaseConnectionString"),
            //             new MySqlServerVersion(new Version()),
            //             mySqlOptionsAction: options => { options.EnableRetryOnFailure(); }));
            services.AddMvc();

            //     services.AddDbContext<AspNoteDbContext>(options =>
            //     {
            //         // string connectionString = AppConfig.Configuration.GetConnectionString("DefaultConnection");
            //         string connectionString = "Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;";
            //
            //         options.UseMySql(connectionString,
            //             ServerVersion.AutoDetect(connectionString),
            //             mySqlOptions =>
            //                 mySqlOptions.EnableRetryOnFailure(
            //                     maxRetryCount: 10,
            //                     maxRetryDelay: TimeSpan.FromSeconds(30),
            //                     errorNumbersToAdd: null)
            //         );
            //     });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}