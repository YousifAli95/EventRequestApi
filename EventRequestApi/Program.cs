
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models;
using Services;
using Contracts.Services;
using Contracts.Repositories;
using Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IEventRepository, EventRepository>(); 
builder.Services.AddTransient<IEventService, EventService>(); 
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EventsContext>(o => o.UseSqlServer(connString));
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
