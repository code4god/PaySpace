using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaySpace.DataLayer;
using PaySpace.DataLayer.Repository;
using PaySpace.TaxCalculator;

namespace PaySpace.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("PaySpaceConnectionString");
            SetMigrate(connectionString);
            services.AddDbContextPool<PaySpaceContext>(options => options.UseSqlServer(connectionString));            
            services.AddScoped<ICalculator, Calculator>();  
            services.AddControllers();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ITaxRepository, TaxRepository>();
            services.AddScoped<IPostalCodeRepository, PostalCodeRepository>();
            services.AddScoped<ICalculationTypesRepository, CalculationTypesRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });          
        }

        private void SetMigrate(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaySpaceContext>();
            optionsBuilder.UseSqlServer(connectionString);
            using (var context = new PaySpaceContext(optionsBuilder.Options))
            {
                context.Database.Migrate();
            }
        }
    }
}
