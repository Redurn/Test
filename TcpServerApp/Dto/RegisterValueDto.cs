using System;
using System.Collections.Generic;
using System.Text;

namespace TcpServerApp.Dto;

public class CreateRegisterValueDto
{
    public Guid RegisterId { get; set; }
    public int Value { get; set; }
    public DateTime Timestamp { get; set; }
}
