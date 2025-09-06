using CafeFlow.Framework.Configuration;
using CafeFlow.Framework.ExceptionAgg.ExceptionHandling;
using CafeService.AppService.StartUpConfiguration;
using CafeService.CommandRepository.Configuration;
using CafeService.MongoDbApp.Configuration;
using CafeService.QueriesDataBase.Configuration;
using CafeService.QueryRepositories.Configuration;
using CafeService.SqlCommandRepository.StartUpConfiguration;
using CafeService.SqlServerDataBase.Configuration.StartUpConfiguration;
using CefeService.WebApiApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCafeService();
builder.Services.AddStartup(builder.Host , builder.Configuration);
builder.Services.StartUpMongoDbConfiguration();
builder.Services.StartUpCommandRepoConfiguration();
builder.Services.StartUpQueriesRepoConfiguration();
builder.Services.StartUpSqlDbConfiguration(builder.Configuration);
builder.Services.ConfigureSqlServerDataBase(builder.Configuration);
builder.Services.SqlCommandRepoConfigure();
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

