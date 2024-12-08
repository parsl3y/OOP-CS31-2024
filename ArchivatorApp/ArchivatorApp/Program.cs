using ArchivatorApp.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .RegisterServices()
    .BuildServiceProvider();
var invoker = new Invoker(serviceProvider);

invoker.Run();