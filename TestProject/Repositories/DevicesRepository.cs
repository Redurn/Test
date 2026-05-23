using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Models;

namespace TestProject.Repositories;

internal class DevicesRepository
{
    private readonly AppDbContext _dbContext;

    public DevicesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DeviceEntity>> Get()
    {
        return await _dbContext.Devices
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<DeviceEntity>> GetByInterface(Guid interfaceId)
    {
        return await _dbContext.Devices.Where(d => d.InterfaceId == interfaceId).ToListAsync();
    }
    public async Task Add(Guid interfaceId, string name, string description, string figureType, int size,
                          int posX, int posY, string color) 
                          
    {
        var deviceEntity = new DeviceEntity
        {
            Name = name,
            Description = description,
            InterfaceId = interfaceId,
            FigureType = figureType,
            Size = size,
            PosX = posX,
            PosY = posY,
            Color = color,
            IsEnabled = false,
            EditingDate = DateTime.Now
        };
        await _dbContext.AddAsync(deviceEntity);
        await _dbContext.SaveChangesAsync();

    }

    public async Task Update(DeviceEntity deviceEntity, string name, string description, string figureType, int size,
                             int posX, int posY, string color)
    {
        deviceEntity.Name = name;
        deviceEntity.Description = description;
        deviceEntity.FigureType = figureType;
        deviceEntity.Size = size;
        deviceEntity.PosX = posX;
        deviceEntity.PosY = posY;
        deviceEntity.Color = color;
        deviceEntity.EditingDate = DateTime.Now;
        _dbContext.Update(deviceEntity);
        await _dbContext.SaveChangesAsync();
    }
}
