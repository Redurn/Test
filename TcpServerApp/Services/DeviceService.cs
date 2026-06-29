using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Dto;
using TestProject.Models;

namespace TestProject.Services;

internal class DeviceService : IDeviceService
{
    private readonly IDevicesRepository _devicesRepository;

    public DeviceService(IDevicesRepository devicesRepository)
    {
        _devicesRepository = devicesRepository;
    }

    public async Task<List<GetDeviceDto>> GetByInterfaceIdAsync(Guid id)
    {
        var selectedDevices = await _devicesRepository.GetByInterfaceId(id);

        return selectedDevices.Select(x => new GetDeviceDto
        {
            Id = x.Id,
            InterfaceId = x.InterfaceId,
            Name = x.Name,
            Description = x.Description,
            IsEnabled = x.IsEnabled,
            FigureType = x.FigureType,
            EditingDate = x.EditingDate,
            Size = x.Size,
            PosX = x.PosX,
            PosY = x.PosY,
            Color = x.Color,
        }).ToList();
    }

    public async Task CreateDeviceAsync(CreateDeviceDto dto)
    {
        var deviceEntity = new DeviceEntity
        {
            InterfaceId = dto.InterfaceId,
            Name = dto.Name,
            Description = dto.Description,
            FigureType = dto.FigureType,
            Size = dto.Size,
            PosX = dto.PosX,
            PosY = dto.PosY,
            Color = dto.Color,
            IsEnabled = false,
            EditingDate = DateTime.Now
        };

        await _devicesRepository.Create(deviceEntity);
    }

    public async Task UpdateDeviceAsync(UpdateDeviceDto dto) 
    {
        var device = await _devicesRepository.GetById(dto.Id);

        device.Update(dto.Name, dto.Description, dto.FigureType, dto.Size, dto.PosX, dto.PosY, dto.Color);

        await _devicesRepository.Update(device);
    }

    public async Task ChangeDeviceStatusAsync(ChangeDeviceStatusDto dto)
    {
        var device = await _devicesRepository.GetById(dto.Id);

        device.ChangeStatus(dto.IsEnabled);

        await _devicesRepository.Update(device);
    }

    public async Task<List<GetDeviceDto>> GetAllDevicesAsync()
    {
        var devices = await _devicesRepository.GetAll();

        return devices.Select(x => new GetDeviceDto
        {
            Id = x.Id,
            InterfaceId = x.InterfaceId,
            Name = x.Name,
            Description = x.Description,
            FigureType = x.FigureType,
            Size = x.Size,
            EditingDate = x.EditingDate,
            PosX = x.PosX,
            PosY = x.PosY,
            Color = x.Color,
            IsEnabled = x.IsEnabled,
        }).ToList();
    }

    public async Task<List<GetDeviceDto>> GetAllEnabledDevicesAsync()
    {
        var devices = await _devicesRepository.GetAllEnabled();

        return devices.Select(x => new GetDeviceDto
        {
            Id = x.Id,
            InterfaceId = x.InterfaceId,
            Name = x.Name,
            Description = x.Description,
            FigureType = x.FigureType,
            Size = x.Size,
            EditingDate = x.EditingDate,
            PosX = x.PosX,
            PosY = x.PosY,
            Color = x.Color,
            IsEnabled = x.IsEnabled,
        }).ToList();
    }

    public async Task DeleteDeviceAsync(Guid id)
    {
        await _devicesRepository.Delete(id);
    }
}
