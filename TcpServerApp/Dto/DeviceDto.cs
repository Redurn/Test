using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Models;

namespace TestProject.Dto;

public class GetDeviceDto
{
    public Guid Id { get; set; }
    public Guid InterfaceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime EditingDate { get; set; }
    public string FigureType { get; set; }
    public int Size { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public string Color { get; set; }
}

public class CreateDeviceDto
{
    public Guid InterfaceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FigureType { get; set; }
    public int Size { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public string Color { get; set; }
}

public class UpdateDeviceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FigureType { get; set; }
    public int Size { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public string Color { get; set; }
}

public class ChangeDeviceStatusDto
{
    public Guid Id { get; set; }
    public bool IsEnabled { get; set; }
}