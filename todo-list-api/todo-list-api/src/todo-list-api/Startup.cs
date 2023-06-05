
using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoList
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
            // get connection string from config and connect
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("DefaultConnection setting not defined in appsettings.json");
            }

            services.AddDbContext<ToDoDbContext>(x => x.UseSqlServer(connectionString,
                builder =>
                {
                    builder.CommandTimeout(800);
                    builder.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null);

                }));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                var origins = new List<string>
                {
                    "https://todo.thisnameischeapbecauseitsverylong.com",
                    "http://localhost:4200",
                    "https://localhost:4200"
                };

                options
                .WithOrigins(origins.ToArray())
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello from To Do List Web API Lambda");
                });
            });
        }
    }
}