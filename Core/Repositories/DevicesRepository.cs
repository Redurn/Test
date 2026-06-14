using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Models;

namespace TestProject.Repositories;

public class DevicesRepository : IDevicesRepository
{
    private readonly AppDbContext _dbContext;

    public DevicesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DeviceEntity>> GetAll()
    {
        return await _dbContext.Devices
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<DeviceEntity>> GetByInterfaceId(Guid interfaceId)
    {
        return await _dbContext.Devices.Where(d => d.InterfaceId == interfaceId).ToListAsync();
    }
    public async Task Create(DeviceEntity deviceEntity)               
    {
        await _dbContext.AddAsync(deviceEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, string name, string description, string figureType, int size,
                             int posX, int posY, string color)
    {
        var deviceEntity = await _dbContext.Devices.FirstOrDefaultAsync(d => d.Id == id);
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
