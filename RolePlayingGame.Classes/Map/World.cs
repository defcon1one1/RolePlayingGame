namespace RolePlayingGame.Classes.Map;

public class World
{
    public int WorldSize { get; set; }
    public int TileSize { get; set; }
    public Tile[,] Tiles { get; set; }

    public World(int worldSize, int tileSize)
    {
        WorldSize = worldSize;
        TileSize = tileSize;
        Tiles = new Tile[WorldSize / TileSize, WorldSize / TileSize];
    }


    public int GetMiddlePosition()
    {
        return (WorldSize / TileSize) / 2;
    }
}
