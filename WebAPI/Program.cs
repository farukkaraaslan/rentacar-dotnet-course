

using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers;
using Business.Mappers;
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
//Tarih i�lemlerii�in
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.
// register b�sines service clas�na alarak program.cs temizlendi.
builder.Services.RegisterBusinessService();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAnyOrigin",
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
// maping baslatmak i�in Auoto mapper Dependency incetion paketi ile kulland�k
builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddTransient<ITestService, TestManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
//exception handler yapildi
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// resimlerin taray�c�da g�r�nt�lenebilmesi i�in eklendi
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
