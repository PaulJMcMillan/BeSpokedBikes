using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Repositories;
using BeSpokedBikes.Services;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, 
                sqlServerOptions=>sqlServerOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));
            builder.Services.AddScoped<ISalesPersonService, SalesPersonService>();
            builder.Services.AddScoped<ISalesPersonRepository, SalesPersonRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
