namespace MongoDB_API.DTO;

public class PlayerDto
{
    public string Name { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public int Number { get; set; }
    public int Height { get; set; }
    public char Position { get; set; }
    public int Index { get; set; }
}
