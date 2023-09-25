using ISM_Y1_Marin_Ioana_Web_Cloud_Project.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

            builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDBContext>();
            builder.Services.AddScoped<IRepository, EFRepository>();

            //Configure password required length, account lockout and other requirements
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });

            //Configurations
            var app = builder.Build();
            app.UseStaticFiles();
            //Configurations for authentication + authorization
            app.UseAuthentication();
            app.UseAuthorization();

            //redirect HTTP requests to HTTPS
            app.UseHttpsRedirection();

            //send HTTP Strict Transport Security Protocol (HSTS) headers to clients
            app.UseHsts();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();


            SeedData.EnsurePopulated(app);
            Task.Run(async () =>  await SeedDataIdentity.PopulationAsync(app)).Wait();

            app.Run();
        }
    }
}