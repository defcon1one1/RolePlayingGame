using RolePlayingGame.Classes.Entities;
using RolePlayingGame.Classes.Enums;
using RolePlayingGame.Classes.Map;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RolePlayingGame.WPF;

public partial class MainWindow : Window
{
    private const string ImagesDirectory = @"C:\Users\Jan\source\repos\RolePlayingGame-master\RolePlayingGame.Classes\Images\";
    private const string HeroImagePath = ImagesDirectory + "hero.png";

    private readonly string[] grassTiles = [ImagesDirectory + "grass1.png",
        ImagesDirectory + "grass2.png",
        ImagesDirectory + "grass3.png"];

    private const int WorldSize = 768;
    private const int TileSize = 32;

    private readonly World world;
    private Hero hero;
    private Image heroImage;

    public MainWindow()
    {
        InitializeComponent();
        world = new World(WorldSize, TileSize);

        worldCanvas.Width = WorldSize;
        worldCanvas.Height = WorldSize;

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

        if (newPosX >= 0 && newPosX < WorldSize / TileSize
            && newPosY >= 0 && newPosY < WorldSize / TileSize)
        {
            hero.Move(direction);
            Canvas.SetLeft(heroImage, hero.PositionX * TileSize);
            Canvas.SetTop(heroImage, hero.PositionY * TileSize);
        }
    }

    private void DrawHero()
    {
        hero = new Hero()
        {
            Name = "Hero",
            PositionX = world.GetMiddlePosition(),
            PositionY = world.GetMiddlePosition(),
            ImagePath = HeroImagePath
        };
        heroImage = new Image()
        {
            Source = new BitmapImage(new Uri(HeroImagePath)),
            Width = TileSize,
            Height = TileSize
        };

        Canvas.SetLeft(heroImage, hero.PositionX * TileSize);
        Canvas.SetTop(heroImage, hero.PositionY * TileSize);

        worldCanvas.Children.Add(heroImage);
    }

    private void DrawBackground()
    {
        for (int x = 0; x < WorldSize / TileSize; x++)
        {
            for (int y = 0; y < WorldSize / TileSize; y++)
            {
                Random random = new();
                Tile grassTile = new() { ImagePath = grassTiles[random.Next(grassTiles.Length)] };

                Image image = new()
                {
                    Source = new BitmapImage(new Uri(grassTile.ImagePath)),
                    Width = TileSize,
                    Height = TileSize
                };

                Canvas.SetLeft(image, x * TileSize);
                Canvas.SetTop(image, y * TileSize);

                worldCanvas.Children.Add(image);
            }
        }
    }
}