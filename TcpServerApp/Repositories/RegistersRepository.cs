using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Models;

namespace TestProject.Repositories;

internal class RegistersRepository : IRegistersRepository
{
    private readonly AppDbContext _dbContext;

    public RegistersRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<RegisterEntity>> GetAll()
    {
        return await _dbContext.Registers
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<RegisterEntity>> GetByDeviceId(Guid deviceId)
    {
        return await _dbContext.Registers.Where(r =>  r.DeviceId == deviceId).ToListAsync();
    }

    public async Task<RegisterEntity?> GetById(Guid id)
    {
        return await _dbContext.Registers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<RegisterEntity>> GetRegistersOfEnabledDevices()
    {
        return await _dbContext.Registers.Where(x => x.Device.IsEnabled).ToListAsync();
    }

    public async Task Create(RegisterEntity registerEntity)
    {
        await _dbContext.AddAsync(registerEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(RegisterEntity registerEntity)
    {
        _dbContext.Update(registerEntity);
        await _dbContext.SaveChangesAsync();
    }
}
