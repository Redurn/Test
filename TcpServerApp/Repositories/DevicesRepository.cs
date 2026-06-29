using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TcpServerApp;
using TestProject.Models;

namespace TestProject.Repositories;

internal class DevicesRepository : IDevicesRepository
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

    public async Task<List<DeviceEntity>> GetAllEnabled()
    {
        return await _dbContext.Devices.Where(x => x.IsEnabled == true).ToListAsync();
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

    public async Task<DeviceEntity?> GetById(Guid id)
    {
        return await _dbContext.Devices.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(DeviceEntity deviceEntity)
    {
        _dbContext.Update(deviceEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var deviceEntity = await _dbContext.Devices.FindAsync(id);

        _dbContext.Devices.Remove(deviceEntity);
        await _dbContext.SaveChangesAsync();
    }
}
