using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TcpServerApp;
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

    public async Task Update(InterfaceEntity interfaceEntity)
    {
        _dbContext.Update(interfaceEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var interfaceEntity = await _dbContext.Interfaces.FindAsync(id);

        _dbContext.Interfaces.Remove(interfaceEntity);
        await _dbContext.SaveChangesAsync();
    }
}
