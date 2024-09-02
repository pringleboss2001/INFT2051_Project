using INFT2051_Project.Services.PartialMethods;
using SQLite;
using INFT2051_Project.Services;
using INFT2051_Project.Models;
using INFT2051_Project.ViewModels;

namespace INFT2051_Project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            WindowSizeHandler.CallSetWindowSize();

            MainPage = new AppShell();
        }
    }
}
