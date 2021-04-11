using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using FF.Models;

namespace FF {
    public class Startup {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration config) {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            services.AddDbContext<FFDbContext>(opts =>
            opts.UseSqlServer(Configuration["ConnectionStrings:FFConnection"]));

            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentsSubjectsRepository, StudentsSubjectsRepository>();

            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentsSubjectsRepository, StudentsSubjectsRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IProtocolRepository, ProtocolRepository>();

            services.AddDbContext<FFIdentityDbContext>(opts =>
            opts.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<FFIdentityDbContext>();

            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/User/Login");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("Default","",
                    new { Controller = "User", action = "Index" });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                
            }
                );
            IdentitySeedData.EnsurePopulated(app);
            SeedStudentData.EnsurePopulated(app);
            SeedSubjectData.EnsurePopulated(app);
            SeedStudentsSubjectData.EnsurePopulated(app);
            SeedProtocolData.EnsurePopulated(app);
        }
    }
}