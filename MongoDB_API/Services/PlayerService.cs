using Microsoft.Extensions.Options;
using MongoDB_API.Models;
using MongoDB.Driver;

namespace MongoDB_API.Services;

public class PlayerService
{
    private readonly IMongoCollection<Player> _collection; 
 
    public PlayerService(IOptions<BasketballDataBaseSettings> basketballDatabaseSettings) 
    { 
        var mongoClient = new MongoClient( 
            basketballDatabaseSettings.Value.ConnectionString); 
 
        var mongoDatabase = mongoClient.GetDatabase( 
            basketballDatabaseSettings.Value.DatabaseName); 
 
        _collection = mongoDatabase.GetCollection<Player>(
            basketballDatabaseSettings.Value.BasketballCollectionName); 
    } 
     
    public async Task<List<Player>> GetPlayerAsync() => 
        await _collection.Find(_ => true).ToListAsync(); 
 
    public async Task<Player?> GetPlayerByIdAsync(string id) => 
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<Player> GetPlayerByNameAsync(string name) =>
        await _collection.Find(x => x.Name == name).FirstOrDefaultAsync();
    public async Task CreateNewPlayerAsync(Player player) => 
        await _collection.InsertOneAsync(player); 
 
    public async Task UpdatePlayerAsync (Player player) => 
        await _collection.ReplaceOneAsync(x => x.Id == player.Id, player); 
 
    public async Task DeletePlayerAsync(string id) => 
        await _collection.DeleteOneAsync(x => x.Id == id); 
} 
