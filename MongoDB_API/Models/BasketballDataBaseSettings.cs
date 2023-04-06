namespace MongoDB_API.Models;
public class BasketballDataBaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;

    public string BasketballCollectionName { get; set; }
    
}