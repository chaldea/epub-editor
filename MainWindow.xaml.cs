using Chaldea.Epub.Core;
using Chaldea.Epub.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Chaldea.Epub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppState _appState = new();
        private readonly ServiceProvider serviceProvider;

        public MainWindow()
        {
            var services = new ServiceCollection();
            services.AddBlazorWebView();
            services.AddAntDesign();
            services.AddSingleton<AppState>(_appState);
            services.AddSingleton<NativeService>();
            services.AddScoped<JsInterop>();
            services.AddScoped<ProjectService>();
            serviceProvider = services.BuildServiceProvider();
            Resources.Add("services", serviceProvider);
            InitializeComponent();
            CenterWindowOnScreen();
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = Width;
            double windowHeight = Height;
            Left = (screenWidth / 2) - (windowWidth / 2);
            Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }

    public partial class Main { }
}
