namespace CatalogoVehiculosApp;

public partial class App : Application
{
    // La página principal de la aplicación se establece en MainPage
    public App(MainPage mainPage)
    {
        InitializeComponent();
        MainPage = new NavigationPage(mainPage);
    }
}
