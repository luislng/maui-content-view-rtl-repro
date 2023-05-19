using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace MauiArabic;

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
			})
            .ConfigureMauiHandlers(handlers =>
            {
#if IOS
                // Workaround from Shane and EZ
                ContentViewHandler.Mapper.AppendToMapping(nameof(IContentView.Content), (handler, view) =>
                {
                      if (view is ContentView cv && cv.Content != null)
                      {
                            cv.FlowDirection = FlowDirection.LeftToRight;

                            switch (Microsoft.Maui.ApplicationModel.AppInfo.RequestedLayoutDirection)
                            {
                                  case LayoutDirection.LeftToRight:
                                        cv.Content.FlowDirection = FlowDirection.LeftToRight;
                                        break;
                                  case LayoutDirection.RightToLeft:
                                        cv.Content.FlowDirection = FlowDirection.RightToLeft;
                                        break;
                            }
                      }
                });
#endif
            });


#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}
