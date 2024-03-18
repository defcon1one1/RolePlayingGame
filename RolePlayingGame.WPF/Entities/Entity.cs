using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RolePlayingGame.WPF.Entities;

public class Entity
{
    public string ImagePath { get; set; } = string.Empty;
    public string Name { get; set; } = "DefaultName";
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public bool Visible { get; set; }

    public Image Draw()
    {
        Image image = new()
        {
            Source = new BitmapImage(new Uri(ImagePath)),
            Width = GameSettings.TileSize,
            Height = GameSettings.TileSize,
        };
        return image;
    }
}