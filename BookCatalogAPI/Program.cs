using BookCatalogAPI;
using BookCatalogAPI.Mappers;
using BookCatalogAPI.Requests.AuthorRequests;
using BookCatalogAPI.Requests.BookRequests;
using BookCatalogAPI.Requests.CityRequests;
using BookCatalogAPI.Requests.LanguageRequests;
using BookCatalogAPI.Requests.PublishingRequests;
using BookCatalogAPI.Requests.SubjectRequests;
using BookCatalogAPI.Services.Authors.AuthorServices;
using BookCatalogAPI.Services.Books.BookServices;
using BookCatalogAPI.Services.Cities.CityServices;
using BookCatalogAPI.Services.Languages.LanguageServices;
using BookCatalogAPI.Services.Publishings.PublishingServices;
using BookCatalogAPI.Services.Subjects.SubjectServices;
using BookCatalogAPI.Validations.AuthorValidators;
using BookCatalogAPI.Validations.BookValidators;
using BookCatalogAPI.Validations.CityValidators;
using BookCatalogAPI.Validations.LanguageValidators;
using BookCatalogAPI.Validations.PublishingValidators;
using BookCatalogAPI.Validations.SubjectValidators;
using FluentValidation;
//using BookAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//// Custome Services

builder.Services.AddDbContext<ApplicationDbContext>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// add AutoMapper Profile
builder.Services.AddAutoMapper(typeof(BookProfile),
    typeof(AuthorProfile),
    typeof(CityProfile),
    typeof(LanguageProfile),
    typeof(PublishingProfile),
    typeof(SubjectProfile));

// Add Fluent Validation Abstractions
builder.Services.AddScoped<IValidator<CreateBookRequest>, CreateBookRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateBookRequest>, UpdateBookRequestValidator>();

builder.Services.AddScoped<IValidator<CreateAuthorRequest>, CreateAuthorRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateAuthorRequest>, UpdateAuthorRequestValidator>();

builder.Services.AddScoped<IValidator<CreateCityRequest>, CreateCityRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateCityRequest>, UpdateCityRequestValidator>();

builder.Services.AddScoped<IValidator<CreateLanguageRequest>, CreateLanguageRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateLanguageRequest>, UpdateLanguageRequestValidator>();

builder.Services.AddScoped<IValidator<CreatePublishingRequest>, CreatePublishingRequestValidator>();
builder.Services.AddScoped<IValidator<UpdatePublishingRequest>, UpdatePublishingRequestValidator>();

builder.Services.AddScoped<IValidator<CreateSubjectRequest>, CreateSubjectRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateSubjectRequest>, UpdateSubjectRequestValidator>();

// Add my Services
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<ILanguageService, LanguageService>();

builder.Services.AddScoped<ISubjectService, SubjectService>();

builder.Services.AddScoped<IPublishingService, PublishingService>();


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