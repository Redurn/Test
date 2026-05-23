using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Models;

public class InterfaceEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime EditingDate { get; set; }
    public List<DeviceEntity> Devices { get; set; }
}
