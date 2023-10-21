using AuthSimulator.Business.Manager;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using AuthSimulator.Business.Data;
using AuthSimulator.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;

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
        string connString = builder.Configuration.GetConnectionString("Lite") ?? "";
        connString = connString.Replace("~/", AppContext.BaseDirectory);
        if (!Directory.Exists(Path.GetDirectoryName(connString)))
            Directory.CreateDirectory(Path.GetDirectoryName(connString) ?? throw new Exception());

        builder.Services.AddDbContext<DB>(options => options.UseSqlite($"Data Source={connString}"));
        break;
    case "memory":
        builder.Services.AddDbContext<DB>(options => options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("Memory")?? "AuthSimulator"));
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
