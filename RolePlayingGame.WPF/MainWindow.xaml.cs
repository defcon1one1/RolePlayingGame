using RolePlayingGame.Classes.Entities;
using RolePlayingGame.Classes.Map;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RolePlayingGame.WPF;

public partial class MainWindow : Window
{
    private const string ImagesDirectory = @"C:\Users\Jan\source\repos\RolePlayingGame\RolePlayingGame.Classes\Images\";
    private const string HeroImage = ImagesDirectory + "hero.png";

    private readonly string[] grassTiles = [ImagesDirectory + "grass1.png",
        ImagesDirectory + "grass2.png",
        ImagesDirectory + "grass3.png"];

    private const int WorldSize = 768;
    private const int TileSize = 32;

    private readonly World world;
    private readonly Hero hero;

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

    }

    private void DrawHero()
    {
        throw new NotImplementedException();
    }

    private void DrawBackground()
    {
        for (int x = 0; x < WorldSize / TileSize; x++)
        {
            for (int y = 0; y < WorldSize / TileSize; y++)
            {
                Random random = new();
                Tile tile = new() { ImagePath = grassTiles[random.Next(grassTiles.Length)] };

                Image image = new()
                {

                };

            }
        }
    }
}