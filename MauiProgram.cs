using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using SkiaSharp.Views.Maui.Controls.Hosting;

#if IOS
using Maui.FixesAndWorkarounds;
#endif

namespace MauiArabic;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
#if IOS
            .ConfigureRTLFixes()
#endif
			;


#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}
