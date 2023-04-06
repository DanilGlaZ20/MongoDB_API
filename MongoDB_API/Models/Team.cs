using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_API.Models;

public class Team
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [Key]
    public string? Id { get; set; }
    
    
    [BsonElement("name")]
    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; } = null!;

    [BsonElement("conference")] 
    [BsonRepresentation(BsonType.String)] 
    public string Conference { get; set; } = null!;

    [BsonElement("founded")]
    [BsonRepresentation(BsonType.String)]
    public string Founded { get; set; } = null!;
    
    [BsonElement("title")]
    [BsonRepresentation(BsonType.Int32)] 
    public int Title { get; set; }
    
    
    [BsonElement("index")]
    [BsonRepresentation(BsonType.Int32)]
    [JsonIgnore]
    public int Index { get; set; }
}