﻿using RolePlayingGame.WPF.Enums;

namespace RolePlayingGame.WPF.Entities;

public class Hero : Entity
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