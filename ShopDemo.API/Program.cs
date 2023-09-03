using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopDemo.Application.Handlers.Product;
using ShopDemo.Application.Repository;
using ShopDemo.Application.Repository.IRepository;
using ShopDemo.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(typeof(CreateProductCommandHandler).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();


// Add services to the container.

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