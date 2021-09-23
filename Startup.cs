using System.IO;
using ForbExpress.DAL.DbContexts;
using ForbExpress.DAL.Repositories.ContractsRepository;
using ForbExpress.DAL.Repositories.CorrespondenceRepository;
using ForbExpress.DAL.Repositories.PartnersRepository;
using ForbExpress.Models.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ForbExpress
{
    public class Startup
    {

        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddRazorRuntimeCompilation();

            services.AddEntityFrameworkNpgsql().AddDbContext<ForbDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("MainConnection")));
            
            services.AddEntityFrameworkNpgsql().AddDbContext<UsersIdentityContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("MainConnection")));
            
            services.AddTransient<IPartnersRepository, EfPartnersRepository>();
            
            services.AddTransient<IContractsRepository, TestContractsRepository>();
            
            services.AddSingleton<ICorrespondenceRepository, TestCorrespondenceRepository>();

            services.AddIdentity<User, IdentityRole>(opt =>
                    {
                        opt.Password.RequiredLength = 8;
                        opt.User.RequireUniqueEmail = true;
                    }
                )
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<UsersIdentityContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            
            app.UseStaticFiles();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Contracts}/{action=Index}/{pageNumber?}/{pageCapacity?}");
            });
        }
    }
}