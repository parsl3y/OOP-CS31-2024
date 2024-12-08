using ArchivatorApp.Services.Commands;
using ArchivatorApp.Services.ConsoleWrap;
using ArchivatorApp.Services.Interfaces;
using ArchivatorApp.Services.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace ArchivatorApp.Services;

public static class Container
{
    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<LowCompressionStrategy>()
            .AddSingleton<MediumCompressionStrategy>()
            .AddSingleton<HighCompressionStrategy>()
            .AddSingleton<ZipCommand>() 
            .AddSingleton<UnZipCommand>()
            .AddTransient<ExitCommand>()
            .AddSingleton<IConsoleWrapper, ConsoleWrapper>();
    }

}