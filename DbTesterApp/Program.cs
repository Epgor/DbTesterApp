using DbTesterApp.Models;
using DbTesterApp.Models.Database;
using DbTesterApp.Models.NoSql;
using DbTesterApp.Services;
using DbTesterApp.Services.Mongo;
using DbTesterApp.Services.MSSQL;
using DbTesterApp.Services.Redis;
using Microsoft.AspNetCore.Hosting;
using StackExchange.Redis;
using Microsoft.AspNetCore.Builder;
using DbTesterApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<TestSeedingService>();

//mongo
builder.Services.Configure<MongoDatabaseModel>(builder.Configuration.GetSection("MongoDatabase"));
var mongoServiceType = typeof(GenericMongoService<>);
foreach (var entry in CollectionsDictionary.NoSqlTypes)
{
    builder.Services.AddScoped(mongoServiceType.MakeGenericType(entry.Key));
}
//redis
var redisMuxer = ConnectionMultiplexer.Connect(builder.Configuration.GetSection("RedisDatabase:ConnectionString").Value);
builder.Services.AddSingleton<IConnectionMultiplexer>(redisMuxer);
var redisServiceType = typeof(GenericRedisService<>);
foreach (var entry in CollectionsDictionary.NoSqlTypes)
{
    builder.Services.AddScoped(redisServiceType.MakeGenericType(entry.Key));
}
//mssql
BookStoreDbContext.ConfigureConnection(builder.Configuration.GetSection("MSSQLDatabase:ConnectionString").Value);
builder.Services.AddDbContext<BookStoreDbContext>();
var mssqlServiceType = typeof(GenericSqlService<>);
foreach (var entry in CollectionsDictionary.SqlTypes)
{
    builder.Services.AddScoped(mssqlServiceType.MakeGenericType(entry.Key));
}

builder.Services.AddSingleton<HashIdentifierService>();
builder.Services.AddScoped<DataPreparationService>();
//var _ = dataPreparationService.PrepareData(10000);
builder.Services.AddScoped<JsonFileService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
//app.Urls.Add("https://0.0.0.0:1410");
//app.Urls.Add("http://0.0.0.0:321");
/*
var service = new TestSeedingService();
service.SeedSql();
service.SeedNoSql();
*/
app.Run();
