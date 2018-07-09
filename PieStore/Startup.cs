using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using PieStore.Models;

namespace PieStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Mac-version
            /*
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    "Data Source=127.0.0.1,1433;Database=PieDb;User ID=sa;Password=Nakisa@3160448"));
            */

            //Win version
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    @"Server=.\;Database=PieDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddIdentity<IdentityUser,IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
            
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddTransient<IFeedbackRepository,FeedbackRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute( 
                    name:"default",
                    template:"{controller=Home}/{action=Index}/{id?}");

            });

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
