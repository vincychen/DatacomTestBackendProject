using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DatacomTestProject.Data.Repositories;
using DatacomTestProject.Data;
using DatacomTestProject.Services;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("JobApplications"));

        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddScoped<ApplicationService>();

        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Job Applications API", Version = "v1" });
        });

        services.AddCors(options =>
        {
            options.AddPolicy("LocalhostPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3001") // React app running on localhost:3000
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors("LocalhostPolicy");

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Job Applications API V1");
            c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
        });
    }
}