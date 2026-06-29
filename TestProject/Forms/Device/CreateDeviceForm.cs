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

namespace TestProject.Forms
{
    public partial class CreateDeviceForm : Form
    {
        private readonly TcpClientService _tcpClientService;
        public CreateDeviceForm(TcpClientService tcpCLientService)
        {
            _tcpClientService = tcpCLientService;

            InitializeComponent();
        }

        private async void AddDeviceForm_Load(object sender, EventArgs e)
        {
            var interfaces = await _tcpClientService.GetInterfacesAsync();

            comboBox1.DataSource = interfaces;
            comboBox1.DisplayMember = "Name";

            string[] figures = new string[3] { "Круг", "Квадрат", "Треугольник" };
            string[] colors = new string[3] { "Красный", "Синий", "Зелёный" };

            typeComboBox.DataSource = figures;
            colorComboBox.DataSource = colors;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var selectedInterface = (GetInterfaceDto)comboBox1.SelectedItem;
            var interfaceId = selectedInterface.Id;
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
                var dto = new CreateDeviceDto
                {
                    Name = name,
                    Description = description,
                    InterfaceId = interfaceId,
                    FigureType = figureType,
                    Size = size,
                    PosX = posX,
                    PosY = posY,
                    Color = color
                };
                await _tcpClientService.CreateDeviceAsync(dto);
            }
            catch (Exception)
            {
                MessageBox.Show("заданы неверные параметры");
            }
        }
    }
}
