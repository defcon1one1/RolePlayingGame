namespace RolePlayingGame.WPF;

public static class GameSettings
{
    public const string ImagesDirectory = @"C:\Users\Jan\source\repos\RolePlayingGame\RolePlayingGame.WPF\Images\";
    public const string HeroImagePath = ImagesDirectory + "hero.png";

    public readonly static string[] grassTiles = [ImagesDirectory + "grass1.png",
        ImagesDirectory + "grass2.png",
        ImagesDirectory + "grass3.png"];

    public const string TreeImagePath = ImagesDirectory + "tree.png";

    public const int WorldSize = 768;
    public const int TileSize = 32;
}