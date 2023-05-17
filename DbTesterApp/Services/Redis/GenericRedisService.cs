using DbTesterApp.Controllers;
using DbTesterApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Reflection;

namespace DbTesterApp.Services.Redis;

public class GenericRedisService<T>
{
    private readonly IConnectionMultiplexer _redis;
    private readonly string _pattern;
    public GenericRedisService(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _pattern = $"{CollectionsDictionary.CollectionName<T>()}-";
    }
    private IDatabase GetDatabase()
    {
        return _redis.GetDatabase();
    }
    public async Task<bool> KeyExist(string key)
    {
        var db = GetDatabase();
        if (db.KeyExists($"{_pattern}{key}"))
        {
            return true;
        }
        return false;
    }
    public async Task<bool> AddAsync(T value)
    {
        var key = typeof(T).GetProperty("Id");

        var idValue = key.GetValue(value) as string;

        var db = GetDatabase();
        var json = JsonConvert.SerializeObject(value);
        return await db.StringSetAsync($"{_pattern}{idValue}", json);
    }
    public async Task<bool> AddAsync(T value, string id)
    {
        var db = GetDatabase();
        var json = JsonConvert.SerializeObject(value);
        return await db.StringSetAsync($"{_pattern}{id}", json);
    }
    public async Task<bool> AddFastAsync(IEnumerable<T> entities, string id)
    {
        var db = GetDatabase();
        var json = JsonConvert.SerializeObject(entities);
        return await db.StringSetAsync($"{_pattern}{id}", json);
    }
    public async Task<List<T>> GetAllAsync()
    {
        var db = GetDatabase();
        var keys = _redis.GetServer(_redis.GetEndPoints()[0]).Keys(pattern: $"{ _pattern}*");
        var values = await db.StringGetAsync(keys.Select(k => (RedisKey)k).ToArray());
        var resultList = new List<T>();

        foreach (var value in values)
        {
            if (value.HasValue)
            {
                var deserializedValue = JsonConvert.DeserializeObject<T>(value.ToString());
                if (deserializedValue != null)
                    resultList.Add(deserializedValue);
                else
                    resultList.Add(Activator.CreateInstance<T>());
            }
        }
        return resultList;
    }
    public async Task<List<string>> GetAllFastAsync()
    {
        var db = GetDatabase();
        var keys = _redis.GetServer(_redis.GetEndPoints()[0]).Keys(pattern: $"{_pattern}*");
        var values = await db.StringGetAsync(keys.Select(k => (RedisKey)k).ToArray());
        var bookList = values.Where(v => v.HasValue).Select(v => v.ToString()).ToList();

        return bookList;
    }
    public async Task<T?> GetAsync(string key)
    {
        var db = GetDatabase();
        var json = await db.StringGetAsync($"{_pattern}{key}");
        if (!json.HasValue)
        {
            return Activator.CreateInstance<T>();// key not found
        }
        return JsonConvert.DeserializeObject<T>(json);
    }
    public async Task<string> GetFastAsync(string key)
    {
        var db = GetDatabase();
        var json = await db.StringGetAsync($"{_pattern}{key}");
        if (!json.HasValue)
        {
            return "";// key not found
        }
        return json;
    }
    public async Task<bool> UpdateAsync(string key, T value)
    {
        var db = GetDatabase();
        var json = JsonConvert.SerializeObject(value);
        return await db.StringSetAsync($"{_pattern}{key}", json);
    }
    public async Task<bool> DeleteAsync(string key)
    {
        var db = GetDatabase();
        return await db.KeyDeleteAsync($"{_pattern}{key}");
    }
    public async Task<bool> DeleteAllAsync()
    {
        var db = GetDatabase();
        var endpoints = db.Multiplexer.GetEndPoints();
        var server = db.Multiplexer.GetServer(endpoints.First());
        var keys = server.Keys(pattern: $"{_pattern}*");
        return await db.KeyDeleteAsync(keys.ToArray()) > 0;
    }
    public async Task<string> HealthCheck()
    {
        var db = GetDatabase();
        var pong = await db.PingAsync();
        return $"Ping! - Pong at:{pong}";
    }

    public async Task<List<string>> GetAllIds()
    {
        List<T> list = await GetAllAsync();
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
        var firstObject = await GetAllAsync();

        if (firstObject.Count > 0)
        {
            var objectId = GetIdValue(firstObject.First());
            await DeleteAsync(objectId);
        }
    }
}