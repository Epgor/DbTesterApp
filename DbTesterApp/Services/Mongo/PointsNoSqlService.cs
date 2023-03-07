using DbTesterApp.Models;
using DbTesterApp.Models.Database;
using DbTesterApp.Models.NoSql;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DbTesterApp.Services.Mongo;
public class PointsNoSqlService
{
    private readonly IMongoCollection<PointNoSql> _numbersCollection;

    public PointsNoSqlService(
        IOptions<MongoDatabaseModel> workerStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            workerStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            workerStoreDatabaseSettings.Value.DatabaseName);

        _numbersCollection = mongoDatabase.GetCollection<PointNoSql>(
            workerStoreDatabaseSettings.Value.PointsCollectionName);
    }

    public async Task<List<PointNoSql>> GetAsync() =>
        await _numbersCollection.Find(_ => true).ToListAsync();

    public async Task<PointNoSql?> GetAsync(string id) =>
        await _numbersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PointNoSql newPoint) =>
        await _numbersCollection.InsertOneAsync(newPoint);

    public async Task UpdateAsync(string id, PointNoSql updatedPoint) =>
        await _numbersCollection.ReplaceOneAsync(x => x.Id == id, updatedPoint);

    public async Task RemoveAsync(string id) =>
        await _numbersCollection.DeleteOneAsync(x => x.Id == id);

    public async Task RemoveAllAsync() =>
        await _numbersCollection.DeleteManyAsync("{}");
}