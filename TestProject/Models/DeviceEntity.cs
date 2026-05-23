using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Models;
public class DeviceEntity
{
    public Guid Id { get; set; }
    public Guid InterfaceId { get; set; }
    public InterfaceEntity Interface { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime EditingDate { get; set; }
    public string FigureType { get; set; }
    public int Size { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public  string Color { get; set; }
    public List<RegisterEntity> Registers { get; set; }
}
