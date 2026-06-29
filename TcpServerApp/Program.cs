using Core.Tcp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TcpServerApp;
using TcpServerApp.Repositories;
using TcpServerApp.Services;
using TestProject.Models;
using TestProject.Repositories;
using TestProject.Services;

var services = new ServiceCollection();

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestProject.db");

services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={path}"));

services.AddScoped<IInterfacesRepository, InterfacesRepository>();
services.AddScoped<IDevicesRepository, DevicesRepository>();
services.AddScoped<IRegistersRepository, RegistersRepository>();
services.AddScoped<IRegisterValuesRepository, RegisterValuesRepository>();

services.AddScoped<IInterfaceService, InterfaceService>();
services.AddScoped<IDeviceService, DeviceService>();
services.AddScoped<IRegisterService,  RegisterService>();
services.AddScoped<IRegisterValueService, RegisterValueService>();

services.AddScoped<TcpServer>();

var serviceProvider = services.BuildServiceProvider();

using(var scope = serviceProvider.CreateScope())
{
    var server = scope.ServiceProvider.GetRequiredService<TcpServer>();
    await server.StartAsync();
}

//var dbCOntext = new AppDbContext();

//var interfacesRepository = new InterfacesRepository(dbCOntext);

//var interfaceService = new InterfaceService(interfacesRepository);

//var deviceRepository = new DevicesRepository(dbCOntext);

//var deviceService = new DeviceService(deviceRepository);

//var registersRepository = new RegistersRepository(dbCOntext);

//var registerService = new RegisterService(registersRepository);

//var _server = new TcpServer(interfaceService, deviceService, registerService);

//await _server.StartAsync();
