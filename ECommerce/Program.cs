using ECommerce.Business.Extensions;
using ECommerce.DataAccess.Extensions;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EcommerceContext>(_ => _.UseSqlServer("Server=LAPTOP-KQ0LS43E;Database=ECommerce;User Id=sa;Password=Password1;TrustServerCertificate=True;"));

builder.Services.AddDataAccessRegistration();
builder.Services.AddBusinessRegistration();

var app = builder.Build();


app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerceAPI V1");
});

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
