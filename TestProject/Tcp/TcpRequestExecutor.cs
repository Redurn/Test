using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace TestProject.Tcp;

internal class TcpRequestExecutor
{
    private readonly string _host;
    private readonly int _port;

    public TcpRequestExecutor(string host, int port)
    {
        _host = host;
        _port = port;
    }

    public async Task SendAsync(string Command, object data = null)
    {
        using var client = new TcpClient();
        await client.ConnectAsync(_host, _port);
        await using var stream = client.GetStream();

        var reqyest = new TcpRequest
        {
            Command = Command,
            Data = data != null ? JsonSerializer.Serialize(data) : null
        };

        var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(reqyest));
        await stream.FlushAsync();
    }

    public async Task<T> SendAndReceiveAsync<T>(string command, object data = null)
    {
        using var client = new TcpClient();
        await client.ConnectAsync(_host, _port);
        await using var stream = client.GetStream();

        var request = new TcpRequest
        {
            Command = command,
            Data = data != null ? JsonSerializer.Serialize(data) : null
        };

        var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

        await stream.WriteAsync(bytes);
        await stream.FlushAsync();

        using var memoryStream = new MemoryStream();
        var buffer = new Byte[4096];
        int bytesRead;

        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
        {
            memoryStream.Write(buffer, 0, bytesRead);
        }

        var responseJson = Encoding.UTF8.GetString(memoryStream.ToArray());
        return JsonSerializer.Deserialize<T>(responseJson);
    }
}


