namespace WebScrumBoard2.DTO;
public class CreateTaskDTO
{
    public string? TaskTitle { get; set; }
    public string? TaskDescription { get; set; }
    public int TaskPriority { get; set; }
}