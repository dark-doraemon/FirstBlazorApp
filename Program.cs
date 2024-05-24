using System.Collections.Generic;
using System.ComponentModel;

namespace FirstBlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //sử dụng Blazor cần phải có Razor pages
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();//Blazor


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapBlazorHub();

            //First the Fallback Route which is _Host.cshtml is called.
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
