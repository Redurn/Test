
using TestProject.Models;
using TestProject.Repositories;

namespace TestProject.Forms;

public partial class UpdateInterfaceForm : Form
{
    public UpdateInterfaceForm()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var dbContext = new AppDbContext();
        var interfacesRepository = new InterfacesRepository(dbContext);
        var selectedInterfae = (InterfaceEntity)comboBox1.SelectedItem;
        await interfacesRepository.Update(selectedInterfae, textBox1.Text, textBox2.Text);

        var interfaces = await interfacesRepository.Get();

        comboBox1.DataSource = interfaces;
        comboBox1.DisplayMember = "Name";
    }

    private async void UpdateInterfaceForm_Load(object sender, EventArgs e)
    {
        var dbContext = new AppDbContext();
        var interfacesRepository = new InterfacesRepository(dbContext);

        var interfaces = await interfacesRepository.Get();

        comboBox1.DataSource = interfaces;
        comboBox1.DisplayMember = "Name";
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selected = (InterfaceEntity)comboBox1.SelectedItem;
        textBox1.Text = selected.Name;
        textBox2.Text = selected.Description;
    }
}
