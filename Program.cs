using System.Collections.Generic;
using System.ComponentModel;

namespace FirstBlazorApp
{
    public class Program
    {
        // “Blazor Server” configuration
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Start by adding support for Razor Pages in the app since Blazor needs Razor Pages to work
            builder.Services.AddRazorPages();

            //add Server-Side Blazor services to the service collection
            builder.Services.AddServerSideBlazor();


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            //integrate Blazor with ASP.NET Core Endpoint Routing
            //It allows app to call any Razor component from inside the ASP.NET Core Controller’s views or Razor pages.
            //This will let SignalR which is the part of ASP.NET Core that handles the persistent HTTP request to work properly
            app.MapBlazorHub();

            app.MapGet("/", context =>
            {
                context.Response.Redirect("/Iexample");
                return Task.CompletedTask;
            });

           

            //First the Fallback Route which is _Host.cshtml is called.
            //Fallback Route là route dự phòng, nó có độ ưu tiên thấp, chỉ được gọi khi mà những route khác không match
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
