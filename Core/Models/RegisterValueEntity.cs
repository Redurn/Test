using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Models;
public class RegisterValueEntity
{
    public Guid Id { get; set; }
    public Guid RegisterId { get; set; }
    public RegisterEntity Register { get; set; }
    public int Value { get; set; }
    public DateTime Timestamp { get; set; }
}

