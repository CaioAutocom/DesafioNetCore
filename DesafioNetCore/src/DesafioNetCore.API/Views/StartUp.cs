using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DesafioNetCore.API.Views;

public static class StartUp
{
    public static IApplicationBuilder ConfigureMvc(this IApplicationBuilder app)
    {
        app.UseMvc();
        // entrega os arquivos de estilo e js para o browser
        app.UseStaticFiles();
        return app;
    }

    public static IEndpointRouteBuilder UseMapRoutes(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapControllerRoute(
            "login",
            "{controller=Login}/{action=Index}/"
        );

        endpointRouteBuilder.MapControllerRoute(
           "modulos",
           "modulos/{controller=Home}/{action=Index}/{id?}"
       );

        endpointRouteBuilder.MapControllerRoute(
            "default",
            "{controller=Home}/{action=Index}/{id?}"
        );

        return endpointRouteBuilder;
    }
}
