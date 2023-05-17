using DbTesterApp.Models;
using DbTesterApp.Models.Database;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection;

namespace DbTesterApp.Services.Mongo;
public class GenericMongoService<T>
{
    private readonly IMongoCollection<T> _genericsCollection;

    public GenericMongoService(
        IOptions<MongoDatabaseModel> workerStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            workerStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            workerStoreDatabaseSettings.Value.DatabaseName);

        var collectionName = CollectionsDictionary.CollectionName<T>();

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

    public async Task CreateAsync(T entity)
    {
        await _genericsCollection.InsertOneAsync(entity);
    }
    public async Task CreateManyAsync(IEnumerable<T> entities)
    {
        await _genericsCollection.InsertManyAsync(entities);
    }

    public async Task<bool> UpdateAsync(string id, T updatedGeneric)
    {
        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        var result = await _genericsCollection.ReplaceOneAsync(filter, updatedGeneric);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id) 
    {
        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        var result = await _genericsCollection.DeleteOneAsync(filter);
        return result.DeletedCount > 0;
    }

    public async Task DeleteAllAsync() =>
        await _genericsCollection.DeleteManyAsync("{}");

    public async Task<List<string>> GetAllIds()
    {
        List<T> list = await GetAsync();
        List<string> ids = list.Select(GetIdValue).ToList();
        return ids;
    }

    private string GetIdValue(T obj)
    {
        PropertyInfo idProperty = typeof(T).GetProperty("Id");
        if (idProperty != null)
        {
            object idValue = idProperty.GetValue(obj);
            return idValue?.ToString();
        }
        return null;
    }

    public async Task DeleteSomeId()
    {
        var firstObject = await GetAsync();

        if (firstObject.Count > 0)
        {
            var objectId = GetIdValue(firstObject.First());
            await DeleteAsync(objectId);
        }
    }

}