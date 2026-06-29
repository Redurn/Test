using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using TcpServerApp.Dto;
using TestProject.Dto;
using TestProject.Models;
using TestProject.Tcp;

namespace Core.Tcp;
public class TcpServer
{
    private readonly TcpListener _listener;
    private readonly IServiceProvider _serviceProvider;

    public TcpServer(IServiceProvider serviceProvider)
    {
       _serviceProvider = serviceProvider;

        _listener = new TcpListener(IPAddress.Any, 5000);
    }

    public async Task StartAsync()
    {
        _listener.Start();

        Console.WriteLine("TCP сервер запущен");

        while (true)
        {
            TcpClient client = await _listener.AcceptTcpClientAsync();

            Console.WriteLine("Клиент подключен");

            _ = HandleClientAsync(client);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        using var scope = _serviceProvider.CreateScope();

        var interfaceService = scope.ServiceProvider.GetRequiredService<IInterfaceService>();
        var deviceService = scope.ServiceProvider.GetRequiredService<IDeviceService>();
        var registerService = scope.ServiceProvider.GetRequiredService<IRegisterService>();
        var registerValueService = scope.ServiceProvider.GetRequiredService<IRegisterValueService>();

        using (client)

        using (var stream = client.GetStream())
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    var buffer = new byte[4096];
                    int bytesRead;

                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    await memoryStream.WriteAsync(buffer, 0, bytesRead);

                    while (stream.DataAvailable)
                    {
                        bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                            await memoryStream.WriteAsync(buffer, 0, bytesRead);
                    }

                    var json = Encoding.UTF8.GetString(memoryStream.ToArray());
                    var request = JsonSerializer.Deserialize<TcpRequest>(json);

                    if (request == null)
                        return;

                    // Интерфейсы

                    if (request.Command == "CREATE_INTERFACE")
                    {
                        var dto = JsonSerializer.Deserialize<CreateInterfaceDto>(request.Data);

                        await interfaceService.CreateInterfaceAsync(dto);
                    }

                    else if (request.Command == "UPDATE_INTERFACE")
                    {
                        var dto = JsonSerializer.Deserialize<UpdateInterfaceDto>(request.Data);

                        await interfaceService.UpdateInterfaceAsync(dto);
                    }

                    else if (request.Command == "GET_INTERFACES")
                    {
                        var interfaces = await interfaceService.GetAllInterfacesAsync();

                        var responseJson = JsonSerializer.Serialize(interfaces);

                        var responseBytes = Encoding.UTF8.GetBytes(responseJson);

                        await stream.WriteAsync(responseBytes);
                    }

                    else if (request.Command == "GET_INTERFACE_BY_ID")
                    {
                        var id = JsonSerializer.Deserialize<Guid>(request.Data);

                        var interfaceById = await interfaceService.GetInterfaceByIdAsync(id);

                        var responseJson = JsonSerializer.Serialize(interfaceById);

                        var responseBytes = Encoding.UTF8.GetBytes(responseJson);

                        await stream.WriteAsync(responseBytes);
                    }

                    else if (request.Command == "DELETE_INTERFACE")
                    {
                        var id = JsonSerializer.Deserialize<Guid>(request.Data);

                        await interfaceService.DeleteInterfaceAsync(id);
                    }

                    // Устройства

                    else if (request.Command == "GET_BY_INTERFACE_ID")
                    {
                        var interfaceId = JsonSerializer.Deserialize<Guid>(request.Data);

                        var devicesByInterfaceId = await deviceService.GetByInterfaceIdAsync(interfaceId);

                        var repsonseJson = JsonSerializer.Serialize(devicesByInterfaceId);

                        var responseBytes = Encoding.UTF8.GetBytes(repsonseJson);

                        await stream.WriteAsync(responseBytes);

                        await stream.FlushAsync();
                    }

                    else if (request.Command == "CREATE_DEVICE")
                    {
                        var dto = JsonSerializer.Deserialize<CreateDeviceDto>(request.Data);

                        await deviceService.CreateDeviceAsync(dto);
                    }

                    else if (request.Command == "UPDATE_DEVICE")
                    {
                        var dto = JsonSerializer.Deserialize<UpdateDeviceDto>(request.Data);

                        await deviceService.UpdateDeviceAsync(dto);
                    }

                    else if (request.Command == "CHANGE_DEVICE_STATUS")
                    {
                        var dto = JsonSerializer.Deserialize<ChangeDeviceStatusDto>(request.Data);

                        await deviceService.ChangeDeviceStatusAsync(dto);
                    }

                    else if (request.Command == "GET_DEVICES")
                    {
                        var devices = await deviceService.GetAllDevicesAsync();

                        var responseJson = JsonSerializer.Serialize(devices);

                        var responseBytes = Encoding.UTF8.GetBytes(responseJson);

                        await stream.WriteAsync(responseBytes);
                    }

                    else if (request.Command == "GET_ENABLED_DEVICES")
                    {
                        var devices = await deviceService.GetAllEnabledDevicesAsync();

                        var responseJson = JsonSerializer.Serialize(devices);

                        var responseBytes = Encoding.UTF8.GetBytes(responseJson);

                        await stream.WriteAsync(responseBytes);
                    }

                    else if (request.Command == "DELETE_DEVICE")
                    {
                        var deviceId = JsonSerializer.Deserialize<Guid>(request.Data);

                        await deviceService.DeleteDeviceAsync(deviceId);
                    }

                    // Регистры

                    else if (request.Command == "GET_BY_DEVICE_ID")
                    {
                        var deviceId = JsonSerializer.Deserialize<Guid>(request.Data);

                        var registersByDeviceId = await registerService.GetByDeviceIdAsync(deviceId);

                        var responseJson = JsonSerializer.Serialize(registersByDeviceId);

                        var responseBytes = Encoding.UTF8.GetBytes(responseJson);

                        await stream.WriteAsync(responseBytes);
                    }

                    else if (request.Command == "GET_REGISTERS")
                    {
                        var registers = await registerService.GetAllRegistersAsync();

                        var responseJson = JsonSerializer.Serialize(registers);

                        var responseBytes = Encoding.UTF8.GetBytes(responseJson);

                        await stream.WriteAsync(responseBytes);
                    }

                    else if (request.Command == "GET_REGISTERS_OF_ENABLED_DEVICES")
                    {
                        var registers = await registerService.GetRegistersOfEnabledDevicesAsync();

                        var responseJson = JsonSerializer.Serialize(registers);

                        var responseBytes = Encoding.UTF8.GetBytes(responseJson);

                        await stream.WriteAsync(responseBytes);
                    }

                    else if (request.Command == "CREATE_REGISTER")
                    {
                        var dto = JsonSerializer.Deserialize<CreateRegisterDto>(request.Data);

                        await registerService.CreateRegisterAsync(dto);
                    }

                    else if (request.Command == "UPDATE_REGISTER")
                    {
                        var dto = JsonSerializer.Deserialize<UpdateRegisterDto>(request.Data);

                        await registerService.UpdateRegisterAsync(dto);
                    }

                    else if (request.Command == "DELETE_REGISTER")
                    {
                        var registerId = JsonSerializer.Deserialize<Guid>(request.Data);

                        await registerService.DeleteRegisterAsync(registerId);
                    }

                    // Значения регистров

                    else if (request.Command == "CREATE_REGISTER_VALUES")
                    {
                        var dto = JsonSerializer.Deserialize<List<CreateRegisterValueDto>>(request.Data);

                        await registerValueService.CreateRegisterValuesAsync(dto);
                    }
                }

                

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER ERROR] Ошибка обработки клиента: {ex.Message}");
                Console.WriteLine($"[SERVER ERROR] StackTrace: {ex.StackTrace}");
            }
        }
    }
}

