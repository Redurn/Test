using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestProject.Dto;
using TestProject.Models;
using TestProject.Repositories;

namespace TestProject.Forms.Register
{
    public partial class CreateRegisterForm : Form
    {
        private readonly TcpClientService _tcpClientService;
        public CreateRegisterForm(TcpClientService tcpClientService)
        {
            _tcpClientService = tcpClientService;

            InitializeComponent();
        }

        private async void AddRegisterForm_Load(object sender, EventArgs e)
        {
            var devices = await _tcpClientService.GetAllDevicesAsync();

            comboBox1.DataSource = devices;
            comboBox1.DisplayMember = "Name";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var selectedDevice = (GetDeviceDto)comboBox1.SelectedItem;
            var deviceId = selectedDevice.Id;
            var dto = new CreateRegisterDto
            {
                Name = nameRegistertextBox.Text,
                Description = descriptionRegisterTextBox.Text,
                DeviceId = deviceId,
            };
            await _tcpClientService.CreateRegisterAsync(dto);
        }
    }
}
