using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Services;
using PharmacyStore.DataAccess;
using PharmacyStore.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PharmacyDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(PharmacyDBContext)));

});

builder.Services.AddScoped<IMedicinesService, MedicinesService>();
builder.Services.AddScoped<IMedicineRepository, MedicinesRepository>();
builder.Services.AddScoped<IWorkersService, WorkersService>();
builder.Services.AddScoped<IWorkerRepository, WorkersRepository>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<ICustomerRepository, CustomersRepository>();

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

app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.Run();
