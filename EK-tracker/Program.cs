using EK_tracker.Data;
using EK_tracker.Models;
using EK_tracker.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;

namespace EK_tracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            var API_KEY = builder.Configuration["x-rapidapi-key"];
            var API_HOST = builder.Configuration["x-rapidapi-host"];
            var GOOGLE_CLIENT_ID = builder.Configuration["google-client-id"];
            var GOOGLE_CLIENT_SECRET = builder.Configuration["google-client-secret"];

            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient<ApiService>(client =>
            {
                client.DefaultRequestHeaders.Add("x-rapidapi-key", API_KEY);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", API_HOST);
            });

            builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(connectionString));
            
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
            })
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login";
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
