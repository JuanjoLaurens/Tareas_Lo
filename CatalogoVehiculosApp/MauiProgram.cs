using CatalogoVehiculosApp.Services;

namespace CatalogoVehiculosApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                // Se pueden agregar fuentes personalizadas aquí
            });

        // Registro de servicios para inyección de dependencias
        builder.Services.AddSingleton<VehicleService>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
