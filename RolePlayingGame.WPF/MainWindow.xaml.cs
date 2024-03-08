using RolePlayingGame.Classes.Entities;
using RolePlayingGame.Classes.Enums;
using RolePlayingGame.Classes.Map;
using RolePlayingGame.Classes.Map.Tiles;
using RolePlayingGame.WPF.Settings;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RolePlayingGame.WPF;

public partial class MainWindow : Window
{
    private World world = new(GameSettings.WorldSize, GameSettings.TileSize);
    private Hero hero = new();
    private Image heroImage = new();

    public MainWindow()
    {
        InitializeComponent();
        worldCanvas.Width = GameSettings.WorldSize;
        worldCanvas.Height = GameSettings.WorldSize;

        DrawBackground();
        DrawHero();

        KeyDown += MainWindow_KeyDown;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        KeyDown += MainWindow_KeyDown;
    }

    private void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {

        hero.Visible = !hero.Visible;

        switch (e.Key)
        {
            case Key.W:
                MoveHero(Direction.North);
                break;
            case Key.S:
                MoveHero(Direction.South);
                break;
            case Key.A:
                MoveHero(Direction.West);
                break;
            case Key.D:
                MoveHero(Direction.East);
                break;
        }
    }

    private void MoveHero(Direction direction)
    {
        int newPosX = hero.PositionX;
        int newPosY = hero.PositionY;

        switch (direction)
        {
            case Direction.North:
                newPosY--;
                break;
            case Direction.South:
                newPosY++;
                break;
            case Direction.West:
                newPosX--;
                break;
            case Direction.East:
                newPosX++;
                break;
        }

        if (IsTileWalkable(newPosX, newPosY))
        {
            hero.Move(direction);
            Canvas.SetLeft(heroImage, hero.PositionX * GameSettings.TileSize);
            Canvas.SetTop(heroImage, hero.PositionY * GameSettings.TileSize);
        }
    }

    private bool IsTileWalkable(int x, int y)
    {
        if (x >= 0 && x < GameSettings.WorldSize / GameSettings.TileSize
            && y >= 0 && y < GameSettings.WorldSize / GameSettings.TileSize)
        {
            Tile newTile = world.Tiles[x, y];
            return world.Tiles[x, y].Walkable;
        }
        return false;
    }


    private void DrawHero()
    {
        hero = new Hero()
        {
            Name = "Hero",
            PositionX = 0,
            PositionY = 0,
            ImagePath = GameSettings.HeroImagePath
        };
        heroImage = new Image()
        {
            Source = new BitmapImage(new Uri(GameSettings.HeroImagePath)),
            Width = GameSettings.TileSize,
            Height = GameSettings.TileSize
        };


        Canvas.SetLeft(heroImage, hero.PositionX * GameSettings.TileSize);
        Canvas.SetTop(heroImage, hero.PositionY * GameSettings.TileSize);

        worldCanvas.Children.Add(heroImage);
    }

    private void DrawBackground()
    {
        for (int x = 0; x < GameSettings.WorldSize / GameSettings.TileSize; x++)
        {

            for (int y = 0; y < GameSettings.WorldSize / GameSettings.TileSize; y++)
            {
                Random random = new();
                Grass grassTile = new() { ImagePath = GameSettings.grassTiles[random.Next(2)], PositionX = x, PositionY = y, Walkable = true };
                world.Tiles[x, y] = grassTile;
                Image grassTileImage = new()
                {
                    Source = new BitmapImage(new Uri(grassTile.ImagePath)),
                    Width = GameSettings.TileSize,
                    Height = GameSettings.TileSize
                };


                Canvas.SetLeft(grassTileImage, x * GameSettings.TileSize);
                Canvas.SetTop(grassTileImage, y * GameSettings.TileSize);
                worldCanvas.Children.Add(grassTileImage);

                if (random.Next(10) >= 9)
                {
                    Tree treeTile = new() { ImagePath = GameSettings.TreeImagePath, PositionX = x, PositionY = y, Walkable = false };
                    world.Tiles[x, y] = treeTile;
                    Image treeTileImage = new()
                    {
                        Source = new BitmapImage(new Uri(treeTile.ImagePath)),
                        Width = GameSettings.TileSize,
                        Height = GameSettings.TileSize
                    };

                    Canvas.SetLeft(treeTileImage, x * GameSettings.TileSize);
                    Canvas.SetTop(treeTileImage, y * GameSettings.TileSize);
                    worldCanvas.Children.Add(treeTileImage);
                }

            }
        }
    }
}