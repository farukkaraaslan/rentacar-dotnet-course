

using Business.Absract;
using Business.Concrete;
using Business.Rules;
using Business.Rules.Validation.FluentValidation;
using Core.DataAccess;
using Core.Entities;
using Core.Middlewares;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IBrandDal, EfBrandDal>()
    .AddSingleton<IBrandService, BrandManager>()
    .AddSingleton<BrandBusinesRules>()
    .AddSingleton<CarBusinessRules>()
    .AddSingleton<ColorBusinessRules>()
    .AddSingleton<BrandValidator>()
    .AddSingleton<CarValidator>()
    .AddSingleton<ColorValidator>()
    .AddSingleton<ICarDal,EfCarDal>()
    .AddSingleton<ICarService,CarManager>()
    .AddSingleton<IColorDal,EfColorDal>()
    .AddSingleton<IColorService,ColorManager>();

//builder.Services.AddTransient<ITestService, TestManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

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
