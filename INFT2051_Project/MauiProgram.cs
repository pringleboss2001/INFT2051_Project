using Microsoft.Extensions.Logging;
using SQLite;

namespace INFT2051_Project
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Cambria-Math.ttf", "CambriaMath");
                    fonts.AddFont("lmroman10-italic.ttf", "RomanMath");
                });

#if DEBUG
            

            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
