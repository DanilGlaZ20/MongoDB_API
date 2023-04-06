using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_API.Models;


public class Coach
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [Key]
    public string? Id { get; set; }
    
    
    [BsonElement("name")]
    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; } = null!;

    [BsonElement("lastname")] 
    [BsonRepresentation(BsonType.String)] 
    public string Lastname { get; set; } = null!;
    
    [BsonElement("age")]
    [BsonRepresentation(BsonType.Int32)]
    public int Age { get; set; }
    
    [BsonElement("index")]
    [BsonRepresentation(BsonType.Int32)]
    [JsonIgnore]
    public int Index { get; set; }
}