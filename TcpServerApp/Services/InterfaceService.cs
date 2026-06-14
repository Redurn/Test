using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Dto;
using TestProject.Models;

namespace TestProject.Services;

public class InterfaceService : IInterfaceService
{
    private readonly IInterfacesRepository _interfacesRepository;

    public InterfaceService(IInterfacesRepository interfacesRepository)
    {
        _interfacesRepository = interfacesRepository;
    }

    public async Task<List<GetInterfaceDto>> GetAllInterfacesAsync()
    {
        var interfaces = await _interfacesRepository.GetAll();
        return interfaces.Select(x => new GetInterfaceDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            EditingDate = x.EditingDate,
        }).ToList();
    }

    public async Task<GetInterfaceDto> GetInterfaceByIdAsync(Guid id)
    { 
        var interfacEntity = await _interfacesRepository.GetById(id);

        if (interfacEntity is null)
        {
            throw new Exception("Интерфейс не найден");
        }

        return new GetInterfaceDto
        {
            Id = interfacEntity.Id,
            Name = interfacEntity.Name,
            Description = interfacEntity.Description,
            EditingDate = interfacEntity.EditingDate,
        };
    }

    public async Task CreateInterfaceAsync(CreateInterfaceDto dto)
    {
        var interfaceEntity = new InterfaceEntity
        {
            Name = dto.Name,
            Description = dto.Description,
            EditingDate = DateTime.Now
        };
        await _interfacesRepository.Create(interfaceEntity);
    }

    public async Task UpdateInterfaceAsync(UpdateInterfaceDto dto)
    {
        var selectedInterface = await _interfacesRepository.GetById(dto.Id);
        selectedInterface.Update(dto.Name, dto.Description);
        await _interfacesRepository.Update(selectedInterface);
    }
}
