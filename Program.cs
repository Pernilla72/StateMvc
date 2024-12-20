using StateMvc.Services;

namespace StateMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<DataService>();
            builder.Services.AddTransient<StateService>();
            //builder.Services.AddScoped<IDataService, DataService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();

            var app = builder.Build();

            app.UseSession();
            app.UseHttpsRedirection();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error/exception");
                app.UseStatusCodePagesWithRedirects("/error/http/{0}");
            }

            //app.MapGet("/", () => "Hello World!");
            app.MapControllers();
            app.UseStaticFiles();
            app.Run();
        }
    }
}
