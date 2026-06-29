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
using TestProject.Tcp;

namespace TestProject.Forms.Device
{
    public partial class UpdateDeviceForm : Form
    {
        private readonly TcpClientService _tcpCLientService;
        public UpdateDeviceForm(TcpClientService tcpClientService)
        {
            _tcpCLientService = tcpClientService;

            InitializeComponent();
        }

        private async void UpdateDeviceForm_Load(object sender, EventArgs e)
        {
            var devices = await _tcpCLientService.GetAllDevicesAsync();

            comboBox1.DataSource = devices;
            comboBox1.DisplayMember = "Name";

            string[] figures = new string[3] { "Круг", "Квадрат", "Треугольник" };
            string[] colors = new string[3] { "Красный", "Синий", "Зелёный" };

            typeComboBox.DataSource = figures;
            colorComboBox.DataSource = colors;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDevice = (GetDeviceDto)comboBox1.SelectedItem;
            nameTextBox.Text = selectedDevice.Name;
            descriptionTextBox.Text = selectedDevice.Description;
            sizeTextBox.Text = selectedDevice.Size.ToString();
            posXTextBox.Text = selectedDevice.PosX.ToString();
            posYTextBox.Text = selectedDevice.PosY.ToString();
            typeComboBox.Text = selectedDevice.FigureType;
            colorComboBox.Text = selectedDevice.Color;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var selectedDevice = (GetDeviceDto)comboBox1.SelectedItem;
            try
            {
                string name = nameTextBox.Text;
                string description = descriptionTextBox.Text;
                string figureType = typeComboBox.Text;
                string color = colorComboBox.Text;
                int size = Convert.ToInt32(sizeTextBox.Text);
                if (size <= 0)
                {
                    throw new Exception();
                }
                int posX = Convert.ToInt32(posXTextBox.Text);
                int posY = Convert.ToInt32(posYTextBox.Text);
                var dto = new UpdateDeviceDto
                {
                    Id = selectedDevice.Id,
                    Name = name,
                    Description = description,
                    FigureType = figureType,
                    Color = color,
                    Size = size,
                    PosX = posX,
                    PosY = posY
                };
                await _tcpCLientService.UpdateDeviceAsync(dto);

                var devices = await _tcpCLientService.GetAllDevicesAsync();
                comboBox1.DataSource = devices;
                comboBox1.DisplayMember = "Name";
            }
            catch (Exception)
            {
                MessageBox.Show("Заданы неверные параметры");
            }
        }
    }
}
