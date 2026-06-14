using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Dto;

namespace TestProject.Models;
public class RegisterEntity
{
    public Guid Id { get; set; }
    public Guid DeviceId { get; set; }
    public DeviceEntity Device { get; set; }
    public List<RegisterValueEntity> Values { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime EditingDate { get; set; }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
        EditingDate = DateTime.Now;
    }
}

public interface IRegistersRepository
{
    Task<List<RegisterEntity>> GetByDeviceId(Guid deviceId);
    Task Create(RegisterEntity registerEntity);
    Task Update(RegisterEntity registerEntity);
    Task<RegisterEntity> GetById(Guid id);
    Task<List<RegisterEntity>> GetAll();
    Task<List<RegisterEntity>> GetRegistersOfEnabledDevices();
}

public interface IRegisterService
{
    Task<List<GetRegistersDto>> GetByDeviceIdAsync(Guid deviceId);
    Task CreateRegisterAsync(CreateRegisterDto dto);
    Task UpdateRegisterAsync(UpdateRegisterDto dto);
    Task<List<GetRegistersDto>> GetAllRegistersAsync();
    Task<List<GetRegisterIdDto>> GetRegistersOfEnabledDevicesAsync();
}
