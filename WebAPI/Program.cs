using Application.Validation;
using Helper;
using Infrastructure.Powershell;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IEmployeeValidator, EmployeeValidator>();
builder.Services.AddScoped<IPowerShellOperations, PowerShellOperations>();
builder.Services.AddScoped<IEmployeeStringify, EmployeeStringify>();

// Ignore this crap
builder.Services.AddScoped<Application2.Validation.IEmployeeValidator, Application2.Validation.EmployeeValidator>();
builder.Services.AddScoped<Infrastructure2.Powershell.IPowerShellOperations, Infrastructure2.Powershell.PowerShellOperations>();
builder.Services.AddScoped<Service.Helper.IEmployeeStringify, Service.Helper.EmployeeStringify>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
