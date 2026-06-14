using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Models;
public class LogEntity
{
    public Guid Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string Message { get; set; }
    public string Type { get; set; }
}