using Microsoft.EntityFrameworkCore;

namespace BUMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("BumsConnection") ?? throw new InvalidOperationException("Connection string 'BumsConnection' not found.");

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<BUMSDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddTransient<IGroupService, GroupService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserGroupService, UserGroupService>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
