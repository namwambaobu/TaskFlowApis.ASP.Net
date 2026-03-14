using TaskFlow.Api.Database;
using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Features.Tasks.CreateTask;

public class CreateTaskHandler
{
    private readonly AppDbContext _db;

    public CreateTaskHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<CreateTaskResponse> Handle(CreateTaskRequest request)
    {
        var task = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            DueDate = request.DueDate,
            Status = TaskStatus.Pending
        };

        _db.Tasks.Add(task);

        await _db.SaveChangesAsync();

        return new CreateTaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status.ToString(),
            Priority = task.Priority.ToString(),
            DueDate = task.DueDate,
            CreatedAt = task.CreatedAt
        };
    }
}