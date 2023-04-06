namespace MongoDB_API.DTO;

public class TeamDto
{
    public string Name { get; set; } = null!;
    public string Conference { get; set; } = null!;
    public string Founded { get; set; }
    public int Title { get; set; }
    public int Index { get; set; }
}