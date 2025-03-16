using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DatacomTestProject.Data.Repositories;
using DatacomTestProject.Data;
using DatacomTestProject.Services;

public class Startup
{
    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    /// <param name="services">The service collection.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        // Configure the database context to use an in-memory database
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("JobApplications"));

        // Register the application repository and service
        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddScoped<ApplicationService>();

        // Add controllers to the services
        services.AddControllers();

        // Configure Swagger for API documentation
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Job Applications API", Version = "v1" });
        });

        // Configure CORS to allow requests from the React app running on localhost:3000
        services.AddCors(options =>
        {
            options.AddPolicy("LocalhostPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    /// <summary>
    /// Configures the HTTP request pipeline.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web host environment.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Use the developer exception page in development environment
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Enable CORS with the specified policy
        app.UseCors("LocalhostPolicy");

        // Enable routing
        app.UseRouting();

        // Enable authorization
        app.UseAuthorization();

        // Map controller endpoints
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        // Enable Swagger and Swagger UI
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Job Applications API V1");
            c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
        });
    }
}