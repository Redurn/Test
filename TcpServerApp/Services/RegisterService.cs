using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Dto;
using TestProject.Models;

namespace TestProject.Services;

internal class RegisterService : IRegisterService
{
    private readonly IRegistersRepository _registersRepository;

    public RegisterService(IRegistersRepository registersRepository)
    {
        _registersRepository = registersRepository;
    }

    public async Task<List<GetRegistersDto>> GetAllRegistersAsync()
    {
        var registers = await _registersRepository.GetAll();

        return registers.Select(x => new GetRegistersDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            DeviceId = x.DeviceId,
            EditingDate = x.EditingDate,
        }).ToList();
    }

    public async Task<List<GetRegistersDto>> GetByDeviceIdAsync(Guid deviceId)
    {
        var selectedRegisters = await _registersRepository.GetByDeviceId(deviceId);

        return selectedRegisters.Select(x => new GetRegistersDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            DeviceId = deviceId,
            EditingDate = x.EditingDate,
        }).ToList();
    }

    public async Task<List<GetRegisterIdDto>> GetRegistersOfEnabledDevicesAsync()
    {
        var registers = await _registersRepository.GetRegistersOfEnabledDevices();
        return registers.Select(x => new GetRegisterIdDto
        {
            Id = x.Id
        }).ToList();
    }

    public async Task CreateRegisterAsync(CreateRegisterDto dto)
    {
        var registerEntity = new RegisterEntity
        {
            Name = dto.Name,
            Description = dto.Description,
            DeviceId = dto.DeviceId,
            EditingDate = DateTime.Now
        };

        await _registersRepository.Create(registerEntity);
    }

    public async Task UpdateRegisterAsync(UpdateRegisterDto dto)
    {
        var registerEntity = await _registersRepository.GetById(dto.Id);

        registerEntity.Update(dto.Name, dto.Description);

        await _registersRepository.Update(registerEntity);
    }

    public async Task DeleteRegisterAsync(Guid id)
    {
        await _registersRepository.Delete(id);
    }
}
