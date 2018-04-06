using System.Globalization;
using Amesc.Data.Contexts;
using Amesc.Data.Identity;
using Amesc.Data.Repositorios;
using Amesc.Dominio;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Contas;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
using Amesc.WebApp.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Amesc.Dominio.Cursos.Instrutores;

namespace Amesc.WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(config => {

                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 3;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Autenticacao");

            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(ICursoRepositorio), typeof(CursoRepositorio));
            services.AddScoped(typeof(IInstrutorRepositorio), typeof(InstrutorRepositorio));
            services.AddScoped(typeof(IAlunoRepositorio), typeof(AlunoRepositorio));
            services.AddScoped(typeof(ICursoAbertoRepositorio), typeof(CursoAbertoRepositorio));
            services.AddScoped(typeof(IMatriculaRepositorio), typeof(MatriculaRepositorio));
            services.AddScoped(typeof(IAutenticacao), typeof(Autenticacao));
            services.AddScoped(typeof(ArmazenadorDeAluno));
            services.AddScoped(typeof(CanceladorDeMatricula));
            services.AddScoped(typeof(ArmazenadorDeCurso));
            services.AddScoped(typeof(ArmazenadorDeInstrutor));
            services.AddScoped(typeof(ArmazenadorDeCursoAberto));
            services.AddScoped(typeof(CriacaoDeMatricula));
            services.AddScoped(typeof(AlteracaoDeDadosDaMatricula));

            services.AddMvc(config => {
                config.Filters.Add(typeof(CustomExceptionFilter));
            });

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Use(async (context, next) =>
            {
                //Request
                try
                {
                    await next.Invoke();

                    var applicationDbContext = (ApplicationDbContext)context.RequestServices.GetService(typeof(ApplicationDbContext));
                    //Response
                    await applicationDbContext.Commit();
                }
                catch(Exception ex)
                {

                }
                
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            var supportedCultures = new[] { new CultureInfo("pt-BR") };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
