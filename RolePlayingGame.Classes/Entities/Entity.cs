namespace RolePlayingGame.Classes.Entities;

public class Entity
{
    public string Name { get; set; } = "DefaultName";
    public string ImagePath { get; set; } = string.Empty;
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public bool Visible { get; set; }
}