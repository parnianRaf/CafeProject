using CafeFlow.Framework.Configuration;
using CafeFlow.Framework.ExceptionAgg.ExceptionHandling;
using CafeService.SqlCommandDataBase._Common.StartUpConfiguration;
using CommandRepositories.StartUpConfiguration;
using CustomerService.AppService._Common;
using CustomerService.QueriesDataBase.Configuration;
using QueriesRepositories.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddStartup(builder.Host , builder.Configuration);
builder.Services.SqlCommandRepoConfigure();
builder.Services.StartUpQueriesRepoConfiguration();
builder.Services.StartUpSqlDbConfiguration(builder.Configuration);
builder.Services.ConfigureSqlServerDataBase(builder.Configuration);
builder.Services.AppServiceConfigure(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();  
app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandling();
app.MapControllers();

app.Run();