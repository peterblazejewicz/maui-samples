using System.Collections.Immutable;
using MongoDB.Bson;
using Realms;
using TodoRealm.Contract;
using TodoRealm.Models;

namespace TodoRealm.Data;

public class TodoItemDatabase : ITodoItemDatabase
{
    private readonly Lazy<Task<Realm>> _lazyInstance;

    public TodoItemDatabase()
    {
        _lazyInstance = new Lazy<Task<Realm>>(() =>
        {
            var config = new RealmConfiguration
            {
                ShouldCompactOnLaunch = (totalBytes, usedBytes) =>
                {
                    const int oneHundredMb = 100 * 1024 * 1024;
                    return totalBytes > (double)oneHundredMb &&
                           (double)usedBytes / totalBytes < 0.5;
                }
            };
            return Realm.GetInstanceAsync(config);
        });
    }

    public async Task<IList<TodoItem>> GetItemsAsync()
    {
        var db = await GetInstance();
        return db.All<TodoItem>().ToImmutableList();
    }

    public async Task<IList<TodoItem>> GetItemsNotDoneAsync()
    {
        var db = await GetInstance();
        return db.All<TodoItem>().Where(i => i.Done == false).ToImmutableList();
    }

    public async Task<TodoItem?> GetItem(ObjectId id)
    {
        var db = await GetInstance();
        return db.Find<TodoItem>(id);
    }

    public async Task<ObjectId> SaveItemAsync(TodoItem item)
    {
        var db = await GetInstance();
        var update = item.Id is { } id;
        return await db.WriteAsync(() => db.Add(item, update).Id);
    }

    public async Task<ObjectId> DeleteItemAsync(TodoItem item)
    {
        var id = item.Id;
        var db = await GetInstance();
        await db.WriteAsync(() => db.Remove(item));
        return id;
    }

    private async Task<Realm> GetInstance()
    {
        return await _lazyInstance.Value;
    }
}