using EK_tracker.Data;
using Microsoft.EntityFrameworkCore;

namespace EK_tracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddAuthentication("UserCookie").AddCookie("UserCookie", options =>
            {
                options.Cookie.Name = "UserCookie";
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/AccessDenied";
            });


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
