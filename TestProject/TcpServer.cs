using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Net.Sockets;
using System.Text;

namespace TestProject;
public class TcpServer
{
    private readonly TcpListener _listener;

    public TcpServer(int port)
    {
        _listener = new TcpListener(IPAddress.Any, port);
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
        try
        {
            using NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[4096];

            int bytesRead = await stream.ReadAsync(buffer);

            if (bytesRead == 0)
                return;

            string request = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Получен запрос: {request}");

            string response = await ProcessRequestAsync(request);

            byte[] responseBytes =
                System.Text.Encoding.UTF8.GetBytes(response);

            await stream.WriteAsync(responseBytes);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            client.Close();
        }
    }

    private async Task<string> ProcessRequestAsync(string request)
    {
        // Тут будет работа с EF Core

        await Task.Delay(1);

        return "OK";
    }
}

