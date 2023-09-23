using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopDemo.Application;
using ShopDemo.Application.Commands.Product;
using ShopDemo.Application.Handlers.Product;
using ShopDemo.Application.Queries.Product;
using ShopDemo.Application.Repository;
using ShopDemo.Application.Repository.IRepository;
using ShopDemo.Domain.Entities;
using ShopDemo.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IRequestHandler<GetProductByIdQuery, Product>, GetProductByIdQueryHandler>();

builder.Services.AddScoped<IRequestHandler<CreateProductCommand, object>, CreateProductCommandHandler>();

// builder.Services.AddScoped<IRequestHandler<CreateProductCommand, object>, CreateProductCommandHandler>();

builder.Services.AddAutoMapper(typeof(MappingConfig).Assembly);
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