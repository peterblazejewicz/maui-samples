using MongoDB.Bson;
using Realms;

namespace TodoRealm.Models;

public partial class TodoItem : IRealmObject
{
    [PrimaryKey] [MapTo("_id")] public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    [MapTo("name")] public string? Name { get; set; }
    [MapTo("notes")] public string? Notes { get; set; }
    [MapTo("done")] public bool Done { get; set; }
}