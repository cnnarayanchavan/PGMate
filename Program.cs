using Microsoft.EntityFrameworkCore;
using PGMate;
using PGMate.Data;
using PGMate.Repositories;
using PGMate.Services;
//using PGMate.AutoM;

var builder = WebApplication.CreateBuilder(args);

//Register Repositories
builder.Services.AddScoped<IPGMemberRepository, PGMemberRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<ICleaningRepository, CleaningRepository>();

// Add services to the container.
builder.Services.AddScoped<IPGMemberService, PGMemberService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<ICleaningService, CleaningService>();

//Register Databse Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Register AutoMapper
// Register AutoMapper using assembly scanning
//No manual registration ==> You don’t need to do services.AddAutoMapper(typeof(MappingProfile)) manually
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
