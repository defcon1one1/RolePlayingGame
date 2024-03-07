using RolePlayingGame.Classes.Enums;
using RolePlayingGame.Classes.Interfaces;

namespace RolePlayingGame.Classes.Entities;

public class Hero : Entity, IMovable
{
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
}