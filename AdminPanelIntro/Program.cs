using AdminPanelIntro.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AdminPanelIntro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conn = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ProniaDbContext>(opt =>
            {
                opt.UseSqlServer(conn);
            });

            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseStaticFiles();


            app.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );


            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
