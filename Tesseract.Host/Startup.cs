using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Tesseract.DI;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Tesseract.Database.Migrators._2018._10;

namespace Tesseract
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
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Configuration.GetConnectionString("Master");
            var serviceProvider = services.AddFluentMigratorCore()
            .Configure<AssemblySourceOptions>(x => x.AssemblyNames = new[] { typeof(Migration_1810190).Assembly.GetName().Name })
            .ConfigureRunner(rb => rb
            .AddSqlServer2016()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(typeof(Migration_1810190).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole()).BuildServiceProvider(false);

            using (var scope = serviceProvider.CreateScope())
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }

            var employeeModule = new EmployeeModule();
            employeeModule.Load(services);

            var databaseModule = new DatabaseModule();
            databaseModule.Load(services, connectionString);

            var financeModule = new FinanceModule();
            financeModule.Load(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
