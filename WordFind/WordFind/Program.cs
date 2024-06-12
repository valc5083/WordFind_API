using WordFind.Data;
using WordFind.Interface;
using WordFind.SearchService;
using Microsoft.EntityFrameworkCore;
using WordFind.Authentication;
using WordFind.Repository;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<MyDbContext>(
    options => options.UseSqlServer(
        "data source=LT-IN-VRAMWK2RT; database=Data; user id = sa; password=C0mpl3xP@ssw0rd; TrustServerCertificate = True;"
    )
);

builder.Services.AddScoped<IAuthenticationServices, CustomAuthenticationService>();
builder.Services.AddScoped<ISearchService, SearchService>(); 
builder.Services.AddScoped<IUserRepository, UserRepository>(); 
builder.Services.AddScoped<ITokenRepository, TokenRepository>(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddCors();

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();