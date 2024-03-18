using RolePlayingGame.WPF.Enums;

namespace RolePlayingGame.WPF.Interfaces;

public interface IMovable
{
    void Move(Direction direction);
}