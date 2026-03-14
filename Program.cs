using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using FluentValidation;
using TaskFlow.Api.Database;
using TaskFlow.Api.Features.Tasks.CreateTask;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add EF Core PostgreSQL DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register feature services
builder.Services.AddScoped<CreateTaskHandler>();

// Register FluentValidation validator
builder.Services.AddScoped<IValidator<CreateTaskRequest>, CreateTaskValidator>();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TaskFlow API",
        Version = "v1",
        Description = "API documentation for TaskFlow"
    });
});

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskFlow API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map endpoints from feature
app.MapCreateTaskEndpoint();

app.MapControllers();

app.Run();