using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Models;

namespace TestProject.Repositories;

public class InterfacesRepository
{
    private readonly AppDbContext _dbContext;
    public InterfacesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<InterfaceEntity>> Get()
    {
        return await _dbContext.Interfaces
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task Add(string name, string description)
    {
        var interfaceEntity = new InterfaceEntity
        {
            Name = name,
            Description = description,
            EditingDate = DateTime.Now
        };
        await _dbContext.AddAsync(interfaceEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(InterfaceEntity interfaceEntity, string name, string ndescription)
    {
        interfaceEntity.Name = name;

        interfaceEntity.Description = ndescription;

        interfaceEntity.EditingDate = DateTime.Now;

        _dbContext.Interfaces.Update(interfaceEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(InterfaceEntity interfaceEntity)
    {
        _dbContext.Interfaces.Remove(interfaceEntity);
        await _dbContext.SaveChangesAsync();
    }
}
