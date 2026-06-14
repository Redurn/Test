using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Models;

namespace TestProject.Repositories;

public class InterfacesRepository : IInterfacesRepository
{
    private readonly AppDbContext _dbContext;

    public InterfacesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<InterfaceEntity>> GetAll()
    {
        return await _dbContext.Interfaces
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<InterfaceEntity?> GetById(Guid id)
    {
        return await _dbContext.Interfaces.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(InterfaceEntity interfaceEntity)
    {
        await _dbContext.AddAsync(interfaceEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, string name, string description)
    {
        var selectedInterface = await _dbContext.Interfaces.FirstOrDefaultAsync(x => x.Id == id);

        selectedInterface.Name = name;
        selectedInterface.Description = description;
        selectedInterface.EditingDate = DateTime.Now;
        _dbContext.Update(selectedInterface);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(InterfaceEntity interfaceEntity)
    {
        _dbContext.Interfaces.Remove(interfaceEntity);
        await _dbContext.SaveChangesAsync();
    }
}
