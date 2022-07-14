
using Microsoft.EntityFrameworkCore;
using InventoryAPIs.Models;
using InventoryAPIs.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContext>(options =>
        options.UseSqlServer("Server = DESKTOP-4UQI8GH; Database=InventoryDb; Integrated Security=True; Trusted_Connection = True;"));

//builder.Services.AddDbContext<InventoryDbContext>(opt=> opt.UseSqlServer(builder.Configuration.GetConnectionString("InventoryConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed(origin => true)
         );

app.MapControllers();

app.Run();
