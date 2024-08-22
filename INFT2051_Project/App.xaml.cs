using INFT2051_Project.Services.PartialMethods;

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
