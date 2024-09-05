using Microsoft.EntityFrameworkCore;
using Sales_NET8.Web.Data;
using System.Drawing.Text;

namespace Sales_NET8.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();


            //Add Runtime Compilation
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            //Inject datacontext
            builder.Services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection"));
            });

            builder.Services.AddTransient<SeedDb>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            RunSeeding(app);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }


        private static void RunSeeding(WebApplication app)
        {
            var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<SeedDb>();
                seeder.SeedAsync().Wait(); 
            }
        }
    }
}
