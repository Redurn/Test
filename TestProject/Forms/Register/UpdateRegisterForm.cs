using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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
    public partial class UpdateRegisterForm : Form
    {
        public UpdateRegisterForm()
        {
            InitializeComponent();
        }

        private async void UpdateRegisterForm_Load(object sender, EventArgs e)
        {
            var dbCOntexr = new AppDbContext();
            var registersRepository = new RegistersRepository(dbCOntexr);
            var registers = await registersRepository.Get();

            comboBox1.DataSource = registers;
            comboBox1.DisplayMember = "Name";

            var selectedRegiser = (RegisterEntity)comboBox1.SelectedItem;
            nameTextBox.Text = selectedRegiser.Name;
            descriptionTextBox.Text = selectedRegiser.Description;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var dbContext = new AppDbContext();
            var registersRepository = new RegistersRepository(dbContext);
            var selectredRegister = (RegisterEntity)comboBox1.SelectedItem;
            string name = nameTextBox.Text;
            string description = descriptionTextBox.Text;
            await registersRepository.Update(selectredRegister, name, description);

            var registers = await registersRepository.Get();
            comboBox1.DataSource = registers;
            comboBox1.DisplayMember = "Name";
        }
    }
}
