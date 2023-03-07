using DbTesterApp.Models;
using DbTesterApp.Models.Database;
using DbTesterApp.Models.NoSql;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DbTesterApp.Services.Mongo;
public class BooksNoSqlService
{
    private readonly IMongoCollection<BookNoSql> _booksCollection;

    public BooksNoSqlService(
        IOptions<MongoDatabaseModel> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<BookNoSql>("string");
    }

    public async Task<List<BookNoSql>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();

    public async Task<BookNoSql?> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(BookNoSql newBook) =>
        await _booksCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, BookNoSql updatedBook) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);

    public async Task RemoveAllAsync() =>
        await _booksCollection.DeleteManyAsync("{}");
}