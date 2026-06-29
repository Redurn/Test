using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestProject.Dto;
using TestProject.Repositories;
using TestProject.Services;
using TestProject.Tcp;

namespace TestProject;

public partial class CreateInterfaceForm : Form
{
    private readonly TcpClientService _tcpClientService;

    public CreateInterfaceForm(TcpClientService tcpClientService)
    {
        InitializeComponent();

        _tcpClientService = tcpClientService;
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var dto = new CreateInterfaceDto
        {
            Name = textBox1.Text,
            Description = textBox2.Text,
        };

        await _tcpClientService.CreateInterfaceAsync(dto);
    }
}
