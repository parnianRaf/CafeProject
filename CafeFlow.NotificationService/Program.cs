using CafeFlow.AuthenticationService.ExceptionHandling;
using CafeFlow.Framework.Configuration;
using CafeFlow.Framework.ExceptionAgg.ExceptionHandling;
using CafeFlow.NotifcationService.SetUpConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfigurationHandler(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddStartup(builder.Host);
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
app.MapControllers();

app.UseExceptionHandling();


app.Run();

