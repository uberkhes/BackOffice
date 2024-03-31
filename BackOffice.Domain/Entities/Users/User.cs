using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackOffice.Domain.Entities.Users;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string? UserName { get; set; }

    public string? LastName { get; set; }
}
