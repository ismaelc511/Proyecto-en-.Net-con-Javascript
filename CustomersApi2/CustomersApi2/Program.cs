using CustomersApi2.Repositories;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(routing => routing.LowercaseUrls = true); //Convierte cada letra de la ruta en minuscula

builder.Services.AddDbContext<CustomerDatabaseContext>(builder => 
{
    builder.UseMySQL("Server=127.0.0.1; Port=3306; Database=system; UserId=root; Password=");
});


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
