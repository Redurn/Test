using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Dto;

namespace TestProject.Models;

public class InterfaceEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime EditingDate { get; set; }
    public List<DeviceEntity> Devices { get; set; }
}

public interface IInterfacesRepository
{
    Task<List<InterfaceEntity>> GetAll();

    Task<InterfaceEntity> GetById(Guid id);

    Task Create(InterfaceEntity interfaceEntity);

    Task Update(Guid id, string name, string description);
}

public interface IInterfaceService
{
    Task CreateInterfaceAsync(CreateInterfaceDto dto);

    Task UpdateInterfaceAsync(UpdateInterfaceDto dto);

    Task<List<GetInterfaceDto>> GetAllInterfacesAsync();

    Task<GetInterfaceDto> GetInterfaceByIdAsync(Guid id);
}

