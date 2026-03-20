using AppUsersAPI.Domain.Repository;
using AppUsersAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using AppUserContext = AppUsersAPI.Infrastructure.Data.AppDbContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppUserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();