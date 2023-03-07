using DbTesterApp.Models;
using DbTesterApp.Models.Database;
using DbTesterApp.Models.NoSql;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DbTesterApp.Services.Mongo;
public class GenericNoSqlService<T>
{
    private readonly IMongoCollection<T> _genericsCollection;

    public GenericNoSqlService(
        IOptions<MongoDatabaseModel> workerStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            workerStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            workerStoreDatabaseSettings.Value.DatabaseName);

        var collectionName = workerStoreDatabaseSettings.Value.CollectionName<T>();

        _genericsCollection = mongoDatabase.GetCollection<T>(collectionName);
    }

    public async Task<List<T>> GetAsync()
    {
        return await _genericsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<T> GetAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        return await _genericsCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T newGeneric) =>
        await _genericsCollection.InsertOneAsync(newGeneric);

    public async Task<bool> UpdateAsync(string id, T updatedGeneric)
    {
        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        var result = await _genericsCollection.ReplaceOneAsync(filter, updatedGeneric);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> RemoveAsync(string id) 
    {
        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        var result = await _genericsCollection.DeleteOneAsync(filter);
        return result.DeletedCount > 0;
    }

    public async Task RemoveAllAsync() =>
        await _genericsCollection.DeleteManyAsync("{}");
}