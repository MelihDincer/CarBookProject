﻿namespace CarBookProject.Domain.Entities;

public class TagCloud
{
    public int TagCloudID { get; set; }
    public string Name { get; set; }
    public int BlogID { get; set; }
    public Blog Blog { get; set; }
}
