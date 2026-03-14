using FluentValidation;

namespace TaskFlow.Api.Features.Tasks.CreateTask;

public static class CreateTaskEndpoint
{
    public static void MapCreateTaskEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/tasks", async (
            CreateTaskRequest request,
            CreateTaskHandler handler,
            IValidator<CreateTaskRequest> validator) =>
        {
            var validation = await validator.ValidateAsync(request);

            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            var result = await handler.Handle(request);

            return Results.Created($"/api/tasks/{result.Id}", result);
        });
    }
}