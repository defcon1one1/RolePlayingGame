namespace RolePlayingGame.WPF.Settings;
public static class GameSettings
{
    public const string ImagesDirectory = @"C:\Users\Jan\source\repos\RolePlayingGame\RolePlayingGame.Classes\Images\";
    public const string HeroImagePath = ImagesDirectory + "hero.png";

    public static readonly string[] grassTiles = [ImagesDirectory + "grass1.png",
        ImagesDirectory + "grass2.png",
        ImagesDirectory + "grass3.png"];

    public static readonly string TreeImagePath = ImagesDirectory + "tree1.png";

    public const int WorldSize = 768;
    public const int TileSize = 32;
}