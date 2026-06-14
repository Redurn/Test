using TestProject.Dto;
using TestProject.Models;
using TestProject.Repositories;

namespace TestProject.Forms;

public partial class UpdateInterfaceForm : Form
{

    private readonly TcpClientService _tcpClientService;

    public UpdateInterfaceForm(TcpClientService tcpClientService)
    {
        _tcpClientService = tcpClientService;

        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var selectedInterface = (GetInterfaceDto)comboBox1.SelectedItem;
        var dto = new UpdateInterfaceDto
        {
            Id = selectedInterface.Id,
            Name = textBox1.Text,
            Description = textBox2.Text,
        };
        await _tcpClientService.UpdateInterfaceAsync(dto);

        var interfaces = await _tcpClientService.GetInterfacesAsync();

        comboBox1.DataSource = interfaces;
        comboBox1.DisplayMember = "Name";
    }

    private async void UpdateInterfaceForm_Load(object sender, EventArgs e)
    {
        var interfaces = await _tcpClientService.GetInterfacesAsync();

        comboBox1.DataSource = interfaces;
        comboBox1.DisplayMember = "Name";
    }

    private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedInterface = (GetInterfaceDto)comboBox1.SelectedItem;

        textBox1.Text = selectedInterface.Name;
        textBox2.Text = selectedInterface.Description;
    }
}
