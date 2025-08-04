namespace CatalogoVehiculosApp.Models;

// Clase que representa cada vehículo del catálogo.
// Las propiedades coinciden con los nombres del archivo JSON remoto.
public class Vehicle
{
    public int Codigo { get; set; }
    public string? Marca { get; set; }
    public string? Logo { get; set; }
    public string? Tipo { get; set; }
    public string? Modelo { get; set; }
    public string? Caracteristicas { get; set; }
    public string? Imagen { get; set; }
    public int NumeroPuertas { get; set; }
    public string? Motor { get; set; }
    public string? Combustible { get; set; }
    public string? Categoria { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }
    public int Existencia { get; set; }
}
