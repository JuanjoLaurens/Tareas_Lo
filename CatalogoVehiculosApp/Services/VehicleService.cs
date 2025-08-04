using System.Text.Json;
using CatalogoVehiculosApp.Models;

namespace CatalogoVehiculosApp.Services;

// Servicio encargado de descargar y deserializar el JSON de vehículos.
public class VehicleService
{
    private readonly HttpClient _httpClient = new();

    // URL del archivo JSON alojado en GitHub
    private const string Url = "https://raw.githubusercontent.com/JUANCITOPENA/ARCHIVO_JSON_FOTOS_AUTOS_CLASE/main/vehiculos.json";

    // Descarga el JSON y lo convierte a una lista de objetos Vehicle
    public async Task<List<Vehicle>> GetVehiclesAsync()
    {
        using var stream = await _httpClient.GetStreamAsync(Url);
        // Opciones de deserialización para ignorar mayúsculas/minúsculas
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var vehicles = await JsonSerializer.DeserializeAsync<List<Vehicle>>(stream, options);
        return vehicles ?? new List<Vehicle>();
    }
}
