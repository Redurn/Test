using Core.Tcp;
using Microsoft.EntityFrameworkCore;
using TcpServerApp.Dto;
using TestProject.Dto;
using TestProject.Forms;
using TestProject.Forms.Device;
using TestProject.Forms.Register;
using TestProject.Models;
using TestProject.Repositories;
using TestProject.Services;
using TestProject.Tcp;

namespace TestProject
{
    public partial class Form1 : Form
    {
        private readonly TcpClientService _tcpClientService;

        private List<GetDeviceDto> _enabledDevices = [];

        private bool _generatorStart = false;

        public Form1()
        {
            InitializeComponent();

            _tcpClientService = new TcpClientService();
        }

        public async void RefreshForm()
        {
            var interfaces = await _tcpClientService.GetInterfacesAsync();

            Console.WriteLine(interfaces.Count);
            comboBox1.DataSource = interfaces;
            comboBox1.DisplayMember = "Name";

            await LoadEnabledDevices();
            panel1.Invalidate();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            var interfaces = await _tcpClientService.GetInterfacesAsync();

            comboBox1.DataSource = interfaces;
            comboBox1.DisplayMember = "Name";

            await LoadEnabledDevices();
            panel1.Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = new CreateInterfaceForm(_tcpClientService);
            await form.ShowDialogAsync();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var form = new UpdateInterfaceForm(_tcpClientService);
            await form.ShowDialogAsync();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedInterface = (GetInterfaceDto)comboBox1.SelectedItem;

            textBox1.Text = selectedInterface.Description;
            textBox2.Text = selectedInterface.EditingDate.ToString();

            var devices = await _tcpClientService.GetByInterfaceIdAsync(selectedInterface.Id);

            if (devices.Count != 0)
            {
                comboBox2.Visible = true;
                comboBox2.DataSource = devices;
                comboBox2.DisplayMember = "Name";
                descriptionDeviceTextBox.Visible = true;
                typeDeviceTextBox.Visible = true;
                colorDeviceTextBox.Visible = true;
                sizeDeviceTextBox.Visible = true;
                editingDateDeviceTextBox.Visible = true;
                posXDeviceTextBox.Visible = true;
                posYDeviceTextBox.Visible = true;
                statusDeviceTextBox.Visible = true;
                changeStatusButton.Visible = true;
            }
            else
            {
                comboBox2.Visible = false;
                descriptionDeviceTextBox.Visible = false;
                typeDeviceTextBox.Visible = false;
                colorDeviceTextBox.Visible = false;
                sizeDeviceTextBox.Visible = false;
                editingDateDeviceTextBox.Visible = false;
                posXDeviceTextBox.Visible = false;
                posYDeviceTextBox.Visible = false;
                comboBox3.Visible = false;
                descriptionRegisterTextBox.Visible = false;
                editingDateRegisterTextBox.Visible = false;
                statusDeviceTextBox.Visible = false;
                changeStatusButton.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var form = new CreateDeviceForm(_tcpClientService);
            await form.ShowDialogAsync();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var form = new UpdateDeviceForm(_tcpClientService);
            await form.ShowDialogAsync();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDevice = (GetDeviceDto)comboBox2.SelectedItem;

            descriptionDeviceTextBox.Text = selectedDevice.Description;
            typeDeviceTextBox.Text = selectedDevice.FigureType;
            colorDeviceTextBox.Text = selectedDevice.Color;
            sizeDeviceTextBox.Text = Convert.ToString(selectedDevice.Size);
            posXDeviceTextBox.Text = Convert.ToString(selectedDevice.PosX);
            posYDeviceTextBox.Text = Convert.ToString(selectedDevice.PosY);
            editingDateDeviceTextBox.Text = Convert.ToString(selectedDevice.EditingDate);
            if (selectedDevice.IsEnabled)
            {
                statusDeviceTextBox.Text = "Активно";
            }
            else { statusDeviceTextBox.Text = "Неактивно"; }

            var registers = await _tcpClientService.GetByDeviceIdAsync(selectedDevice.Id);

            if (registers.Count > 0)
            {
                comboBox3.Visible = true;
                descriptionRegisterTextBox.Visible = true;
                editingDateRegisterTextBox.Visible = true;
                comboBox3.DataSource = registers;
                comboBox3.DisplayMember = "Name";
            }
            else
            {
                comboBox3.Visible = false;
                descriptionRegisterTextBox.Visible = false;
                editingDateRegisterTextBox.Visible = false;
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var form = new CreateRegisterForm(_tcpClientService);
            await form.ShowDialogAsync();
        }

        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRegister = (GetRegistersDto)comboBox3.SelectedItem;
            descriptionRegisterTextBox.Text = selectedRegister.Description;
            editingDateRegisterTextBox.Text = Convert.ToString(selectedRegister.EditingDate);
        }

        private async void button6_Click_1(object sender, EventArgs e)
        {
            var form = new UpdateRegisterForm(_tcpClientService);
            await form.ShowDialogAsync();
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            var device = (GetDeviceDto)comboBox2.SelectedItem;

            var dto = new ChangeDeviceStatusDto
            {
                Id = device.Id,
                IsEnabled = device.IsEnabled
            };
            await _tcpClientService.ChangeDeviceStatus(dto);

            var selectedInterface = (GetInterfaceDto)comboBox1.SelectedItem;

            var devices = await _tcpClientService.GetByInterfaceIdAsync(selectedInterface.Id);

            comboBox2.DataSource = devices;
            comboBox2.DisplayMember = "Name";

            await LoadEnabledDevices();
            panel1.Invalidate();
        }

        private async Task LoadEnabledDevices()
        {
            _enabledDevices = await _tcpClientService.GetAllEnabledDevicesAsync();
        }

        private PointF[] SetPoints(string figureType, int posX, int posY, int size)
        {
            if (figureType == "Треугольник")
            {
                double h = Math.Sqrt(3) * size / 2.0;
                PointF pont1 = new((float)posX, (float)(posY - 2.0 * h / 3));
                PointF point2 = new((float)(posX - size / 2.0), (float)(posY + h / 3));
                PointF point3 = new((float)(posX + size / 2.0), (float)(posY + h / 3));
                PointF[] points = { pont1, point2, point3 };

                return points;
            }
            else
            {
                PointF point1 = new((float)(posX - size / 2), (float)(posY - size / 2));
                PointF point2 = new((float)(posX + size / 2), (float)(posY - size / 2));
                PointF point3 = new((float)(posX + size / 2), (float)(posY + size / 2));
                PointF point4 = new((float)(posX - size / 2), (float)(posY + size / 2));
                PointF[] points = { point1, point2, point3, point4 };
                return points;
            }
            ;
        }

        private void DrawDevice(Graphics g, string figureType, int posX, int posY, int size, string color)
        {
            if (figureType == "Квадрат" || figureType == "Треугольник")
            {
                var points = SetPoints(figureType, posX, posY, size);
                if (color == "Красный")
                {
                    g.DrawPolygon(Pens.Red, points);
                }
                else if (color == "Зелёный")
                {
                    g.DrawPolygon(Pens.Green, points);
                }
                else if (color == "Синий")
                {
                    g.DrawPolygon(Pens.Blue, points);
                }
            }
            else
            {
                if (color == "Синий")
                {
                    g.DrawEllipse(Pens.Blue, posX - size, posY - size, size * 2, size * 2);
                }
                else if (color == "Красный")
                {
                    g.DrawEllipse(Pens.Red, posX - size, posY - size, size * 2, size * 2);
                }
                else
                {
                    g.DrawEllipse(Pens.Green, posX - size, posY - size, size * 2, size * 2);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var device in _enabledDevices)
            {
                DrawDevice(e.Graphics, device.FigureType, device.PosX, device.PosY, device.Size, device.Color);
                g.DrawString(device.Name, new Font("Arial", 8), Brushes.Black, device.PosX - device.Size / 2, device.PosY);
            }
        }

        private async void button7_Click_1(object sender, EventArgs e)
        {
            var registersOfENabledDevices = await _tcpClientService.GetRegistersOfEnabledDevicesAsync();
            Random rnd = new Random();
            _generatorStart = true;
            List<CreateRegisterValueDto> registerValues = new List<CreateRegisterValueDto>();
            button8.Enabled = true;
            button7.Enabled = false;
            try
            {
                while (_generatorStart)
                {
                    foreach (var register in registersOfENabledDevices)
                    {
                        registerValues.Add(new CreateRegisterValueDto
                        {
                            RegisterId = register.Id,
                            Value = rnd.Next(-30, 30),
                            Timestamp = DateTime.Now,
                        });
                    }

                    if (registerValues.Count > 200)
                    {
                        await _tcpClientService.CreateRegisterValuesAsync(registerValues);

                        registerValues.Clear();
                    }

                    await Task.Delay(2000);
                }
            }
            finally
            {
                await _tcpClientService.CreateRegisterValuesAsync(registerValues);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _generatorStart = false;
            button7.Enabled = true;
            button8.Enabled = false;
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            var selectedInterface = (GetInterfaceDto)comboBox1.SelectedItem;
            var interfaceId = selectedInterface.Id;

            await _tcpClientService.DeleteInterfaceAsync(interfaceId);

            RefreshForm();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private async void button10_Click(object sender, EventArgs e)
        {
            var selectedDevice = (GetDeviceDto)comboBox2.SelectedItem;
            var deviceId = selectedDevice.Id;

            await _tcpClientService.DeleteDeviceAsync(deviceId);

            RefreshForm();
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            var selectedRegister = (GetRegistersDto)comboBox3.SelectedItem;
            var registerId = selectedRegister.Id;

            await _tcpClientService.DeleteRegisterAsync(registerId);

            RefreshForm();
        }
    }
}
