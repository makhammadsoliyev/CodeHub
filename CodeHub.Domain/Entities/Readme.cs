﻿using CodeHub.Domain.Commons;
namespace CodeHub.Domain.Entities;
public class Readme : Auditable
{
    public string Name { get; set; }
    public string Content { get; set; }
}
