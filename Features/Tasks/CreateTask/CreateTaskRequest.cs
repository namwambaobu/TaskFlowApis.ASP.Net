using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Features.Tasks.CreateTask;

public class CreateTaskRequest
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public TaskPriority Priority { get; set; }

    public DateTime? DueDate { get; set; }
}