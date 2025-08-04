using System.Collections.ObjectModel;
using System.ComponentModel;
using CatalogoVehiculosApp.Models;
using CatalogoVehiculosApp.Services;

namespace CatalogoVehiculosApp;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    private readonly VehicleService _vehicleService;
    private List<Vehicle> _allVehicles = new();
    private string _searchText = string.Empty;

    public ObservableCollection<Vehicle> Vehicles { get; } = new();

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText == value)
                return;
            _searchText = value;
            OnPropertyChanged();
            ApplyFilter();
        }
    }

    public MainPage(VehicleService vehicleService)
    {
        InitializeComponent();
        _vehicleService = vehicleService;
        BindingContext = this; // Establece el contexto para data binding
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Evita recargar los datos si ya se descargaron
        if (_allVehicles.Count > 0)
            return;

        try
        {
            // Descarga asincrónicamente el archivo JSON y lo deserializa
            var vehicles = await _vehicleService.GetVehiclesAsync();

            _allVehicles = vehicles;
            Vehicles.Clear();
            foreach (var vehicle in vehicles)
            {
                Vehicles.Add(vehicle);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudieron cargar los datos: {ex.Message}", "Aceptar");
        }
    }

    private void ApplyFilter()
    {
        var filtered = string.IsNullOrWhiteSpace(_searchText)
            ? _allVehicles
            : _allVehicles.Where(v =>
                (v.Marca?.Contains(_searchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (v.Tipo?.Contains(_searchText, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();

        Vehicles.Clear();
        foreach (var vehicle in filtered)
        {
            Vehicles.Add(vehicle);
        }
    }
}
