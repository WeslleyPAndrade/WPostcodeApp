using Wpostcode.AppService;
using Wpostcode.AppService.Interfaces;
using Wpostcode.Repository;
using Wpostcode.Repository.Interfaces;
using Wpostcode.Service;
using Wpostcode.Service.Interfaces;
using Wpostcode.Usecase;
using Wpostcode.Usecase.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAppService, AppService>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IUseCase, UseCase>();
builder.Services.AddSingleton<IRepository, Repository>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
