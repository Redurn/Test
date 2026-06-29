using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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

namespace TestProject.Forms.Register
{
    public partial class UpdateRegisterForm : Form
    {
        private readonly TcpClientService _tcpClientService;
        public UpdateRegisterForm(TcpClientService tcpClientService)
        {
            _tcpClientService = tcpClientService;

            InitializeComponent();
        }

        private async void UpdateRegisterForm_Load(object sender, EventArgs e)
        {
            var registers = await _tcpClientService.GetAllRegistersAsync();

            comboBox1.DataSource = registers;
            comboBox1.DisplayMember = "Name";
            //var dbCOntexr = new AppDbContext();
            //var registersRepository = new RegistersRepository(dbCOntexr);
            //var registers = await registersRepository.Get();

            //comboBox1.DataSource = registers;
            //comboBox1.DisplayMember = "Name";

            //var selectedRegiser = (RegisterEntity)comboBox1.SelectedItem;
            //nameTextBox.Text = selectedRegiser.Name;
            //descriptionTextBox.Text = selectedRegiser.Description;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var register = (GetRegistersDto)comboBox1.SelectedItem;
            var dto = new UpdateRegisterDto
            {
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
                Id = register.Id
            };
            await _tcpClientService.UpdateRegisterAsync(dto);

            var registers = await _tcpClientService.GetAllRegistersAsync();
;            comboBox1.DataSource = registers;
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var register = (GetRegistersDto)comboBox1.SelectedItem;
            nameTextBox.Text = register.Name;
            descriptionTextBox.Text = register.Description;
        }
    }
}
