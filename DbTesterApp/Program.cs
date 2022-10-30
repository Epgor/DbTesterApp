using DbTesterApp.Models.Database;
using DbTesterApp.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TestSeedingService>();

var redisMuxer = ConnectionMultiplexer.Connect("localhost:6379,abortConnect=false,password=password");
builder.Services.AddSingleton<IConnectionMultiplexer>(redisMuxer);

builder.Services.Configure<MongoDatabaseModel>(
    builder.Configuration.GetSection("MongoDatabase"));

builder.Services.AddSingleton<BooksService>();

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
