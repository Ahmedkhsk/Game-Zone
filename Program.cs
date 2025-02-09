using Project.Repository;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DB
            //var connectionString = builder.Configuration.GetConnectionString("Db") 
            //    ?? throw new InvalidOperationException("No Connetion String was Found"); 
       
            builder.Services.AddDbContext<Context>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Db"));
                }
                );

            //Register
            builder.Services.AddScoped<IGameRepository,GameRepository>();
            builder.Services.AddScoped<IDeviceRepository,DeviceRepository>();
            builder.Services.AddScoped<ICategorieRepository,CategorieRepository>();
            builder.Services.AddScoped<IGameDeviceRepository,GameDeviceRepository>();


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
