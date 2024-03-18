namespace RolePlayingGame.WPF.Entities;

public class Entity
{
    public string ImagePath { get; set; } = string.Empty;
    public string Name { get; set; } = "DefaultName";
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public bool Visible { get; set; }
}