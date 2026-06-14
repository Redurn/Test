using System;
using System.Collections.Generic;
using System.Text;
using TcpServerApp.Dto;

namespace TestProject.Models;
public class RegisterValueEntity
{
    public Guid Id { get; set; }
    public Guid RegisterId { get; set; }
    public RegisterEntity Register { get; set; }
    public int Value { get; set; }
    public DateTime Timestamp { get; set; }
}

public interface IRegisterValuesRepository
{
    Task CreateRegisterValues(List<RegisterValueEntity> registerValues);
}

public interface IRegisterValueService
{
    Task CreateRegisterValuesAsync(List<CreateRegisterValueDto> registerValues);
}

