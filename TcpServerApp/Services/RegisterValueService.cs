using System;
using System.Collections.Generic;
using System.Text;
using TcpServerApp.Dto;
using TestProject.Models;

namespace TcpServerApp.Services;

internal class RegisterValueService : IRegisterValueService
{
    private readonly IRegisterValuesRepository _registerValuesRepository;

    public RegisterValueService(IRegisterValuesRepository registerValuesRepository)
    {
        _registerValuesRepository = registerValuesRepository;
    }

    public async Task CreateRegisterValuesAsync(List<CreateRegisterValueDto> registerValues)
    {
        var registerValueEntities = registerValues.Select(x => new RegisterValueEntity
        {
            Value = x.Value,
            RegisterId = x.RegisterId,
            Timestamp = x.Timestamp
        }).ToList();
        await _registerValuesRepository.CreateRegisterValues(registerValueEntities);
    }
}
