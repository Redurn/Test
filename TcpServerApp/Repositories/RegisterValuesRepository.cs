using System;
using System.Collections.Generic;
using System.Text;
using TcpServerApp.Dto;
using TestProject;
using TestProject.Models;

namespace TcpServerApp.Repositories;

internal class RegisterValuesRepository : IRegisterValuesRepository
{
    private readonly AppDbContext _dbContext;

    public RegisterValuesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateRegisterValues(List<RegisterValueEntity> registerValues)
    {
        await _dbContext.RegisterValues.AddRangeAsync(registerValues);
        await _dbContext.SaveChangesAsync();
    }
}
