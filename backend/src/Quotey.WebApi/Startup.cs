using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quotey.Domain.Quotes.Services;
using Quotey.Persistence.SqlServer;
using Quotey.Persistence.SqlServer.Repositories;
using Quotey.WebApi.Extensions;

namespace Quotey.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<QuoteyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("QuoteyDatabase")));

            services.AddTransient<IQuotesRepository, QuotesRepository>();

            services.AddBrickweaveCqrs();

            services
                .AddCors()
                .AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Environment.IsDevelopment()
                        ? Formatting.Indented
                        : Formatting.None;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());


            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
