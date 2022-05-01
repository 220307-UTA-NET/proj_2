using stpApp.BusinessLogic;
using stpAPP.DataLogic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, SQLRepository>();


string connectionString = builder.Configuration["connectionString"];

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration["DBInfo:ConnectionString"]));
builder.Services.AddCors();



/*

Debug = string connectionString = builder.Configuration["connectionString"];

Release = string connectionString = builder.Configuration.GetConnectionString("RPS-DB-Connection"); if release v2 does not work

Release v2 (works) after publish to azure = string connectionString = builder.Configuration.GetConnectionString("connectionString");

*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(
    x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
            );

app.MapControllers();

app.Run();
