using Microsoft.EntityFrameworkCore;
using TestProject.Forms;
using TestProject.Forms.Device;
using TestProject.Forms.Register;
using TestProject.Models;
using TestProject.Repositories;

namespace TestProject
{
    public partial class Form1 : Form
    {
        private TcpServer? _server;
        public Form1()
        {
            InitializeComponent();

            StartServer();
        }

        public async void RefreshForm()
        {
            var dbContext = new AppDbContext();
            var interfacesRepository = new InterfacesRepository(dbContext);

            var interfaces = await interfacesRepository.Get();

            comboBox1.DataSource = interfaces;
            comboBox1.DisplayMember = "Name";
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            var dbContext = new AppDbContext();
            var interfacesRepository = new InterfacesRepository(dbContext);
            var devicesRepository = new DevicesRepository(dbContext);
            var registersRepository = new RegistersRepository(dbContext);

            var interfaces = await interfacesRepository.Get();

            comboBox1.DataSource = interfaces;
            comboBox1.DisplayMember = "Name";

            // Проверка на наличии Устройств у интерфейса
            var selectedInterface = (InterfaceEntity)comboBox1.SelectedItem;
            Guid interfaceId = selectedInterface.Id;
            var interfaceWithDevices = dbContext.Interfaces.Include(x => x.Devices)
                .FirstOrDefault(x => x.Id == interfaceId);
            if (interfaceWithDevices.Devices.Any())
            {
                var devices = await devicesRepository.GetByInterface(interfaceId);
                comboBox2.DataSource = devices;
                comboBox2.DisplayMember = "Name";

                //Проверка на наличии регистров у устройства
                var selectedDevice = (DeviceEntity)comboBox2.SelectedItem;
                Guid deviceId = selectedDevice.Id;
                var deviceWithRegisters = dbContext.Devices.Include(d => d.Registers)
                    .FirstOrDefault(d => d.Id == deviceId);

                if (deviceWithRegisters.Registers.Any())
                {
                    var registers = await registersRepository.GetByDevice(deviceId);
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
            }


        }

        private void StartServer()
        {
            _server = new TcpServer(5000);

            _ = _server.StartAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = new AddInterfaceForm();
            await form.ShowDialogAsync();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var form = new UpdateInterfaceForm();
            await form.ShowDialogAsync();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dbContext = new AppDbContext();
            var devicesRepository = new DevicesRepository(dbContext);

            var selectedInterface = (InterfaceEntity)comboBox1.SelectedItem;
            textBox1.Text = selectedInterface.Description;
            textBox2.Text = Convert.ToString(selectedInterface.EditingDate);

            // Проверяет наличие устройств у интерфейса и скрывает поля, если их нет
            Guid interfaceId = selectedInterface.Id;
            var devices = await devicesRepository.GetByInterface(interfaceId);
            var interfaceEntity = dbContext.Interfaces.Include(x => x.Devices)
                .FirstOrDefault(x => x.Id == interfaceId);

            if (interfaceEntity.Devices.Any())
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
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var form = new AddDeviceForm();
            await form.ShowDialogAsync();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var form = new UpdateDeviceForm();
            await form.ShowDialogAsync();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dbContext = new AppDbContext();
            var registersRepository = new RegistersRepository(dbContext);
            var selectedDevice = (DeviceEntity)comboBox2.SelectedItem;
            descriptionDeviceTextBox.Text = selectedDevice.Description;
            typeDeviceTextBox.Text = selectedDevice.FigureType;
            colorDeviceTextBox.Text = selectedDevice.Color;
            sizeDeviceTextBox.Text = Convert.ToString(selectedDevice.Size);
            posXDeviceTextBox.Text = Convert.ToString(selectedDevice.PosX);
            posYDeviceTextBox.Text = Convert.ToString(selectedDevice.PosY);
            editingDateDeviceTextBox.Text = Convert.ToString(selectedDevice.EditingDate);

            // Проверяет на наличии регистров у устройства
            Guid deviceId = selectedDevice.Id;
            var registers = await registersRepository.GetByDevice(deviceId);
            var deviceEntity = dbContext.Devices.Include(d => d.Registers)
                .FirstOrDefault(d => d.Id == selectedDevice.Id);
            if (deviceEntity.Registers.Any())
            {
                comboBox3.Visible = true;
                comboBox3.DataSource = registers;
                comboBox3.DisplayMember = "Name";
                descriptionRegisterTextBox.Visible = true;
                editingDateRegisterTextBox.Visible = true;
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
            var form = new AddRegisterForm();
            await form.ShowDialogAsync();
        }

        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRegister = (RegisterEntity)comboBox3.SelectedItem;
            descriptionRegisterTextBox.Text = selectedRegister.Description;
            editingDateRegisterTextBox.Text = Convert.ToString(selectedRegister.EditingDate);
        }

        private async void button6_Click_1(object sender, EventArgs e)
        {
            var form = new UpdateRegisterForm();
            await form.ShowDialogAsync();
        }
    }
}
