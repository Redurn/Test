using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Dto;

public class CreateInterfaceDto
{
    public string Name { get; set; }

    public string Description { get; set; }
}

public class UpdateInterfaceDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}

public class GetInterfaceDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime EditingDate { get; set; }
}
