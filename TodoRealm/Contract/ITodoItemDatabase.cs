using MongoDB.Bson;
using TodoRealm.Models;

namespace TodoRealm.Contract;

public interface ITodoItemDatabase
{
    Task<IList<TodoItem>> GetItemsAsync();
    Task<IList<TodoItem>> GetItemsNotDoneAsync();
    Task<TodoItem?> GetItem(ObjectId id);
    Task<ObjectId> SaveItemAsync(TodoItem item);
    Task<ObjectId> DeleteItemAsync(TodoItem item);
}