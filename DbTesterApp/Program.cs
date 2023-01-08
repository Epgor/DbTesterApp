using DbTesterApp.Entities;
using DbTesterApp.Models.Database;
using DbTesterApp.Services;
using MongoDB.Driver.Core.Configuration;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TestSeedingService>();
//redis
//var redisMuxer = ConnectionMultiplexer.Connect("localhost:6379,abortConnect=false,password=password");
var redisMuxer = ConnectionMultiplexer.Connect(builder.Configuration.GetSection("RedisDatabase:ConnectionString").Value);
builder.Services.AddSingleton<IConnectionMultiplexer>(redisMuxer);
//mongo
builder.Services.Configure<MongoDatabaseModel>(builder.Configuration.GetSection("MongoDatabase"));
builder.Services.AddSingleton<BooksNoSqlService>();
//sql
BookStoreDbContext.ConfigureConnection(builder.Configuration.GetSection("MSSQLDatabase:ConnectionString").Value);
builder.Services.AddDbContext<BookStoreDbContext>();
builder.Services.AddScoped<BookSqlService>();

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
