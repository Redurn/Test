using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Models;

namespace TestProject.Repositories;

public class RegistersRepository
{
    private readonly AppDbContext _dbContext;

    public RegistersRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<RegisterEntity>> Get()
    {
        return await _dbContext.Registers
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<RegisterEntity>> GetByDevice(Guid deviceId)
    {
        return await _dbContext.Registers.Where(r =>  r.DeviceId == deviceId).ToListAsync();
    }

    public async Task Add(Guid deviceId, string name, string description)
    {
        var registerEntity = new RegisterEntity
        {
            Name = name,
            Description = description,
            DeviceId = deviceId,
            EditingDate = DateTime.Now
        };
        await _dbContext.AddAsync(registerEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(RegisterEntity registerEntity, string name, string description)
    {
        registerEntity.Name = name;
        registerEntity.Description = description;
        registerEntity.EditingDate = DateTime.Now;
        _dbContext.Update(registerEntity);
        await _dbContext.SaveChangesAsync();
    }
}
