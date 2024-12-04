using BarCodeDemo.ViewCommands;
namespace BarCodeDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IBarcodeScannerService, BarcodeScannerService>();

            MainPage = new AppShell();
        }
    }
}
