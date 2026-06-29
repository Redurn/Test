using Azure.Core;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using TcpServerApp.Dto;
using TestProject.Dto;

namespace TestProject.Tcp;

public class TcpClientService
{
    // Интерфейсы

    public async Task CreateInterfaceAsync(CreateInterfaceDto dto)
    {
        var request = new TcpRequest
        {
            Command = "CREATE_INTERFACE",
            Data = JsonSerializer.Serialize(dto)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    public async Task<List<GetInterfaceDto>> GetInterfacesAsync()
    {
        var request = new TcpRequest
        {
            Command = "GET_INTERFACES"
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);

        await stream.FlushAsync();

        var buffer = new byte[4096];

        int bytesRead = await stream.ReadAsync(buffer);

        var responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var interfaces = JsonSerializer.Deserialize<List<GetInterfaceDto>>
            (responseJson);

        return interfaces;
    }

    public async Task<GetInterfaceDto> GetInterfaceByIdAsync(Guid id)
    {
        var request = new TcpRequest
        {
            Command = "GET_INTERFACE_BY_ID",
            Data = JsonSerializer.Serialize(id)
        };
        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);

        var buffer = new byte[4096];

        int bytesRead = await stream.ReadAsync(buffer);

        var responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var interfaceById = JsonSerializer.Deserialize<GetInterfaceDto>(responseJson);

        return interfaceById;
    }

    public async Task UpdateInterfaceAsync(UpdateInterfaceDto dto)
    {
        var request = new TcpRequest
        {
            Command = "UPDATE_INTERFACE",
            Data = JsonSerializer.Serialize(dto)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    public async Task DeleteInterfaceAsync(Guid id)
    {
        var request = new TcpRequest
        {
            Command = "DELETE_INTERFACE",
            Data = JsonSerializer.Serialize(id)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    // Устройства

    public async Task<List<GetDeviceDto>> GetByInterfaceIdAsync(Guid id)
    {
        var request = new TcpRequest
        {
            Command = "GET_BY_INTERFACE_ID",
            Data = JsonSerializer.Serialize(id)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);

        await stream.FlushAsync();

        var buffer = new byte[4096];

        int bytesRead = await stream.ReadAsync(buffer);

        var responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var devicesByInterfaceId = JsonSerializer.Deserialize<List<GetDeviceDto>>(responseJson);

        return devicesByInterfaceId;
    }

    public async Task CreateDeviceAsync(CreateDeviceDto dto)
    {
        var request = new TcpRequest
        {
            Command = "CREATE_DEVICE",
            Data = JsonSerializer.Serialize(dto)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    public async Task UpdateDeviceAsync(UpdateDeviceDto dto)
    {
        var request = new TcpRequest
        {
            Command = "UPDATE_DEVICE",
            Data = JsonSerializer.Serialize(dto)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    public async Task ChangeDeviceStatus(ChangeDeviceStatusDto dto)
    {
        var request = new TcpRequest
        {
            Command = "CHANGE_DEVICE_STATUS",
            Data = JsonSerializer.Serialize(dto)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    public async Task<List<GetDeviceDto>> GetAllDevicesAsync()
    {
        var request = new TcpRequest
        {
            Command = "GET_DEVICES"
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);

        var buffer = new byte[4096];

        int bytesRead = await stream.ReadAsync(buffer);

        var responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var devices = JsonSerializer.Deserialize<List<GetDeviceDto>>
            (responseJson);

        return devices;
    }

    public async Task<List<GetDeviceDto>> GetAllEnabledDevicesAsync()
    {
        var request = new TcpRequest
        {
            Command = "GET_ENABLED_DEVICES"
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);

        var buffer = new byte[4096];

        int bytesRead = await stream.ReadAsync(buffer);

        var responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var devices = JsonSerializer.Deserialize<List<GetDeviceDto>>
            (responseJson);

        return devices;
    }

    public async Task DeleteDeviceAsync(Guid id)
    {
        var request = new TcpRequest
        {
            Command = "DELETE_DEVICE",
            Data = JsonSerializer.Serialize(id)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    // Регистры

    public async Task<List<GetRegistersDto>> GetByDeviceIdAsync(Guid deviceId)
    {
        var request = new TcpRequest
        {
            Command = "GET_BY_DEVICE_ID",
            Data = JsonSerializer.Serialize(deviceId)
        };
        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);

        var buffer = new byte[4096];

        int bytesRead = await stream.ReadAsync(buffer);

        var responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var dregistersByDeviceId = JsonSerializer.Deserialize<List<GetRegistersDto>>(responseJson);

        return dregistersByDeviceId;
    }

    public async Task<List<GetRegistersDto>> GetAllRegistersAsync()
    {
        var request = new TcpRequest
        {
            Command = "GET_REGISTERS"
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);

        var buffer = new byte[4096];

        int bytesRead = await stream.ReadAsync(buffer);

        var responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var registers = JsonSerializer.Deserialize<List<GetRegistersDto>>(responseJson);

        return registers;
    }

    public async Task<List<GetRegisterIdDto>> GetRegistersOfEnabledDevicesAsync()
    {
        var request = new TcpRequest
        {
            Command = "GET_REGISTERS_OF_ENABLED_DEVICES"
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);

        var buffer = new byte[4096];

        int bytesRead = await stream.ReadAsync(buffer);

        var responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var registers = JsonSerializer.Deserialize<List<GetRegisterIdDto>>(responseJson);

        return registers;
    }

    public async Task CreateRegisterAsync(CreateRegisterDto dto)
    {
        var request = new TcpRequest
        {
            Command = "CREATE_REGISTER",
            Data = JsonSerializer.Serialize(dto)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    public async Task UpdateRegisterAsync(UpdateRegisterDto dto)
    {
        var request = new TcpRequest
        {
            Command = "UPDATE_REGISTER",
            Data = JsonSerializer.Serialize(dto)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    public async Task DeleteRegisterAsync(Guid id)
    {
        var request = new TcpRequest
        {
            Command = "DELETE_REGISTER",
            Data = JsonSerializer.Serialize(id)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }

    // Значения регистров

    public async Task CreateRegisterValuesAsync(List<CreateRegisterValueDto> registerValues)
    {
        var request = new TcpRequest
        {
            Command = "CREATE_REGISTER_VALUES",
            Data = JsonSerializer.Serialize(registerValues)
        };

        var json = JsonSerializer.Serialize(request);

        using TcpClient client = new TcpClient();

        await client.ConnectAsync("127.0.0.1", 5000);

        using NetworkStream stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(json);

        await stream.WriteAsync(bytes);
    }
}
