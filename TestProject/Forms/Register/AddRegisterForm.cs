using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestProject.Models;
using TestProject.Repositories;

namespace TestProject.Forms.Register
{
    public partial class AddRegisterForm : Form
    {
        public AddRegisterForm()
        {
            InitializeComponent();
        }

        private async void AddRegisterForm_Load(object sender, EventArgs e)
        {
            var dbContext = new AppDbContext();
            var devicesRepository = new DevicesRepository(dbContext);

            var devices = await devicesRepository.Get();

            comboBox1.DataSource = devices;
            comboBox1.DisplayMember = "Name";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var dbContext = new AppDbContext();
            var deviceEntity = (DeviceEntity)comboBox1.SelectedItem;
            var deviceId = deviceEntity.Id;

            var registersRepository = new RegistersRepository(dbContext);
            await registersRepository.Add(deviceId, nameRegistertextBox.Text, descriptionRegisterTextBox.Text);
        }
    }
}
