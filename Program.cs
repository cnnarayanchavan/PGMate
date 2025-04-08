using Microsoft.EntityFrameworkCore;
using PGMate;
using PGMate.Data;
using PGMate.Repositories;
using PGMate.Services;

var builder = WebApplication.CreateBuilder(args);

//Register Repositories
builder.Services.AddScoped<IPGMemberRepository, PGMemberRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<ICleaningRepository, CleaningRepository>();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPGMemberService, PGMemberService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<ICleaningService, CleaningService>();



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
