using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
namespace GUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IFriendRepository>(service => new FriendRepository(service.GetRequiredService<SocialNetworkContext>()));
            builder.Services.AddScoped<IAccountRepository>(service => new AccountRepository(service.GetRequiredService<SocialNetworkContext>()));
            builder.Services.AddTransient(service => new FriendManager(service.GetRequiredService<IFriendRepository>()));
            builder.Services.AddTransient(service => new AccountManager(service.GetRequiredService<IAccountRepository>()));

            builder.Services.AddDbContext<SocialNetworkContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

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
    }
}