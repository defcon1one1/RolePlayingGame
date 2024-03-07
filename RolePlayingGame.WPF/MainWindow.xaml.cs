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
    private readonly World world = new(GameSettings.WorldSize, GameSettings.TileSize);
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

        if (newPosX >= 0 && newPosX < GameSettings.WorldSize / GameSettings.TileSize
            && newPosY >= 0 && newPosY < GameSettings.WorldSize / GameSettings.TileSize)
        {
            hero.Move(direction);
            Canvas.SetLeft(heroImage, hero.PositionX * GameSettings.TileSize);
            Canvas.SetTop(heroImage, hero.PositionY * GameSettings.TileSize);
        }
    }

    private void DrawHero()
    {
        hero = new Hero()
        {
            Name = "Hero",
            PositionX = world.GetMiddlePosition(),
            PositionY = world.GetMiddlePosition(),
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
                Tile grassTile = new() { ImagePath = GameSettings.grassTiles[random.Next(GameSettings.grassTiles.Length)] };

                Image image = new()
                {
                    Source = new BitmapImage(new Uri(grassTile.ImagePath)),
                    Width = GameSettings.TileSize,
                    Height = GameSettings.TileSize
                };

                Canvas.SetLeft(image, x * GameSettings.TileSize);
                Canvas.SetTop(image, y * GameSettings.TileSize);

                worldCanvas.Children.Add(image);
            }
        }
    }
}