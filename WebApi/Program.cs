using Microsoft.EntityFrameworkCore;

using Domain;
using Persistence;
using WebApi;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

app.UseCustomExceptionHandler();

app.MapGet("/", async (AppDbContext dbContext) =>
{
    var employees = await dbContext.Employees.ToListAsync();

    return Results.Ok(employees);
});

app.MapGet("/{id}", async (Guid id, AppDbContext dbContext) =>
{
    var employee = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);

    if (employee is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(employee);
});

app.MapPost("/", async (EmployeeDto employeeDto, AppDbContext dbContext) =>
{
    var employee = new Employee
    {
        Id = Guid.NewGuid(),
        Name = employeeDto.Name,
        Age = employeeDto.Age 
    };
    
    await dbContext.Employees.AddAsync(employee);
    await dbContext.SaveChangesAsync();

    return Results.Created();
});

app.MapPut("/{id}", async (Guid id, EmployeeDto employeeDto, AppDbContext dbContext) =>
{
    int updatedRows = await dbContext.Employees
        .Where(e => e.Id == id)
        .ExecuteUpdateAsync(e => e
            .SetProperty(u => u.Name, employeeDto.Name)
            .SetProperty(u => u.Age, employeeDto.Age));

    return updatedRows switch
    {
        0 => Results.NotFound(),
        1 => Results.NoContent(),
        _ => Results.BadRequest()
    };
});

app.MapDelete("/{id}", async (Guid id, AppDbContext dbContext) =>
{
    int deletedRows = await dbContext.Employees
        .Where(e => e.Id == id)
        .ExecuteDeleteAsync();

    return deletedRows switch
    {
        0 => Results.NotFound(),
        1 => Results.NoContent(),
        _ => Results.BadRequest()
    };
});

app.Run();
