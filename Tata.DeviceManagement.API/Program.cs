using Microsoft.EntityFrameworkCore;
using Tata.DeviceManagement.Application.Interfaces;
using Tata.DeviceManagement.Infrastructure.DbContext;
using Tata.DeviceManagement.Infrastructure.RepositoryInterfaces;
using Tata.DeviceManagement.Infrastructure.RepositoryServices;
using Tata.DeviceManagement.Infrastructure.services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<DeviceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IDeviceRepository, DeviceRepositoryService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
