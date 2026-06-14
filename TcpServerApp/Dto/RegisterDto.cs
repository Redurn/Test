using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Dto;

public class GetRegistersDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description {  get; set; }
    public Guid DeviceId { get; set; }
    public DateTime EditingDate { get; set; }
}

public class GetRegisterIdDto
{
    public Guid Id {  set; get; }
}

public class CreateRegisterDto
{
    public Guid DeviceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class UpdateRegisterDto
{
    public Guid Id {  get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
