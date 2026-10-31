using Microsoft.Extensions.Logging;

namespace MauiAppHotel
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
                    fonts.AddFont("PTSerif-Bold.ttf", "PTSerifBold");
                    fonts.AddFont("PTSerif-BoldItalic.ttf", "PTSerifBoldItalic");
                    fonts.AddFont("PTSerif-Italic.ttf", "PTSerifItalic");
                    fonts.AddFont("PTSerif-Regular.ttf", "PTSerifRegular");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
