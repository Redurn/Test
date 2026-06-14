using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using TestProject.Dto;
using TestProject.Models;
using TestProject.Tcp;

namespace Core.Tcp;
public class TcpServer
{
    private readonly TcpListener _listener;
    private readonly IInterfaceService _interfaceService;
    private readonly IDeviceService _deviceService;

    public TcpServer(IInterfaceService interfaceService, IDeviceService deviceService)
    {
        _interfaceService = interfaceService;

        _deviceService = deviceService;

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
        var stream = client.GetStream();

        var buffer = new byte[1024];

        int bytesRead = await stream.ReadAsync(buffer);

        var json = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var request = JsonSerializer.Deserialize<TcpRequest>(json);

        if (request == null)
            return;

        // Интерфейсы

        if (request.Command == "CREATE_INTERFACE")
        {
            var dto = JsonSerializer.Deserialize<CreateInterfaceDto>(request.Data);

            await _interfaceService.CreateInterfaceAsync(dto);
        }

        else if (request.Command == "UPDATE_INTERFACE")
        {
            var dto = JsonSerializer.Deserialize<UpdateInterfaceDto>(request.Data);

            await _interfaceService.UpdateInterfaceAsync(dto);
        }

        else if (request.Command == "GET_INTERFACES")
        {
            var interfaces = await _interfaceService.GetAllInterfacesAsync();

            var repsonseJson = JsonSerializer.Serialize(interfaces);

            var responseBytes = Encoding.UTF8.GetBytes(repsonseJson);

            await stream.WriteAsync(responseBytes);
        }

        else if (request.Command == "GET_INTERFACE_BY_ID")
        {
            var id = JsonSerializer.Deserialize<Guid>(request.Data);

            var interfaceById = await _interfaceService.GetInterfaceByIdAsync(id);

            var repsonseJson = JsonSerializer.Serialize(interfaceById);

            var responseBytes = Encoding.UTF8.GetBytes(repsonseJson);

            await stream.WriteAsync(responseBytes);
        }

        // Устройства

        else if (request.Command == "GET_BY_INTERFACE_ID")
        {
            var interfaceId = JsonSerializer.Deserialize<Guid>(request.Data);

            var devicesByInterfaceId = await _deviceService.GetByInterfaceIdAsync(interfaceId);

            var repsonseJson = JsonSerializer.Serialize(devicesByInterfaceId);

            var responseBytes = Encoding.UTF8.GetBytes(repsonseJson);

            await stream.WriteAsync(responseBytes);
        }

        else if (request.Command == "CREATE_DEVICE")
        {
            var dto = JsonSerializer.Deserialize<CreateDeviceDto>(request.Data);

            await _deviceService.CreateDeviceAsync(dto);
        }

        else if (request.Command == "UPDATE_DEVICE")
        {
            var dto = JsonSerializer.Deserialize<UpdateDeviceDto>(request.Data);

            await _deviceService.UpdateDeviceAsync(dto);
        }
        else if (request.Command == "GET_DEVICES")
        {
            var devices = await _deviceService.GetAllDevicesAsync();

            var repsonseJson = JsonSerializer.Serialize(devices);

            var responseBytes = Encoding.UTF8.GetBytes(repsonseJson);

            await stream.WriteAsync(responseBytes);
        }
    }
}

