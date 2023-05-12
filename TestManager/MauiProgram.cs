using Microsoft.Extensions.Configuration;
using TestManagement.Application;
using TestManagement.Application.LiteDB;
using TestManagement.Domain.Model;
using TestManagement.Domain.Model.LiteDB;
using TestManagement.Port.Adapters;

namespace TestManager
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
				});

			builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
			{
				string connectionString;
				{
					string appDirPath = Path.Combine(FileSystem.Current.AppDataDirectory, "TestManager");
					if (!Directory.Exists(appDirPath)) Directory.CreateDirectory(appDirPath);

					connectionString = Path.Combine(appDirPath, "TestManagement.db");
				}

				Dictionary<string, string> collection = new()
				{
					{ "ConnectionStrings:TestManagement", connectionString }
				};

				builder.Configuration.AddInMemoryCollection(collection);
			}

			builder.Services.AddSingleton<ITestDocumentImportingService, TestDocumentImportingService>();
			builder.Services.AddSingleton<ITestDocumentLoader, TestDocumentLoader>();
			builder.Services.AddSingleton<ITestDocumentContextFactory, TestDocumentContextFactory>();

			builder.Services.AddSingleton<ITestDocumentQueryService, TestDocumentQueryService>();
			builder.Services.AddSingleton<ITestDocumentSummaryQueryService, TestDocumentSummaryQueryService>();

			return builder.Build();
		}
	}
}