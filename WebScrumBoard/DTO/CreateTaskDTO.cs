﻿namespace ScrumBoardAPI.DTO;

public class CreateTaskDTO
{
    public string? Name { get; set; }
    public int Priority { get; set; }
    public string? Description { get; set; }
}