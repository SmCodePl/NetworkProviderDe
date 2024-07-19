using NetworkProviderDe.Infrastructure;
using System.Runtime.CompilerServices;

// Add services to the container.



var builder = WebApplication.CreateBuilder(args);

// Get Connection string 
string connectionStr = builder.Configuration
    .GetConnectionString("NetProviderDe") ?? string.Empty;

if (string.IsNullOrWhiteSpace(connectionStr))
{
    throw new ArgumentException("Connection string is required", nameof(connectionStr));
}



// Add Infrastructure
builder.Services.AddInfrastructure(connectionStr, builder.Environment.IsDevelopment());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
