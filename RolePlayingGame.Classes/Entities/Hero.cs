using RolePlayingGame.Classes.Enums;
using RolePlayingGame.Classes.Interfaces;

namespace RolePlayingGame.Classes.Entities;

public class Hero : Entity, ITargetable, IMovable
{
    public string ImagePath { get; set; } = string.Empty;

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                PositionY--;
                break;
            case Direction.East:
                PositionX++;
                break;
            case Direction.West:
                PositionX--;
                break;
            case Direction.South:
                PositionY++;
                break;
        }
    }

    public int TakeDamage(int damage)
    {
        HealthPoints -= damage;
        return damage;
    }
}