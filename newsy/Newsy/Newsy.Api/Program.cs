using Microsoft.EntityFrameworkCore;
using Newsy.Core;
using Newsy.Core.Services;
using Newsy.Data;
using Newsy.Service;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();


builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddDbContext<NewsyDbContext>(options => options
    .UseSqlServer(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("Newsy.Data")));

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
