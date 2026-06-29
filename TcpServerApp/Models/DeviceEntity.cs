using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Dto;

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

    public void Update(string name, string description, string figureType, int size,
                             int posX, int posY, string color)
    {
        Name = name;
        Description = description;
        FigureType = figureType;
        Size = size;
        PosX = posX;
        PosY = posY;
        Color = color;
        EditingDate = DateTime.Now;
    }

    public void ChangeStatus(bool isEnabled)
    {
        IsEnabled = !isEnabled;
    }
}

public interface IDevicesRepository
{
    Task<List<DeviceEntity>> GetByInterfaceId(Guid interfaceId);

    Task Create(DeviceEntity deviceEntity);

    Task Update(DeviceEntity deviceEntity);

    Task<List<DeviceEntity>> GetAll();

    Task<List<DeviceEntity>> GetAllEnabled();

    Task<DeviceEntity> GetById(Guid id);

    Task Delete(Guid id);
}

public interface IDeviceService
{
    Task<List<GetDeviceDto>> GetByInterfaceIdAsync(Guid interfaceId);

    Task CreateDeviceAsync(CreateDeviceDto dto);

    Task UpdateDeviceAsync(UpdateDeviceDto dto);

    Task ChangeDeviceStatusAsync(ChangeDeviceStatusDto dto);

    Task<List<GetDeviceDto>> GetAllDevicesAsync();

    Task<List<GetDeviceDto>> GetAllEnabledDevicesAsync();

    Task DeleteDeviceAsync(Guid id);
}