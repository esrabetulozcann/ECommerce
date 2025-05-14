using ECommerce.Business.Extensions;
using ECommerce.DataAccess.Extensions;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["AppSettings:ValidIssuer"],
        ValidAudience = builder.Configuration["AppSettings:ValidAudience"],// izin verilecek sitelerin denetlenip denetlenmeyeceğini söylüyor.
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"])),  // asıl anahtar yapımızın kontrol edilmesi. Yani tokenın yapısı bize mi ait kontrol ediliyor bu yapı sayesinde.
        ValidateIssuer = true,// hangi sitenin denetlenip denetlenmeyeceğini söylüyor. izin veriyoruz.
        ValidateAudience = true,
        ValidateLifetime = false, // uyghulamada yaşam süresi olsun mu ya izin veriyoruz. Yani token a süre tanımlamak için buraya true değerini veriyoruz ki token a süre verebillelim.
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
