using System;
using System.Collections.Generic;
using System.Text;

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
}
