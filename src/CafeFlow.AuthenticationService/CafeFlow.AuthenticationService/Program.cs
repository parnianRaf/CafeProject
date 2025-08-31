using CafeFlow.AuthenticationService.Configuration.StartUpConfiguration;
using CafeFlow.AuthenticationService.ExceptionHandling;
using CafeFlow.Framework.Configuration;
using CafeFlow.Framework.ExceptionAgg.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStartup(builder.Host);
builder.Services.AddInitialConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}


app.UseAuthorization();

app.MapControllers();
app.UseExceptionHandling();

app.Run();
