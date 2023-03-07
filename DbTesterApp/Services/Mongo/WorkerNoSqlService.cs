using DbTesterApp.Models;
using DbTesterApp.Models.Database;
using DbTesterApp.Models.NoSql;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DbTesterApp.Services.Mongo;
public class WorkersNoSqlService
{
    private readonly IMongoCollection<WorkerNoSql> _workersCollection;

    public WorkersNoSqlService(
        IOptions<MongoDatabaseModel> workerStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            workerStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            workerStoreDatabaseSettings.Value.DatabaseName);

        _workersCollection = mongoDatabase.GetCollection<WorkerNoSql>(
            workerStoreDatabaseSettings.Value.WorkersCollectionName);
    }

    public async Task<List<WorkerNoSql>> GetAsync() =>
        await _workersCollection.Find(_ => true).ToListAsync();

    public async Task<WorkerNoSql?> GetAsync(string id) =>
        await _workersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(WorkerNoSql newWorker) =>
        await _workersCollection.InsertOneAsync(newWorker);

    public async Task UpdateAsync(string id, WorkerNoSql updatedWorker) =>
        await _workersCollection.ReplaceOneAsync(x => x.Id == id, updatedWorker);

    public async Task RemoveAsync(string id) =>
        await _workersCollection.DeleteOneAsync(x => x.Id == id);

    public async Task RemoveAllAsync() =>
        await _workersCollection.DeleteManyAsync("{}");
}