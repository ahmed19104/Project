using Microsoft.EntityFrameworkCore;
using NToastNotify;
using Project.Data;



namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("conString")));
            builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = true,
                PositionClass = ToastPositions.TopRight,
                PreventDuplicates = true,
                CloseButton = true
            });
            builder.Services.AddScoped<Data.Services.IActorsServices, Data.Services.ActorsService>();
            //builder.Services.AddScoped<Data.Services.IProducersService, Data.Services.ProducersService>();
            //builder.Services.AddScoped<Data.Services.ICinemasService, Data.Services.CinemasService>();
            builder.Services.AddScoped<Data.Services.IMovicesService, Data.Services.MoviesService>();
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
            AppDbInitialzier.Initialize(app);
            app.Run();
        }
    }
}
