using FluentValidation;
using FluentValidation.Validators;
using JobPortal.Api.Persistence;
using JobPortal.Shared.Features.ManageJobs.Shared;
using JobPortal.Shared.Features.ManageEmployer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JobPortal.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<JobPortalContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("JobPortalContext")));

            builder.Services.AddScoped<IValidator<JobsDto>, JobsValidator>();

            //builder.Services.AddScoped<IValidator<EmployerDto>, EmployerValidator>();


            builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["Auth0:Authority"];
                options.Audience = builder.Configuration["Auth0:ApiIdentifier"];

                //options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Auth0:Authority"],
                    ValidAudience = builder.Configuration["Auth0:ApiIdentifier"]
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
                RequestPath = new Microsoft.AspNetCore.Http.PathString("/Images")
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}