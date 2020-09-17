using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YouTubePlaylists.Backend.Model;
using YouTubePlaylists.Backend.ViewModel;

namespace YouTubePlaylists
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Обработчик события Startup
        private void App_Startup(object sender, StartupEventArgs e)
        {
           ViewModel viewModel = new ViewModel();
           
            new MainWindow() { DataContext = viewModel }
             .Show();
        }
    }
}
