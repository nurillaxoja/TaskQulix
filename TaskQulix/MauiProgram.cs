using TaskQulix.Services;

namespace TaskQulix;

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
			});

		builder.Services.AddSingleton<CurrencyService>();
		//builder.Services.AddTransient<CurrencyService>();

		builder.Services.AddSingleton<CurrencyViewModel>();

		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
