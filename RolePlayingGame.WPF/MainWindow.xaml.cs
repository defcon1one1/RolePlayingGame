using RolePlayingGame.Classes.Map.Tiles;
using RolePlayingGame.WPF.Characters;
using RolePlayingGame.WPF.Enums;
using RolePlayingGame.WPF.Map;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RolePlayingGame.WPF;

public partial class MainWindow : Window
{
    private readonly World world;
    private Hero hero;
    private Image heroImage;
    private NPC enemyNpc;

    public MainWindow()
    {
        InitializeComponent();
        world = new World(GameSettings.WorldSize, GameSettings.TileSize);

        worldCanvas.Width = GameSettings.WorldSize;
        worldCanvas.Height = GameSettings.WorldSize;

        DrawBackground();
        DrawHero();
        DrawEnemy();

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

        if (IsTileWalkable(newPosX, newPosY))
        {
            hero.Move(direction);
            Canvas.SetLeft(heroImage, hero.PositionX * GameSettings.TileSize);
            Canvas.SetTop(heroImage, hero.PositionY * GameSettings.TileSize);
        }

        if (IsEnemyOnTile(enemyNpc.PositionX, enemyNpc.PositionY))
        {
            FightWindow fightWindow = new();
            fightWindow.ShowDialog();
        }
    }

    private bool IsEnemyOnTile(int enemyPosX, int enemyPosY)
    {
        return hero.PositionX == enemyPosX && hero.PositionY == enemyPosY;
    }

    private bool IsTileWalkable(int newPosX, int newPosY)
    {
        return (newPosX >= 0 && newPosX < GameSettings.WorldSize / GameSettings.TileSize
            && newPosY >= 0 && newPosY < GameSettings.WorldSize / GameSettings.TileSize
            && world.Tiles[newPosX, newPosY].Walkable);
    }

    private void DrawHero()
    {
        hero = new Hero
        {
            Name = "Hero",
            PositionX = world.GetMiddlePosition(),
            PositionY = world.GetMiddlePosition(),
            ImagePath = GameSettings.HeroImagePath
        };

        heroImage = hero.Draw();
        AddToCanvas(hero.PositionX, hero.PositionY, heroImage);
    }

    private void DrawEnemy()
    {
        enemyNpc = new()
        {
            Name = "Enemy",
            PositionX = world.GetMiddlePosition(),
            PositionY = 0,
            ImagePath = GameSettings.EnemyImagePath
        };
        Image enemyImage = enemyNpc.Draw();
        AddToCanvas(enemyNpc.PositionX, enemyNpc.PositionY, enemyImage);
    }

    private void DrawBackground()
    {
        for (int x = 0; x < GameSettings.WorldSize / GameSettings.TileSize; x++)
        {
            for (int y = 0; y < GameSettings.WorldSize / GameSettings.TileSize; y++)
            {
                Random random = new();
                Grass grassTile = new() { ImagePath = GameSettings.grassTiles[random.Next(GameSettings.grassTiles.Length)] };
                world.Tiles[x, y] = grassTile;

                Image grassImage = grassTile.Draw();

                AddToCanvas(x, y, grassImage);

                if (random.Next(100) > 95)
                {
                    Tree treeTile = new() { ImagePath = GameSettings.TreeImagePath };
                    world.Tiles[x, y] = treeTile;

                    Image treeImage = treeTile.Draw();
                    AddToCanvas(x, y, treeImage);
                }
            }
        }
    }

    private void AddToCanvas(int x, int y, Image image)
    {
        Canvas.SetLeft(image, x * GameSettings.TileSize);
        Canvas.SetTop(image, y * GameSettings.TileSize);
        worldCanvas.Children.Add(image);
    }
}