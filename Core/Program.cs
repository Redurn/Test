
using Core.Tcp;
using Microsoft.Extensions.DependencyInjection;
using TestProject;
using TestProject.Models;
using TestProject.Repositories;
using TestProject.Services;

static async Task Main()
{
    var services = new ServiceCollection();

    services.AddScoped<IInterfaceService, InterfaceService>();
    services.AddScoped<IDeviceService, DeviceService>();
    services.AddScoped<TcpServer>();

    var serviceProvider = services.BuildServiceProvider();

    var tcpServer = serviceProvider.GetRequiredService<TcpServer>();

    await tcpServer.StartAsync();
}