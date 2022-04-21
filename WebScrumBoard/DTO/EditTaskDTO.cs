namespace ScrumBoardAPI.DTO;

public class EditTaskDTO
{
    public string? Name { get; set; }
    public int Priority { get; set; }
    public string? Description { get; set; }
    public string? GUID { get; set; }
}