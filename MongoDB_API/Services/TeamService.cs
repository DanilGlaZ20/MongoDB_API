
using Microsoft.Extensions.Options;
using MongoDB_API.Models;
using MongoDB.Driver;
namespace MongoDB_API.Services;

public class TeamService
{
   
        private readonly IMongoCollection<Team> _collection; 
       

        
        public TeamService(IOptions<BasketballDataBaseSettings> basketballDatabaseSettings) 
        { 
            var mongoClient = new MongoClient( 
                basketballDatabaseSettings.Value.ConnectionString); 
 
            var mongoDatabase = mongoClient.GetDatabase( 
                basketballDatabaseSettings.Value.DatabaseName); 
 
            _collection = mongoDatabase.GetCollection<Team>(
                basketballDatabaseSettings.Value.BasketballCollectionName); 
        } 
        
        public async Task<List<Team>> GetTeamAsync() => 
            await _collection.Find(_ => true).ToListAsync();

        public async Task<List<Team>> GetByTitleAsync(int title) =>
            await _collection.Find(x => x.Title > title).ToListAsync();
        public async Task<Team?> GetTeamByIdAsync(string id) => 
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync(); 
 
        public async Task CreateNewTeamAsync(Team team) => 
            await _collection.InsertOneAsync(team); 
 
        public async Task UpdateTeamAsync(Team team ) => 
            await _collection.ReplaceOneAsync(x => x.Id == team.Id, team); 
 
        public async Task DeleteTeamAsync(string id) => 
            await _collection.DeleteOneAsync(x => x.Id == id); 
    
}