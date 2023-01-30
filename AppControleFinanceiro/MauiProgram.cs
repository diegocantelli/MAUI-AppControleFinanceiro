﻿using ControleFinanceiro;
using ControleFinanceiro.Repositories;
using LiteDB;
using Microsoft.Extensions.Logging;
using ControleFinanceiro.Views;

namespace AppControleFinanceiro;

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
			.RegisterDataBaseAndRepositories()
			.RegisterViews();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterDataBaseAndRepositories(this MauiAppBuilder mauiAppBuilder)
	{
        mauiAppBuilder.Services.AddSingleton<LiteDatabase>(
             options => {
                 return new LiteDatabase($"Filename={AppSettings.DatabasePath};Connection=Shared");
             }
             );

        mauiAppBuilder.Services.AddTransient<ITransactionRepository, TransactionRepositories>();
        return mauiAppBuilder;

    }

	public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddTransient<TransactionAdd>();
		mauiAppBuilder.Services.AddTransient<TransactionEdit>();
		mauiAppBuilder.Services.AddTransient<TransactionList>();

		return mauiAppBuilder;
	}
}

