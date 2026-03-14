namespace TaskFlow.Api.Entities;
public class TaskItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } =  String.Empty;

    public string? Description { get; set; } =  String.Empty;

    public TaskStatus Status { get; set; }

    public TaskPriority Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;

}