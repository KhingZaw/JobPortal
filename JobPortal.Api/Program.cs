using JobPortal.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<JobPortalContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("JobPortalContext")));

            builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}