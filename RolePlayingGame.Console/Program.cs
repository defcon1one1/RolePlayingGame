using RolePlayingGame.Classes.Entities;
using RolePlayingGame.Classes.Enums;

Hero hero = new Hero() { Name = "Testero", Visible = true, HealthPoints = 100 };

while (true)
{
    var pressedKey = Console.ReadKey(true);
    switch (pressedKey.Key)
    {
        case ConsoleKey.W:
            hero.Move(Direction.North);
            break;
        case ConsoleKey.A:
            hero.Move(Direction.East);
            break;
        case ConsoleKey.S:
            hero.Move(Direction.South);
            break;
        case ConsoleKey.D:
            hero.Move(Direction.West);
            break;
    }
    Console.WriteLine();
    Console.WriteLine($"X: {hero.PositionX}");
    Console.WriteLine($"Y: {hero.PositionY}");
}