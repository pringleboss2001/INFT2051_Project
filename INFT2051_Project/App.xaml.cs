using INFT2051_Project.Services.PartialMethods;
using SQLite;
using INFT2051_Project.Services;
using INFT2051_Project.Models;

namespace INFT2051_Project
{
    public partial class App : Application
    {

        private readonly DatabaseService _connection;

        public App(DatabaseService connection)
        {
            InitializeComponent();

            WindowSizeHandler.CallSetWindowSize();

            MainPage = new AppShell();

            _connection = connection;
        }

        protected override async void OnStart()
        {
            ISQLiteAsyncConnection database = _connection.CreateConnection();

            CreateTableResult createTableResult = await database.CreateTableAsync<TopicData>();

            base.OnStart();
        }
    }
}
