using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestProject.Models;
using TestProject.Repositories;

namespace TestProject.Forms
{
    public partial class AddDeviceForm : Form
    {
        public AddDeviceForm()
        {
            InitializeComponent();
        }

        private async void AddDeviceForm_Load(object sender, EventArgs e)
        {
            var dbContext = new AppDbContext();
            var interfacesRepository = new InterfacesRepository(dbContext);

            var interfaces = await interfacesRepository.Get();

            comboBox1.DataSource = interfaces;
            comboBox1.DisplayMember = "Name";
            string[] figures = new string[3] { "Круг", "Квадрат", "Треугольник" };
            string[] colors = new string[3] { "Красный", "Синий", "Зелёный" };
            typeComboBox.DataSource = figures;
            colorComboBox.DataSource = colors;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var dbCOntext = new AppDbContext();
            var interfaceEntity = (InterfaceEntity)comboBox1.SelectedItem;
            var interfaceId = interfaceEntity.Id;
            var devicesRepository = new DevicesRepository(dbCOntext);
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
                await devicesRepository.Add(interfaceId, name, description, figureType, size, posX, posY, color);
            }
            catch (Exception ex)
            {
                MessageBox.Show("заданы неверные параметры");
            }
        }
    }
}
