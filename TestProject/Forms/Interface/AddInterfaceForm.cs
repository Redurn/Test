using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestProject.Repositories;

namespace TestProject;

public partial class AddInterfaceForm : Form
{
    public AddInterfaceForm()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var dbContext = new AppDbContext();
        var interfacesRepository = new InterfacesRepository(dbContext);
        await interfacesRepository.Add(textBox1.Text, textBox2.Text);
    }
}
