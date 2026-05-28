namespace SpaceBattle.Lib;

/// <summary>
/// Uniform translational motion command without deformation, for one discrete tick.
/// NewPosition = Position + Velocity.
/// </summary>
public sealed class MoveCommand : ICommand
{
    private readonly IMovingObject _obj;

    public MoveCommand(IMovingObject obj)
    {
        _obj = obj;
    }

    public void Execute()
    {
        _obj.Position = _obj.Position + _obj.Velocity;
    }
}
