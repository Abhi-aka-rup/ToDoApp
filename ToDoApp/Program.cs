using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Contexts;
using ToDoApp.Data.Repositories;
using ToDoApp.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseCosmos("https://todocosmosdemo.documents.azure.com:443/",
    "dXA1ub4UtDkYNmkuCSr0pOVyO7HTtXiOBVrufAJZ88lm2MQn85BRHWxnAK13vVnC3yWtwZzm4JOlqlbsaulgag==",
    "ToDoDb")
);
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
