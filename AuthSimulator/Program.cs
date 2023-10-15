using AuthSimulator.Business.Manager;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using AuthSimulator.Business.Data;
using AuthSimulator.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

// Add services to the container.
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(UnitOfWork).Assembly));

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<UnitOfWork>();


string mode = builder.Configuration.GetSection("ConnectionMode").Value ?? "memory";

switch (mode.ToLower())
{
    case "sql":
        builder.Services.AddDbContext<DB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));
        break;
    case "lite":
        builder.Services.AddDbContext<DB>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Lite")));
        break;
    case "memory":
        builder.Services.AddDbContext<DB>(options => options.UseInMemoryDatabase("InMemory"));
        break;
    default:
        break;
}

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

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
