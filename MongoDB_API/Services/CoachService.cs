using Microsoft.Extensions.Options;
using MongoDB_API.Models;
using MongoDB.Driver;

namespace MongoDB_API.Services;

public class CoachService 
{ 
    private readonly IMongoCollection<Coach> _collection; 
 
    public CoachService(IOptions<BasketballDataBaseSettings> basketballDatabaseSettings) 
    { 
        var mongoClient = new MongoClient( 
            basketballDatabaseSettings.Value.ConnectionString); 
 
        var mongoDatabase = mongoClient.GetDatabase( 
            basketballDatabaseSettings.Value.DatabaseName); 
 
        _collection = mongoDatabase.GetCollection<Coach>(
            basketballDatabaseSettings.Value.BasketballCollectionName); 
    } 
     
    public async Task<List<Coach>> GetCoachAsync() => 
        await _collection.Find(_ => true).ToListAsync(); 
 
    public async Task<Coach?> GetCoachByIdAsync(string id) => 
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync(); 
 
    public async Task CreateNewCoachAsync(Coach coach) => 
        await _collection.InsertOneAsync(coach); 
 
    public async Task UpdateCoachAsync(Coach coach ) => 
        await _collection.ReplaceOneAsync(x => x.Id == coach.Id, coach); 
 
    public async Task DeleteCoachAsync(string id) => 
        await _collection.DeleteOneAsync(x => x.Id == id); 
}