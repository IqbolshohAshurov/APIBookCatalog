using System.Reflection;
using AutoMapper;
//using BookAPI;
using BookCatalogAPI;
using BookCatalogAPI.Dtos;
using BookCatalogAPI.Mapper;
using BookCatalogAPI.Requests.AuthorRequests;
using BookCatalogAPI.Requests.BookRequests;
using BookCatalogAPI.Services;
using BookCatalogAPI.Services.Authors.AuthorServices;
using BookCatalogAPI.Services.Books.BookServices;
using BookCatalogAPI.Validations.AuthorValidators;
using BookCatalogAPI.Validations.BookValidators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//// Custome Services

builder.Services.AddDbContext<ApplicationDbContext>();

// add AutoMapper Profile
builder.Services.AddAutoMapper(typeof(BookProfile),
                                typeof(AuthorProfile));

// Add Fluent Validation Abstractions
builder.Services.AddScoped<IValidator<CreateBookRequest>, CreateBookRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateBookRequest>, UpdateBookRequestValidator>();

builder.Services.AddScoped<IValidator<CreateAuthorRequest>, CreateAuthorRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateAuthorRequest>, UpdateAuthorRequestValidator>();


// Add my Services
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IAuthorService, AuthorService>();

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