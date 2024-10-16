using Microsoft.EntityFrameworkCore;
using ReservationSystemBackend.Core.Interfaces;
using ReservationSystemBackend.Core.Services;
using ReservationSystemBackend.Infraestructure.Data;
using ReservationSystemBackend.Infraestructure.Mappings;
using ReservationSystemBackend.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReservationSystemDbContext>(cf => 
        cf.UseSqlServer(builder.Configuration.GetConnectionString("ReservationSystemDB")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IClientService, ClientService>();

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
