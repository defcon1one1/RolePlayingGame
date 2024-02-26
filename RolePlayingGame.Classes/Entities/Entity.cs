namespace RolePlayingGame.Classes.Entities;

public class Entity
{
    public string Name { get; set; } = "DefaultName";
    public int HealthPoints { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public bool Visible { get; set; }
}